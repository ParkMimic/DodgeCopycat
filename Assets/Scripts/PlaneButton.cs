using UnityEngine;
using UnityEngine.UI;

public class PlaneButton : MonoBehaviour
{
    public GameObject laserTrap;

    private int keyCount;

    public void key()
    {
        keyCount += 1;

        if (keyCount == 2)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (keyCount == 2)
            {
                GameManager gameManager = FindAnyObjectByType<GameManager>();
                gameManager.LockOff();
            }
        }
    }
}
