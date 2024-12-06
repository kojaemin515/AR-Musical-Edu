using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleLifetime : MonoBehaviour
{
    public ParticleSpawner particleSpawner; // particleSpawner ��������
    private const float lifetime = 1.0f; // �⺻ ��ƼŬ ����
    private float creationTime; // ��ƼŬ ���� �ð�
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
        creationTime = Time.time; // �����ð� ���
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
