using UnityEngine;
using System.Collections;

public class ObjectRotation : MonoBehaviour {

	// Use this for initialization

    float rotSpeed = 20f;
    public float speed = 5f;
    public Transform newobject;
    
    void FixedUpdate()
    {
    
        
       

            newobject.Rotate(Vector3.up, speed * Time.deltaTime);
      
    }
    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        newobject.RotateAround(Vector3.up, -rotX);
        //transform.RotateAround(Vector3.right, rotY);
    }
}
