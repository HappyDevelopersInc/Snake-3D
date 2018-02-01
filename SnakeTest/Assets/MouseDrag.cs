using UnityEngine;
using System.Collections;

public class MouseDrag : MonoBehaviour {
    float distance = 10;

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, 0, 0);
        Vector3 objposition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objposition;
    }

}
