using UnityEngine;

public class Trap : MonoBehaviour
{
    public float rotateSpeed = 3;

    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
