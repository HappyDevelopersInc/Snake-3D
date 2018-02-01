using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class leaderboard : MonoBehaviour {
    public Text LeaderBoardText;
    public Text CurrentScoreText;
    public Text HighScoreText;
    public Text Newhighscore;
    public Text GameOverText;
    public Text AchivmetsUnlockedText;
    private static int score;
    public Text infotext;
    float speed = 2.0f;
    float timer;
    public static float tomp;
    public static int cc = 0;
    public static Slider slider;
    string temparr;

    public Text AchivmentListText;
    
    // Use this for initialization
    void Start () {

        //---------------LEADER BOARD------------
        LeaderBoardText.enabled = false;
        HighScoreText.enabled = false;
        CurrentScoreText.enabled = false;
        Newhighscore.enabled = false;
        AchivmetsUnlockedText.enabled = false;
        AchivmentListText.enabled = false;
        //string[] arr = PlayerController.AchivmentsUnlocked;

        //------------LEADER BOARD---------------

        score = PlayerController.Score;
        showachivmentslist();
       // PlayerPrefs.SetInt("Totalscore", PlayerPrefs.GetInt("Totalscore") + score);
    }
    void showachivmentslist()
    {
        if (PlayerController.AchivmentsUnlocked.Count > 0)
        {
            AchivmetsUnlockedText.enabled = true;
            AchivmentListText.enabled = true;

            foreach (string arr in PlayerController.AchivmentsUnlocked)
            {
                temparr += arr + "\n";
                //AchivmentListText.text = "Unlocked :" + arr + "\n";

            }



        }
        AchivmentListText.text = temparr;
    }
    void ShowLeaderBoard()
    {
       
        HighScoreText.text = "Highscore : " + PlayerPrefs.GetInt("Highscore");
        CurrentScoreText.text = "Your Score : " + score;
        LeaderBoardText.enabled = true;
        HighScoreText.enabled = true;
        CurrentScoreText.enabled = true;
        GameOverText.text = "<GAME OVER>";
        if (PlayerPrefs.GetInt("Highscore") < score)
        {
            PlayerPrefs.SetInt("Highscore", score);
            Newhighscore.enabled = true;
            Newhighscore.text = "NEW HIGH SCORE!";
        }

    }
    // Update is called once per frame
    void Update () {
        ShowLeaderBoard();
        timer += Time.deltaTime;
        if(timer>=0.5)
        {
            infotext.enabled = true;
        }
        if(timer>= 1)
        {
            infotext.enabled = false;
            timer = 0;
        }
        if (Input.touchCount>0 || Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("Levels_Scene");
        }
	
	}
}
