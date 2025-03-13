using UnityEngine;

public class PlaneButton : MonoBehaviour
{
    public GameObject key1;
    public GameObject key2;

    private int keyCount;

    void Update()
    {
        if (keyCount == 2)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    public void key()
    {
        keyCount += 1;
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
