using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GetButtonName : MonoBehaviour {

    public void OnButtonClick()
    {
        var go = EventSystem.current.currentSelectedGameObject;
        if (go != null)
            Debug.Log("Clicked on : " + go.name);
        else
            Debug.Log("currentSelectedGameObject is null");
    }
}
