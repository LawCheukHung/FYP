using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject gamingUI;
    public MainMission mainMission;
    public SideMission sideMission;
    public Image endGameImage;
    public Text endGameText;
    private bool isEndGame = false;
    private float totalScore = 0;
    private float mainMissionScore = 0;
    private float sideMissionScore = 0;
    private float sideMissionMultiply = 5;

    void Update()
    {
        if (isEndGame)
        {
            gamingUI.SetActive(false);
            Time.timeScale = 0;
            countTotalScore();
            endGameImage.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                showEndGameInfo();
            }
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
        sideMissionScore = sideMission.getTotalCollectGarbage();
        totalScore = mainMissionScore + sideMissionScore * sideMissionMultiply;
    }

    public void setIsEndGame()
    {
        isEndGame = true;
    }
}
