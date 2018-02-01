using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class backgroundmusic : MonoBehaviour {
    
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
}
