using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // 사용할 총알 지정
    public float spawnRateMin = 0.5f; // 총알 생성 주기 최솟값
    public float spawnRateMax = 3f; // 총알 생성 주기 최댓값

    private Transform target; // 총알이 날아갈 대상
    private float spawnRate; // 총알 생성 주기
    private float timeSpawnRate; // 마지막 사격 후 경과 시간

    void Start()
    {
        timeSpawnRate = 0; // 경과 시간 초기화
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); // 총알 생성 랜덤값 지정
        target = FindAnyObjectByType<PlayerController>().transform; // 대상이 될 타겟 플레이어 오브젝트를 찾아 지정
    }

    void Update()
    {
        timeSpawnRate += Time.deltaTime; // 경과 시간 갱신

        if (timeSpawnRate >= spawnRate) // 만약 경과 시간이 총알 생성 주기보다 크다면
        {
            timeSpawnRate = 0; // 경과 시간 초기화

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation); // 총알 프리팹 복제 후 생성
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax); // 총알 생성 랜덤값 다시 지정
        }
    }
}
