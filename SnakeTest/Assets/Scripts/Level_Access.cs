using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class Level_Access : MonoBehaviour {
    
    public Button buttonlvl2;
    public Sprite locktexture;
    public Button buttonlvl3;
    public Button buttonlvl4;
    public Button buttonlvl5;
    public Button buttonlvl6;
    public Button buttonlvl7;
    public Button buttonlvl8;
    public Button buttonlvl9;
    public Button buttonlvl10;
    public Button buttonDevMode;
    int Rank = 0;
    public Sprite OtherSprite;
    Image imagelvl2;
    Image imagelvl3;
    Image imagelvl4;
    Image imagelvl5;
    Image imagelvl6;
    Image imagelvl7;
    Image imagelvl8;
    Image imagelvl9;
    Image imagelvl10;
    // Use this for initialization
    void Start () {
        imagelvl10 = buttonlvl10.GetComponent<Image>();
        imagelvl9 = buttonlvl9.GetComponent<Image>();
        imagelvl8 = buttonlvl8.GetComponent<Image>();
        imagelvl7 = buttonlvl7.GetComponent<Image>();
        imagelvl6 = buttonlvl6.GetComponent<Image>();
        imagelvl5 = buttonlvl5.GetComponent<Image>();
        imagelvl4 = buttonlvl4.GetComponent<Image>();
        imagelvl3 = buttonlvl3.GetComponent<Image>();
        imagelvl2 = buttonlvl2.GetComponent<Image>();
        buttonlvl2.interactable = false;
        buttonlvl3.interactable = false;
        buttonlvl4.interactable = false;
        buttonlvl5.interactable = false;
        buttonlvl6.interactable = false;
        buttonlvl7.interactable = false;
        buttonlvl8.interactable = false;
        buttonlvl9.interactable = false;
        buttonlvl10.interactable = false;
        Debug.Log(PlayerPrefs.GetInt("highscorenew"));
    }
    

    // Update is called once per frame
    void Update() {
        if (PlayerPrefs.GetInt("Totalscore") >= 100)
        {
            buttonlvl2.interactable = true;
            imagelvl2.sprite = OtherSprite;
        }
        if (PlayerPrefs.GetInt("Totalscore") >= 350)
        {
            buttonlvl3.interactable = true;
            imagelvl3.sprite = OtherSprite;
        }
        if (PlayerPrefs.GetInt("Totalscore") >= 700)
        {
            buttonlvl4.interactable = true;
            imagelvl4.sprite = OtherSprite;
        }
        if (PlayerPrefs.GetInt("Totalscore") >= 1200)
        {
            buttonlvl5.interactable = true;
            imagelvl5.sprite = OtherSprite;
        }
        if (PlayerPrefs.GetInt("Totalscore") >= 1750)
        {
            buttonlvl6.interactable = true;
            imagelvl6.sprite = OtherSprite;
        }
        if (PlayerPrefs.GetInt("Totalscore") >= 2350)
        {
            buttonlvl7.interactable = true;
            imagelvl7.sprite = OtherSprite;
        }
        if (PlayerPrefs.GetInt("Totalscore") >= 3000)
        {
            buttonlvl8.interactable = true;
            imagelvl8.sprite = OtherSprite;
        }
        if (PlayerPrefs.GetInt("Totalscore") >= 4000)
        {
            buttonlvl9.interactable = true;
            imagelvl9.sprite = OtherSprite;
        }
        if (PlayerPrefs.GetInt("Totalscore") >= 5500)
        {
            buttonlvl10.interactable = true;
            imagelvl10.sprite = OtherSprite;
        }
        





    }
        
    
    }

