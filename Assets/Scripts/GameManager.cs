using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject key1;
    public GameObject key2;
    public GameObject door1;
    public GameObject door2;
    public GameObject gameoverText;
    public GameObject recordTime;
    public GameObject gameclearText;
    public Text timeText;
    public Text BestRecord;

    private float surviveTime;
    private bool isGameover;
    private bool isGameclear;
    private bool doorOpen = false;
    
    void Start()
    {
        surviveTime = 0f;
        isGameover = false;
        isGameclear = false;
    }

    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Record Time: " + (int)surviveTime;
        }
        else if (isGameover || isGameclear)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

        if (doorOpen == true)
        {
            if (door1.transform.position.x < 8f)
            {
                door1.transform.Translate(10f * Time.deltaTime, 0, 0);
            }

            if (door2.transform.position.x > -8f)
            {
                door2.transform.Translate(-10f * Time.deltaTime, 0, 0);
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;
        recordTime.SetActive(false);
        gameoverText.SetActive(true);
    }

    public void LockOff()
    {
        doorOpen = true;
    }

    public void GameClear()
    {
        isGameclear = true;
        player.SetActive(false);

        recordTime.SetActive(false);
        gameclearText.SetActive(true);

        float bestScore = PlayerPrefs.GetFloat("BestScore");
        if (surviveTime < bestScore)
        {
            bestScore = surviveTime;
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }

        BestRecord.text = "Your Best Record\n" + (int)bestScore + " Sec";
    }
}
