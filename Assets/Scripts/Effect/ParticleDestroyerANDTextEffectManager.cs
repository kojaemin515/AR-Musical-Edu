using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleDestroyerANDTextEffectManager : MonoBehaviour
{
    // ParticleSpawner 참조변수
    public ParticleSpawner particleSpawner;
    // ParticleLifeTime 참조변수. 파티클의 남은 수명 확인필요.
    public ParticleLifetime particleLifetime;
    // 점수 시스템을 위한 참조변수
    public RythmGameScoreManager rythmGameScoreManager;

    public GameObject PerfectCanvasPrefab;
    public GameObject GoodCanvasPrefab;
    public GameObject BadCanvasPrefab;
    public float displayDuration = 0.5f;



    private float remainingLifetime = 0.0f;

    public float getRemainingLifetime()
    {
        return this.remainingLifetime;
    }

    public void SetRemainingLifetime(float t)
    {
        this.remainingLifetime = t;
    }
    private void OnCollisionEnter(Collision collision)
    {
        particleLifetime = FindObjectOfType<ParticleLifetime>();

        GameObject firstParticle = null;
        if (particleLifetime != null )
        {
            if (particleSpawner.particleQueue.Count > 0)
            {
                firstParticle = particleSpawner.particleQueue.Peek();
                ParticleLifetime firstParticleLifetime = firstParticle.GetComponent<ParticleLifetime>();
                float collisionTime = Time.time;
                remainingLifetime = firstParticleLifetime.getLifetime()
                     - (collisionTime - firstParticleLifetime.getCreationTime());
                Debug.Log(getRemainingLifetime());
            }
        }
        else
        {
            Debug.Log("ParticleLifetime 컴포넌트를 가진 오브젝트를 찾을 수 없습니다.");
        }

        bool perfect = true;

        if (remainingLifetime < 0.15f && particleSpawner.particleQueue.Count > 0) // 퍼펙트 -> 100점
        {
            GameObject canvasInstance = Instantiate(PerfectCanvasPrefab);
            StartCoroutine(DestroyCanvasAfterTime(canvasInstance, displayDuration));

            rythmGameScoreManager.AddScore(perfect);
        }
        else if (remainingLifetime < 0.45f && particleSpawner.particleQueue.Count > 0) // 굿 -> 50점?
        {
            GameObject canvasInstance = Instantiate(GoodCanvasPrefab);
            StartCoroutine(DestroyCanvasAfterTime(canvasInstance, displayDuration));

            rythmGameScoreManager.AddScore(!perfect);
        }
        else // 밷 0점
        {
            GameObject canvasInstance = Instantiate(BadCanvasPrefab);
            StartCoroutine(DestroyCanvasAfterTime(canvasInstance, displayDuration));
        }
        if(particleSpawner.particleQueue.Count > 0)
        {
            particleSpawner.particleQueue.Dequeue();
            Destroy(firstParticle);
            remainingLifetime = 0.0f;
        }
        Destroy(firstParticle);
        remainingLifetime = 0.0f;
    }
    // 일정 시간 후 캔버스 제거
    private IEnumerator DestroyCanvasAfterTime(GameObject canvasInstance, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(canvasInstance);
    }
}