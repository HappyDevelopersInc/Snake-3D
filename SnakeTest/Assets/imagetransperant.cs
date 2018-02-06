using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class imagetransperant : MonoBehaviour {

    public float alphaLevel = 1f;
    // Use this for initialization
    void Start () {
        GetComponent<Image>().color = new Color(1, 1, 1, alphaLevel);

    }


	
	// Update is called once per frame
	void Update () {
	
	}
}

