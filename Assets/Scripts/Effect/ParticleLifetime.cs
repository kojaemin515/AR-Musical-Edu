using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleLifetime : MonoBehaviour
{
    public ParticleSpawner particleSpawner; // particleSpawner 참조변수
    private const float lifetime = 1.0f; // 기본 파티클 수명
    private float creationTime; // 파티클 생성 시각
    public float getLifetime()
    {
        return lifetime;
    }

    public float getCreationTime()
    {
        return this.creationTime;
    }

    void Awake()
    {
        creationTime = Time.time; // 생성시각 기록
        StartCoroutine(DestroyAfterLifetime());
    }

    public void SetSpawnerReference(ParticleSpawner spawner)
    {
        particleSpawner = spawner;
    }

    private IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        if (particleSpawner.particleQueue.Count > 0)
        {
            particleSpawner.particleQueue.Dequeue();
        }
        Destroy(gameObject);
    }
}
