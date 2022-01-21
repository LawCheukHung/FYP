using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class EndGameUI : MonoBehaviour
{
    public GameObject gamingUI;
    public MainMission mainMission;
    public CollectGarbageMission collectGarbageMission;
    public Text endGameText;
    private float totalScore;
    private float mainMissionScore;
    private float sideMissionScore;
    private bool isEndGame = false;

    private void Update()
    {
        if (isEndGame)
        {
            gamingUI.SetActive(false);
            Time.timeScale = 0;
            endGameText.gameObject.SetActive(true);
            countTotalScore();

            if (Input.GetKey(KeyCode.Return))
            {
                showEndGameInfo();
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void showEndGameInfo()
    {
        endGameText.alignment = TextAnchor.MiddleLeft;

        endGameText.text = "Result:" + "\n\n"
            + "Teaching Progress: " + (int)mainMissionScore + "\n"
            + "+ Total Collected Garbage: " + (int)sideMissionScore + "\n"
            + "______________________________" + "\n"
            + "Total Score: " + (int)totalScore;
    }

    private void countTotalScore()
    {
        mainMissionScore = mainMission.getTeachingProgress();
        sideMissionScore = collectGarbageMission.getTotalCollectGarbage();
        totalScore = mainMissionScore + sideMissionScore;
    }

    public void setIsEndGame()
    {
        isEndGame = true;
    }
}
