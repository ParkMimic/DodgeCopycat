using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; // �Ѿ��� �ӵ� ����
    private Rigidbody rigid; // �̵��� ����� ������ٵ� ������Ʈ
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.linearVelocity = Vector3.forward * speed;

        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
