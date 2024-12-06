using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleDestroyerANDTextEffectManager : MonoBehaviour
{
    // ParticleSpawner ��������
    public ParticleSpawner particleSpawner;
    // ParticleLifeTime ��������. ��ƼŬ�� ���� ���� Ȯ���ʿ�.
    public ParticleLifetime particleLifetime;
    // ���� �ý����� ���� ��������
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
            Debug.Log("ParticleLifetime ������Ʈ�� ���� ������Ʈ�� ã�� �� �����ϴ�.");
        }

        bool perfect = true;

        if (remainingLifetime < 0.15f && particleSpawner.particleQueue.Count > 0) // ����Ʈ -> 100��
        {
            GameObject canvasInstance = Instantiate(PerfectCanvasPrefab);
            StartCoroutine(DestroyCanvasAfterTime(canvasInstance, displayDuration));

            rythmGameScoreManager.AddScore(perfect);
        }
        else if (remainingLifetime < 0.45f && particleSpawner.particleQueue.Count > 0) // �� -> 50��?
        {
            GameObject canvasInstance = Instantiate(GoodCanvasPrefab);
            StartCoroutine(DestroyCanvasAfterTime(canvasInstance, displayDuration));

            rythmGameScoreManager.AddScore(!perfect);
        }
        else // �b 0��
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
    // ���� �ð� �� ĵ���� ����
    private IEnumerator DestroyCanvasAfterTime(GameObject canvasInstance, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(canvasInstance);
    }
}