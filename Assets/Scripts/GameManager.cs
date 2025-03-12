using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameover;
    public GameManager gameManager;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void EndGame()
    {
        isGameover = true;
    }
}
