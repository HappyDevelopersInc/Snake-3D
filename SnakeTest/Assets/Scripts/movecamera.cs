using UnityEngine;
using System.Collections;

public class movecamera : MonoBehaviour {

    // Use this for initialization
    public Canvas myCanvas;
    void Start() {
        transform.position = Input.mousePosition;
    }
	// Update is called once per frame
	void Update () {
            
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
            transform.position = myCanvas.transform.TransformPoint(pos);
        }

    }

