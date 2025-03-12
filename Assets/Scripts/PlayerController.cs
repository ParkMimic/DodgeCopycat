using JetBrains.Annotations;
using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigid; // Rigidbody 선언
    public float speed = 10f; // 속도값 주기
    void Start()
    {
        rigid = GetComponent<Rigidbody>();   // rigid에 Rigidbody 컴포넌트 삽입
    }

    void Update()
    {
        // 수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        rigid.linearVelocity = newVelocity;
    }

    public void Die()
    {
        // 자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);

        // 씬에 존재하는 GameObject 타입의 오브젝트를 찾아 가져오기
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager.EndGame();
    }
}
