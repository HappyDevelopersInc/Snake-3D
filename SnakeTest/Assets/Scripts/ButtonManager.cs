using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
    public Text HighscoreText;
    public Button btnpause;
    bool pauseflag;
    void Start()
    {
        pauseflag = false;
        HighscoreText.text = "Highscore:" + PlayerPrefs.GetInt("Highscore");
    }
    public void DevModeClicked()
    {
        PlayerPrefs.SetInt("Totalscore",5500);
    }
    public void Clicked()
    {
        if (!pauseflag)
        {
            btnpause.GetComponentInChildren<Text>().text = "►";
            Time.timeScale = 0;
            pauseflag = true;
        }
        else
        {
            btnpause.GetComponentInChildren<Text>().text = " ▌▌";
            Time.timeScale = 1;
            pauseflag = false;
        }
    }
    public void NewGameBtn(string newGameLevel)
    {
        SceneManager.LoadSceneAsync(newGameLevel);
        

    }
  

   
    
    
    public void SettingsMenu(string SettingsScene)
    {
        SceneManager.LoadScene(SettingsScene);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
