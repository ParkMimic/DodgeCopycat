using UnityEditor.Build.Content;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject door; // 문 오브젝트
    public float closePosition = 4f;

    private bool isClosing = false; // 닫히는 중인지 확인
    private float closeZ; // 문이 어디까지 닫힐지 확인

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
            if (!isClosing) // 이미 닫히는 중이 아니라면
            {
                isClosing = true;
            }

            GameObject gameObject = FindAnyObjectByType<GameManager>();

            Destroy(gameObject, 1.5f);
        }
    }
}