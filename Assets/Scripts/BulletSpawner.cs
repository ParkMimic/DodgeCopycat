using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // ����� �Ѿ� ����
    public float spawnRateMin = 0.5f; // �Ѿ� ���� �ֱ� �ּڰ�
    public float spawnRateMax = 3f; // �Ѿ� ���� �ֱ� �ִ�

    private Transform target; // �Ѿ��� ���ư� ���
    private float spawnRate; // �Ѿ� ���� �ֱ�
    private float timeSpawnRate; // ������ ��� �� ��� �ð�
    private bool isFirstShot = true; // ù ��° �Ѿ����� Ȯ���ϴ� ����

    void Start()
    {
        timeSpawnRate = 0; // ��� �ð� �ʱ�ȭ
        spawnRate = Random.Range(1f, 2f); // ù ��° �Ѿ��� 1�� �� �߻�
        target = FindAnyObjectByType<PlayerController>().transform; // ����� �� Ÿ�� �÷��̾� ������Ʈ�� ã�� ����

        Destroy(gameObject, 10f);
    }

    void Update()
    {
        timeSpawnRate += Time.deltaTime; // ��� �ð� ����

        if (timeSpawnRate >= spawnRate) // ���� ��� �ð��� �Ѿ� ���� �ֱ⺸�� ũ�ٸ�
        {
            timeSpawnRate = 0; // ��� �ð� �ʱ�ȭ

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation); // �Ѿ� ����
            bullet.transform.LookAt(target); // �÷��̾� �������� ����

            if (isFirstShot)
            {
                isFirstShot = false; // ù ��° �Ѿ��� �߻��
                spawnRate = Random.Range(spawnRateMin, spawnRateMax); // ���� ������ �ֱ�� ����
            }
            else
            {
                spawnRate = Random.Range(spawnRateMin, spawnRateMax); // ������ �ֱ�� ���� �Ѿ� ����
            }
        }

        if (transform.position.y <= 0.5f)
        {
            transform.Translate(0, 5f * Time.deltaTime, 0);
        }
    }
}