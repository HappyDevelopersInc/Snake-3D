﻿using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    // Use this for initialization
    string ItemName;
    int ItemWorthCredits;
    public static int CreditBalance;
	void Start () {
        
        
    }
    public Item (string _ItemName,int _ItemWorthCredits =0)
    {
        
        this.ItemName = _ItemName;
        this.ItemWorthCredits = _ItemWorthCredits;
    }
	public void Purchase()
    {
        switch (this.ItemName)
        {
            case ("StandartSkin_15c"):
                {
                     BuySkin(15);
                    break;
                }
        }
    }

    void BuySkin(int CreditsAmount)
    {
        CreditBalance = PlayerPrefs.GetInt("Credits", 0);
        PlayerPrefs.SetInt("Credits", (CreditBalance - CreditsAmount));
        PlayerPrefs.SetFloat("R", ItemPurchase.color.r);
        PlayerPrefs.SetFloat("G", ItemPurchase.color.g);
        PlayerPrefs.SetFloat("B", ItemPurchase.color.b);
    }
    //Gets
    public string GetItemName()
    {
        return this.ItemName;
    }
    public int GetItemWorthCredits()
    {
        return this.ItemWorthCredits;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
