using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public GameObject particlePrefab; // ������ ��ƼŬ�� ������
    public Transform spawnLocation; // ���� ��ġ
    private float spawnInterval = 1.0f; // �⺻ ���� �ֱ�

    private int[] beatNumPerSecond =
    {
        1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
        1, 1, 2, 2, 1, 1, 1, 1, 2, 1,
        1, 1, 2, 1, 1, 1, 2, 1, 1, 1,
        1, 1, 1, 0, 0, 0
    };
    public float indexInterval = 1.0f;
    private int currentIndex = 0;
    
    // ���� �� �� ����� UI�� ���� ���� ��������
    public GameEndCanvasManager gameEndCanvasManager;

    // ��ƼŬ�� FIFO�� �����ϱ� ���� ť
    public Queue<GameObject> particleQueue = new Queue<GameObject>();

    // �ڷ�ƾ ���� ����
    private Coroutine spawnParticleCoroutine;
    private Coroutine increaseIndexCoroutine;


    private IEnumerator SpawnParticles()
    {
        while (true)
        {
            // ��ƼŬ ����
            GameObject particleInstance = Instantiate(particlePrefab, spawnLocation.position, spawnLocation.rotation);

            // ParticleLifetime ��ũ��Ʈ�� particleSpawner ���� ����
            ParticleLifetime particleLifetime = particleInstance.GetComponent<ParticleLifetime>();
            if (particleLifetime != null)
            {
                particleLifetime.SetSpawnerReference(this);
            }

            // ������ ��ƼŬ�� ť�� �߰�
            particleQueue.Enqueue(particleInstance);
         
            // ���� �������� ���
            if (beatNumPerSecond[currentIndex] != 0)
            {
                yield return new WaitForSeconds(spawnInterval / beatNumPerSecond[currentIndex]);
            }
            else
            {
                yield return new WaitForSeconds(2.0f);
            }
        }
    }

    public void SetInitParticles()
    {
        increaseIndexCoroutine = StartCoroutine(IncreaseIndexPeriodically());
        spawnParticleCoroutine = StartCoroutine(SpawnParticles());
    }

    private IEnumerator IncreaseIndexPeriodically()
    {
        while (true)
        {
            // �ε��� ����
            currentIndex++;

            // �ε����� �迭�� ���̸� �ʰ��ϸ� �ٽ� 0���� �ʱ�ȭ �� ��ƼŬ ��������
            if (currentIndex >= beatNumPerSecond.Length)
            {
                currentIndex = 0;
                StopCoroutine(increaseIndexCoroutine);
                StopCoroutine(spawnParticleCoroutine);
                // ���⼭ GameEndCanvasManager�� �޼ҵ� ȣ��?
                gameEndCanvasManager.SetUIOn();
            }

            yield return new WaitForSeconds(indexInterval);
        }
    }
}
