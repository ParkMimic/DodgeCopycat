using UnityEngine;
using UnityEngine.Rendering;

public class Trigger : MonoBehaviour
{
    public GameObject door; // �� ������Ʈ
    public GameObject trapObject; // Ʈ�� ������Ʈ
    public GameObject laserTrap;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // door�� trapObject�� null�� �ƴ��� Ȯ��
            if (door != null)
            {
                door.SetActive(true);
            }

            if (trapObject != null)
            {
                trapObject.SetActive(true);
            }

            if (laserTrap != null)
            {
                laserTrap.SetActive(true);
            }

            // PlaneButton ��ü ã��
            PlaneButton planeButton = FindAnyObjectByType<PlaneButton>();
            if (planeButton != null)
            {
                planeButton.key();
            }

            Destroy(gameObject); // Ʈ���� ������Ʈ ����
        }
    }
}