using UnityEngine;
using System.Collections;

public class Audio1 : MonoBehaviour {

    // Use this for initialization
    AudioSource audio;
    int check = 0;
    void Start () {
         audio = GetComponent<AudioSource>();
        //audio.Play();
        Play();
    }
    
    // Update is called once per frame
    public void Play()
    {
        audio.Play();
    }
    public void Stop()
    {
        audio.Stop();
    }
	void Update () {
	
	}
}
