using UnityEngine;
using System.Collections;

public class ObjectRotation : MonoBehaviour {

	// Use this for initialization

    float rotSpeed = 20f;
    public float speed = 5f;
    public Transform newobject;
    
    void FixedUpdate()
    {



        //newobject.Rotate(new Vector3(0, 1, speed * Time.deltaTime) );
        //newobject.Rotate(Vector3.up, speed * Time.deltaTime,Space.Self);
        //newobject.RotateAround(newobject.position, newobject.up, speed * Time.deltaTime );
        transform.Rotate(0, speed * Time.deltaTime, 0, Space.Self);
        //newobject.RotateAround(newobject.position, Vector3.up, Time.deltaTime * 90f);

    }
    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        newobject.RotateAround(Vector3.up, -rotX);
        //transform.RotateAround(Vector3.right, rotY);
    }
}
