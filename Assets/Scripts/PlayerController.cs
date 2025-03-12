using JetBrains.Annotations;
using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigid; // Rigidbody ����
    public float speed = 10f; // �ӵ��� �ֱ�
    void Start()
    {
        rigid = GetComponent<Rigidbody>();   // rigid�� Rigidbody ������Ʈ ����
    }

    void Update()
    {
        // ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        rigid.linearVelocity = newVelocity;
    }

    public void Die()
    {
        // �ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);

        // ���� �����ϴ� GameObject Ÿ���� ������Ʈ�� ã�� ��������
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager.EndGame();
    }
}
