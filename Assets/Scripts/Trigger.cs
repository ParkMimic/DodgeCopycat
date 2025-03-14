using UnityEngine;
using UnityEngine.Rendering;

public class Trigger : MonoBehaviour
{
    public GameObject door; // �� ������Ʈ
    public GameObject trapObject; // Ʈ�� ������Ʈ

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // CompareTag�� ����ϴ� ���� �� ȿ�����̾�
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

            // PlaneButton ��ü ã��
            PlaneButton planeButton = FindAnyObjectByType<PlaneButton>();
            if (planeButton != null)
            {
                planeButton.key();
            }

            LaserTrap laserTrap = FindAnyObjectByType<LaserTrap>();
            if (laserTrap != null)
            {
                laserTrap.Key();
            }

            Destroy(gameObject); // Ʈ���� ������Ʈ ����
        }
    }
}