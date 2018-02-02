using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputName : MonoBehaviour {

    public InputField nameinput;
    public Text AlertMessage;
   
    //-------------------------
   
    // Use this for initialization

    void LockInput(InputField input)
    {
        
        if (input.text.Length > 2)
        {
            AlertMessage.enabled = false;
            PlayerPrefs.SetString("NameOfSnake", input.text);
            PlayerPrefs.SetInt("FirstTime", 1);
            Debug.Log("Text has been entered");
            SceneManager.LoadSceneAsync("MenuScene");
        }
        else if (input.text.Length < 3)
        {
            AlertMessage.enabled = true;
            Debug.Log("Main Input Empty");
        }
    }
    void Start () {
       
        if (PlayerPrefs.GetInt("FirstTime",0) == 0)
        {
            AlertMessage.enabled = false;

            //Adds a listener that invokes the "LockInput" method when the player finishes editing the main input field.
            //Passes the main input field into the method when "LockInput" is invoked
            nameinput.onEndEdit.AddListener(delegate { LockInput(nameinput); });
        }
        else
        {
            SceneManager.LoadSceneAsync("MenuScene");
            PlayerPrefs.SetInt("FirstTime", 1);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
