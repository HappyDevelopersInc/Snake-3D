using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Text;
using System;
using UnityEngine.SceneManagement;
public class savesliderloc : MonoBehaviour {
    public Slider slider;
    public GameObject obj;
    // Use this for initialization
    void Start () {
        PlayerController.save = PlayerPrefs.GetInt("saveloc");
        savepostionslider();
        Destroy(obj);
	}
    public void savepostionslider()
    {
        slider.value = PlayerPrefs.GetInt("saveloc");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
