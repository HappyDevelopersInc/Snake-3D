using UnityEngine;
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
    public bool Purchase(Texture Tex =null)
    {
        switch (this.ItemName)
        {
            case ("StandartSkin_15c"):
                {
                    return BuySkin(15, this.ItemName);
                    
                }
            case ("RareSkin_25c"):
                {
                    return BuySkin(25, this.ItemName,Tex);
                    
                }
            case ("EpicSkin_40c"):
                {
                    return BuySkin(40, this.ItemName,Tex);
                    
                }
            case ("Another_Live_10c"):
                {
                    return BuyLive(10, this.ItemName);
                    
                }
        }
        return false;
    }
    public bool BuyLive(int CreditAmount,string ItemName)
    {
        if(PlayerPrefs.GetInt("Live")>=3)
        {
            Debug.Log("Youv'e reached the maximum amount of lives!");
            return false;
        }
        else
        {
            CreditBalance = PlayerPrefs.GetInt("Credits", 0);
            int _CreditsAmount = CreditAmount;
            if(CreditBalance>=CreditAmount)
            {
                PlayerPrefs.SetInt("Live", PlayerPrefs.GetInt("Live") + 1);
                PlayerPrefs.SetInt("Credits", CreditBalance - _CreditsAmount);
                return true;
              
            }
            else
            {
                Debug.Log("You do not have enough money to buy "+ItemName);
                return false;
            }
        }
        
    }
    public bool BuySkin(int CreditsAmount,string ItemName,Texture Tex=null)
    {
        CreditBalance = PlayerPrefs.GetInt("Credits", 0);
        
        if (CreditBalance>= CreditsAmount)
        {

            switch(ItemName)
            {
                case ("StandartSkin_15c"):
                    {
                        PlayerPrefs.SetString("SnakeSkin", ItemName);
                        PlayerPrefs.SetInt("Credits", (CreditBalance - CreditsAmount));
                        PlayerPrefs.SetString("Texture", "");
                        PlayerPrefs.SetFloat("R", ItemPurchase.color.r);
                        PlayerPrefs.SetFloat("G", ItemPurchase.color.g);
                        PlayerPrefs.SetFloat("B", ItemPurchase.color.b);
                        return true;
                    }
                case ("RareSkin_25c"):
                    {
                        PlayerPrefs.SetString("SnakeSkin", ItemName);
                        PlayerPrefs.SetInt("Credits", (CreditBalance - CreditsAmount));
                        PlayerPrefs.SetString("Texture", Tex.name);
                        return true;
                    }
                case ("EpicSkin_40c"):
                    {
                        PlayerPrefs.SetString("SnakeSkin", ItemName);
                        PlayerPrefs.SetInt("Credits", (CreditBalance - CreditsAmount));
                        PlayerPrefs.SetString("Texture", Tex.name);
                        return true;
                       
                    }

            }
            

        }
        else
        {
            Debug.Log("You don't have enougth money to buy " + ItemName);
            return false;
        }
        return true;
        
    
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
