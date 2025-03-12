using UnityEditor.Build.Content;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject door; // �� ������Ʈ
    public float closePosition = 4f;

    private bool isClosing = false; // ������ ������ Ȯ��
    private float closeZ; // ���� ������ ������ Ȯ��

    private void Start()
    {
        closeZ = closePosition - door.transform.position.z;
    }

    private void Update()
    {
        if (isClosing)
        {
            door.transform.Translate(0, 0, -10f * Time.deltaTime);
        }

        if (door.transform.position.z <= closeZ)
        {
            isClosing = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            if (!isClosing) // �̹� ������ ���� �ƴ϶��
            {
                isClosing = true;
            }

            GameObject gameObject = FindAnyObjectByType<GameManager>();

            Destroy(gameObject, 1.5f);
        }
    }
}