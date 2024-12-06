using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public GameObject particlePrefab; // 생성할 파티클의 프리팹
    public Transform spawnLocation; // 생성 위치
    private float spawnInterval = 1.0f; // 기본 생성 주기

    private int[] beatNumPerSecond =
    {
        1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
        1, 1, 2, 2, 1, 1, 1, 1, 2, 1,
        1, 1, 2, 1, 1, 1, 2, 1, 1, 1,
        1, 1, 1, 0, 0, 0
    };
    public float indexInterval = 1.0f;
    private int currentIndex = 0;
    
    // 게임 한 판 종료시 UI를 띄우기 위한 참조변수
    public GameEndCanvasManager gameEndCanvasManager;

    // 파티클을 FIFO로 관리하기 위한 큐
    public Queue<GameObject> particleQueue = new Queue<GameObject>();

    // 코루틴 참조 변수
    private Coroutine spawnParticleCoroutine;
    private Coroutine increaseIndexCoroutine;


    private IEnumerator SpawnParticles()
    {
        while (true)
        {
            // 파티클 생성
            GameObject particleInstance = Instantiate(particlePrefab, spawnLocation.position, spawnLocation.rotation);

            // ParticleLifetime 스크립트에 particleSpawner 참조 설정
            ParticleLifetime particleLifetime = particleInstance.GetComponent<ParticleLifetime>();
            if (particleLifetime != null)
            {
                particleLifetime.SetSpawnerReference(this);
            }

            // 생성한 파티클을 큐에 추가
            particleQueue.Enqueue(particleInstance);
         
            // 다음 생성까지 대기
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
            // 인덱스 증가
            currentIndex++;

            // 인덱스가 배열의 길이를 초과하면 다시 0으로 초기화 후 파티클 생성종료
            if (currentIndex >= beatNumPerSecond.Length)
            {
                currentIndex = 0;
                StopCoroutine(increaseIndexCoroutine);
                StopCoroutine(spawnParticleCoroutine);
                // 여기서 GameEndCanvasManager의 메소드 호출?
                gameEndCanvasManager.SetUIOn();
            }

            yield return new WaitForSeconds(indexInterval);
        }
    }
}
