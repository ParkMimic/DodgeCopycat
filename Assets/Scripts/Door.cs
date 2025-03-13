using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float closePosition = 3f;

    private bool isClosing = true; // ������ ������ Ȯ��
    private float closeZ; // ���� ������ ������ Ȯ��
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
