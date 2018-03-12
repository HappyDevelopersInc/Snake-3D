using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Text;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ClickObk : MonoBehaviour {
    int check = 1;
    public bool ButtonOn = true;
    public static bool mute;
    public AudioSource audio;
    

    void Awake()
    {
        
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        
    }
    void Start()
    {
        
        audio = GetComponent<AudioSource>();
        //audio.Pause();
        OnMouseDown();
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        mute = false;
    }
    public void OnMouseDown()
    {
        Stop();
        ButtonOn = !ButtonOn;
        if (ButtonOn)
        {
            mute = true;
            Renderer rend = gameObject.GetComponent<Renderer>();
            rend.material.color = Color.red;
        }
        else
        {
            mute = false;
            Renderer rend = gameObject.GetComponent<Renderer>();
            rend.material.color = Color.green;
        }
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
}
