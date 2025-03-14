using UnityEngine;

public class Door : MonoBehaviour
{
    public float closePosition = 3f;
    private bool isClosing = true; // 닫히는 중인지 확인
    private bool isClosed = false;
    private float closeZ; // 문이 어디까지 닫힐지 확인

    private bool isOpening = false;
    private float timer;
    private float openZ;
    private Vector3 initialPosition; // 문의 초기 위치 저장

    void Start()
    {
        initialPosition = transform.position; // 문의 초기 위치 저장
        closeZ = initialPosition.z - closePosition; // 초기 위치에서 closePosition만큼 뒤로 이동
        openZ = initialPosition.z; // 초기 위치가 열린 위치
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
                isClosed = false; // 문이 열리기 시작하면 isClosed를 false로 설정
                timer = 0; // 타이머 초기화
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