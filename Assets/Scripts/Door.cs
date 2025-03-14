using UnityEngine;

public class Door : MonoBehaviour
{
    public float closePosition = 3f;
    private bool isClosing = true; // ������ ������ Ȯ��
    private bool isClosed = false;
    private float closeZ; // ���� ������ ������ Ȯ��

    private bool isOpening = false;
    private float timer;
    private float openZ;
    private Vector3 initialPosition; // ���� �ʱ� ��ġ ����

    void Start()
    {
        initialPosition = transform.position; // ���� �ʱ� ��ġ ����
        closeZ = initialPosition.z - closePosition; // �ʱ� ��ġ���� closePosition��ŭ �ڷ� �̵�
        openZ = initialPosition.z; // �ʱ� ��ġ�� ���� ��ġ
    }

    void Update()
    {
        if (isClosing)
        {
            transform.Translate(0, 0, -10f * Time.deltaTime);
        }

        if (transform.position.z <= closeZ)
        {
            isClosing = false;
            isClosed = true;
        }

        if (isClosed)
        {
            timer += Time.deltaTime;

            if (timer >= 10)
            {
                isOpening = true;
                isClosed = false; // ���� ������ �����ϸ� isClosed�� false�� ����
                timer = 0; // Ÿ�̸� �ʱ�ȭ
            }
        }

        if (isOpening)
        {
            transform.Translate(0, 0, 10f * Time.deltaTime);
        }

        if (transform.position.z >= openZ)
        {
            gameObject.SetActive(false);
        }
    }
}