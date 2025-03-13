using UnityEditor.Build.Content;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject door; // 문 오브젝트
    public GameObject trapObject; // 트랩 오브젝트

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            if (door != null)
            {
                door.SetActive(true);
            }

            if (trapObject != null)
            {
                trapObject.SetActive(true);
            }

            PlaneButton planeButton = FindAnyObjectByType<PlaneButton>();
            planeButton.key();

            Destroy(gameObject);
        }
    }
}