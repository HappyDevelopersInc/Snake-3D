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
    public GameObject PowerPanel;
    public Text AmountSmallCreature;
    public Text Amount2ApplesOneSwallow;
    public string LEVELNAME;
    void Start()
    {
        
        PowerPanel.SetActive(false);
        pauseflag = false;
        
       
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
    public void SetPowerPanel()
    {
        AmountSmallCreature.text = "Amount :" + PlayerPrefs.GetInt("SmallCreature");
        Amount2ApplesOneSwallow.text = "Amount :" + PlayerPrefs.GetInt("2ApplesOneSwallow");
        PowerPanel.SetActive(true);
        var go = EventSystem.current.currentSelectedGameObject;
        string LevelName = go.name;
        Debug.Log(LevelName);
        LEVELNAME = LevelName;

    }
    public void SelectPower(string LevelName)
    {

        
        var go = EventSystem.current.currentSelectedGameObject;
        string ItemName = go.name;
        
        switch (ItemName)
        {
            case ("SmallCreature"):
                {
                    if (PlayerPrefs.GetInt("SmallCreature") > 0)
                    {
                        PlayerPrefs.SetInt("SmallCreature", PlayerPrefs.GetInt("SmallCreature") - 1);
                        PlayerController.SetSize(0.65f);
                        SceneManager.LoadSceneAsync(LEVELNAME);
                        Debug.Log(ItemName);
                    }
                    else
                        Debug.Log("You Dont Have any " + ItemName);
                    break;
                }
            case ("2applesOneSwallow"):
                {

                    Debug.Log(ItemName);
                    if (PlayerPrefs.GetInt("2ApplesOneSwallow") > 0)
                    {
                        PlayerController.SetScore2times();
                        PlayerController.SetSize();
                        PlayerPrefs.SetInt("2ApplesOneSwallow", PlayerPrefs.GetInt("2ApplesOneSwallow") - 1);
                        SceneManager.LoadSceneAsync(LEVELNAME);
                        Debug.Log(ItemName);
                    }
                    else
                        Debug.Log("You Dont Have any " + ItemName);
                    break;
                }
            case ("NoThanks"):
                {
                    PlayerController.SetSize();
                    SceneManager.LoadSceneAsync(LEVELNAME);
                    break;
                }
        }
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
