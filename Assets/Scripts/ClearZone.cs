using UnityEngine;

public class ClearZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager gameManager = FindAnyObjectByType<GameManager>();
            gameManager.GameClear();
        }
    }
}
