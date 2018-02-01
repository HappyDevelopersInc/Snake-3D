﻿using UnityEngine;
using System.Collections;

public class FadeScene : MonoBehaviour {

    public Texture2D fadeOutTexture; // the texture that will overlay the screen. This can be a black image or loading graphics
    public float fadeSpeed = 0.8f;  //the faading speed
    private int drawDepth = -1000; //the texture's order in the draw hierarchy: a low number means it renders on top
    private float alpha = 1.0f; //the texture's alpha value between 0 and 1
    private int fadeDir = -1; // the direction to fade : in = -1 or out = 1

    void OnGUI()
    {
        //fade out/in the alpha calue using a direction , a speed and Time.deltatime to convert the operation to seonds
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        //force (clamp) the number between 0 and 1 becouse  GUI.color uses alpha values between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        //set the color of our GUI(int this case our texture) All color values remain the same & the alpha is set to the alpha variable
        GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,alpha); //set the alpha value
        GUI.depth = drawDepth; //make the black texture render on top(drawn last)
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture); // draw the texture to fit the entire screen area


    }


    // sets the fadedir to the diraction parameter making the scene fade in if -1 and out if 1
    public float BeginFade(int direction)
    {
        fadeDir = direction;

        return (fadeSpeed); // return the fadespeed variable so it's easy to time the appliction.loadlevel();


    }
    //onlevelwasloaded is called when a level is loaded.it takes loaded level index (int) as parameter so you can limit the fade in to certain scenes
    void OnLevelWasLoaded()
    {
        //alpha =1;        //use this if the alpha is not set to 1 by default;
        BeginFade(-1); //call the fade in function
    }


}
