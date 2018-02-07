using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour {
    public Text HighscoreText;
    public Button btnpause;
    bool pauseflag;
    public Text SnakeName;
    void Start()
    {
        pauseflag = false;
        HighscoreText.text = "Highscore:" + PlayerPrefs.GetInt("Highscore");
        SnakeName.text = PlayerPrefs.GetString("NameOfSnake") + " The Snake";
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
    public void OnButtonClick(string newGameLevel)
    {
        var go = EventSystem.current.currentSelectedGameObject;
        if (go != null)
        {
            Debug.Log("Clicked on : " + go.name);
            ItemPurchase.ItemName = go.name;
        }
        else
            Debug.Log("currentSelectedGameObject is null");
        SceneManager.LoadSceneAsync(newGameLevel);
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
