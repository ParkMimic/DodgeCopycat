using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; // 총알의 속도 저장
    private Rigidbody rigid; // 이동에 사용할 리지드바디 컴포넌트
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
