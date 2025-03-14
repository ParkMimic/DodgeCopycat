using UnityEngine;

public class Laser : MonoBehaviour
{
    private float trapLate;

    private float scaleChange;
    public float changeSpeed = 100;
    private float changeMax = 30f;

    private void Update()
    {
        trapLate += Time.deltaTime;

        if (trapLate >= 1)
        {
            scaleChange += Time.deltaTime * changeSpeed;

            if (transform.localScale.x <= changeMax)
            {
                transform.localScale = new Vector3(scaleChange, 0.5f, 0.5f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
