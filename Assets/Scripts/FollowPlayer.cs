using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    Vector3 offset;
    void Start()
    {
        player = GameObject.Find("Player");
        offset = transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
