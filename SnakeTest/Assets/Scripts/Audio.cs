using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Audio : MonoBehaviour {

    // Use this for initialization
    public AudioSource audio;
    private static Audio instance = null;
    int check = 0;
    public bool ButtonOn = true;
    public Button MyButton;
    public static bool mute;
  
    public static Audio Instance
    {
        get { return instance; }
    }
    void Start () {
         audio = GetComponent<AudioSource>();
        mute = true;
        audio.Play();
        audio.Pause();
        MyButton.image.color = Color.red;
       
    }

   
    public void BeenClicked()
    {
        ButtonOn = !ButtonOn;
        if (ButtonOn)
        {
            mute = false;
            MyButton.image.color = Color.green;
        }
        else
        {
            mute = true;
            MyButton.image.color = Color.red;
        }
    }

    // Update is called once per frame
    public void Play()
    {
        audio.Play();
    }
    public void Stop()
    {
        if (check == 0)
        {
            audio.Pause();
            check = 1;
        }
        else
        {
            audio.UnPause();
            check = 0;
        }
    }
	void Update () {
        

        
    }
}
