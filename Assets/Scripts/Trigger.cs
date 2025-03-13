using UnityEditor.Build.Content;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject door; // �� ������Ʈ
    public GameObject trapObject; // Ʈ�� ������Ʈ

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