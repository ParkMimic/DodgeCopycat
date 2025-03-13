using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float closePosition = 3f;

    private bool isClosing = true; // 닫히는 중인지 확인
    private float closeZ; // 문이 어디까지 닫힐지 확인
    void Start()
    {
        closeZ = closePosition - transform.position.z;
        Destroy(gameObject, 10f);
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
        }
    }
}
