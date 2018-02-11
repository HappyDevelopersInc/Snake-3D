using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


class BodyPart 
    {
    
    private byte Mask;
    private GameObject be;
    private Vector3 temp;
    private float MaskStabCounter;
    


    public BodyPart(float x,float y,GameObject BE,float counter)
    {
        be = BE;
        this.SetXY(x, y);
        Mask = 3;

        MaskStabCounter = counter;
    
}
    public BodyPart(GameObject BE)
    {
        be = BE;
    }
    public void Rotate()
    {
        be.transform.RotateAround(Vector3.down, 90f);
    }
    public BodyPart(float counter)
    {
        
        Mask = 3;
        MaskStabCounter = counter;
    }
    //**************Sets****************
    public void SetXY(float x,float y)
    {
        temp = new Vector3(x, 0, y);
        be.transform.position = temp;
        
    }
    public void SetX(float x)
    {
        temp = new Vector3(x, 0, be.transform.position.z);
        be.transform.position = temp;
    }
    public void SetY(float y)
    {
        temp = new Vector3(be.transform.position.x, 0, y);
        be.transform.position = temp;
    }
    public void SetMask(byte mask)
    {
        this.Mask = mask;
    }
    public void SetCounter(float counter)
    {
        this.MaskStabCounter = counter;
    }
    public void SetVector3(Vector3 position)
    {
        be.transform.position = position;
        
    }
    //************Gets*****************
    public float GetX()
    {
        return be.transform.position.x;
    }
    public Vector3 GetSize()
    {
        return be.transform.localScale;
    }
    public float GetY()
    {
        return be.transform.position.z;
    }
    public GameObject GetObj()
    {
        return be;
    }
    public Vector3 GetVector3()
    {
        return be.transform.position;
    }
    public byte GetMask()
    {
        return Mask;
    }
    public float GetCounter()
    {
        return MaskStabCounter;
    }
}


