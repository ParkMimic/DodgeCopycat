using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // 사용할 총알 지정
    public float spawnRateMin = 0.5f; // 총알 생성 주기 최솟값
    public float spawnRateMax = 3f; // 총알 생성 주기 최댓값

    private Transform target; // 총알이 날아갈 대상
    private float spawnRate; // 총알 생성 주기
    private float timeSpawnRate; // 마지막 사격 후 경과 시간
    private bool isFirstShot = true; // 첫 번째 총알인지 확인하는 변수

    void Start()
    {
        timeSpawnRate = 0; // 경과 시간 초기화
        spawnRate = Random.Range(1f, 2f); // 첫 번째 총알은 1초 후 발사
        target = FindAnyObjectByType<PlayerController>().transform; // 대상이 될 타겟 플레이어 오브젝트를 찾아 지정

        Destroy(gameObject, 10f);
    }

    void Update()
    {
        timeSpawnRate += Time.deltaTime; // 경과 시간 갱신

        if (timeSpawnRate >= spawnRate) // 만약 경과 시간이 총알 생성 주기보다 크다면
        {
            timeSpawnRate = 0; // 경과 시간 초기화

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation); // 총알 생성
            bullet.transform.LookAt(target); // 플레이어 방향으로 조준

            if (isFirstShot)
            {
                isFirstShot = false; // 첫 번째 총알이 발사됨
                spawnRate = Random.Range(spawnRateMin, spawnRateMax); // 이후 랜덤한 주기로 설정
            }
            else
            {
                spawnRate = Random.Range(spawnRateMin, spawnRateMax); // 랜덤한 주기로 다음 총알 생성
            }
        }

        if (transform.position.y <= 0.5f)
        {
            transform.Translate(0, 5f * Time.deltaTime, 0);
        }
    }
}