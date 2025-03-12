using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // ����� �Ѿ� ����
    public float spawnRateMin = 0.5f; // �Ѿ� ���� �ֱ� �ּڰ�
    public float spawnRateMax = 3f; // �Ѿ� ���� �ֱ� �ִ�

    private Transform target; // �Ѿ��� ���ư� ���
    private float spawnRate; // �Ѿ� ���� �ֱ�
    private float timeSpawnRate; // ������ ��� �� ��� �ð�

    void Start()
    {
        timeSpawnRate = 0; // ��� �ð� �ʱ�ȭ
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); // �Ѿ� ���� ������ ����
        target = FindAnyObjectByType<PlayerController>().transform; // ����� �� Ÿ�� �÷��̾� ������Ʈ�� ã�� ����
    }

    void Update()
    {
        timeSpawnRate += Time.deltaTime; // ��� �ð� ����

        if (timeSpawnRate >= spawnRate) // ���� ��� �ð��� �Ѿ� ���� �ֱ⺸�� ũ�ٸ�
        {
            timeSpawnRate = 0; // ��� �ð� �ʱ�ȭ

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation); // �Ѿ� ������ ���� �� ����
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax); // �Ѿ� ���� ������ �ٽ� ����
        }
    }
}
