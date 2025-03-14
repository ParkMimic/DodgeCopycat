using UnityEngine;
using UnityEngine.Rendering;

public class Trigger : MonoBehaviour
{
    public GameObject door; // 문 오브젝트
    public GameObject trapObject; // 트랩 오브젝트
    public GameObject laserTrap;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // door와 trapObject가 null이 아닌지 확인
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

            // PlaneButton 객체 찾기
            PlaneButton planeButton = FindAnyObjectByType<PlaneButton>();
            if (planeButton != null)
            {
                planeButton.key();
            }

            Destroy(gameObject); // 트리거 오브젝트 제거
        }
    }
}