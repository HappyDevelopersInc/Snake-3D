using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemPurchase : MonoBehaviour {
    
    public GameObject[] obj;
    public static string ItemName;
    public Text ItemNameTXT;
    public Text ItemDescription;
    public Text CreditNumber;
    public Text CostAmount;
    public Image ItemImage;
    public Sprite[] ItemSprite;
    public static Color color;
    public Item item;
    public string hex;
    float R, G, B;
    public string tempgo;
    //------------------------GAMEOBJECTS----
    public GameObject StandardSkin;
    
    
	// Use this for initialization
	void Start () {
        StandardSkin.SetActive(false);
        hex = "1";
        tempgo = PlayerPrefs.GetString("checkcolor","");
        switch(ItemName)
        {
            case ("StandartSkin_15c"):
                {
                    StandardSkin.SetActive(true);
                    item = new Item(ItemName, 15);
                    ItemNameTXT.text = "Standtard Skin";
                    ItemImage.sprite = ItemSprite[0];
                    CostAmount.text = ""+item.GetItemWorthCredits();
                    break;
                }
            case ("RareSkin_25c"):
                {
                    item = new Item(ItemName, 25);
                    ItemNameTXT.text = "Rare Skin";
                    ItemImage.sprite = ItemSprite[1];
                    CostAmount.text = "" + item.GetItemWorthCredits();
                    break;
                }
            case ("EpicSkin_40c"):
                {
                    item = new Item(ItemName, 40);
                    ItemNameTXT.text = "Epic Skin";
                    ItemImage.sprite = ItemSprite[2];
                    CostAmount.text = "" + item.GetItemWorthCredits();
                    break;
                }
            case ("Another_Live_10c"):
                {
                    item = new Item(ItemName, 10);
                    ItemNameTXT.text = "Another Live";
                    ItemImage.sprite = ItemSprite[3];
                    CostAmount.text = "" + item.GetItemWorthCredits();
                    break;
                }
            case ("Small_Creature_15c"):
                {
                    item = new Item(ItemName, 15);
                    ItemNameTXT.text = "Small Creature";
                    ItemImage.sprite = ItemSprite[4];
                    CostAmount.text = "" + item.GetItemWorthCredits();
                    break;
                }
            case ("2Apples_OneSwallow_15c"):
                {
                    item = new Item(ItemName, 15);
                    ItemNameTXT.text = "2 Apples One Swallow";
                    ItemImage.sprite = ItemSprite[5];
                    ItemNameTXT.fontSize = 20;
                    CostAmount.text = "" + item.GetItemWorthCredits();
                    break;
                }
            case ("Purchase_Credits"):
                {
                    item = new Item(ItemName);
                    ItemNameTXT.text = "Purchase Credits";
                    ItemImage.sprite = ItemSprite[6];
                    CostAmount.text = "" + item.GetItemWorthCredits();
                    break;
                }
           
        }
        ChangeColorOfObj(obj);
        
    }
    void ChangeColorOfObj(GameObject[] obj)
    {
      
        for (int i = 1; i < obj.Length; i++)
        {
            Renderer rend = obj[i].GetComponent<Renderer>();
            //Initiates each object node in the snake a color
            R = PlayerPrefs.GetFloat("R");
            G = PlayerPrefs.GetFloat("G");
            B = PlayerPrefs.GetFloat("B");
            rend.material.color = new Color(R,G,B);
        }

       
    }
    public string ToHex()//Converts Color Object(RGB) to Hex Value
    {
        Color color = new Color(R, G, B);
        Color32 c = color;
        var hex = string.Format("{0:X2}{1:X2}{2:X2}{3:X2}", c.r, c.g, c.b, c.a);
        return hex;
    }
    public void getRGB(string hexString=" ")//Converts Hex Value to Color Object
    {
        string go = EventSystem.current.currentSelectedGameObject.name;
        
        if (hexString != " "&& go!=tempgo)
        {
            hex = "0";
            for (int i = 1; i < obj.Length; i++)
            {
                Renderer rend = obj[i].GetComponent<Renderer>();
                rend.material.color = hexToColor(hexString);
                color = hexToColor(hexString);

            }
        }
        else { hex = "1"; }
        tempgo = go;
        PlayerPrefs.SetString("checkcolor", tempgo);
    }
   
    public void pressedbuy()
    {
        if (hex != "1")
        {
            item.Purchase();
            hex = "1";
        }
    }
    public static Color hexToColor(string hex)
    {
        hex = hex.Replace("0x", "");//in case the string is formatted 0xFFFFFF
        hex = hex.Replace("#", "");//in case the string is formatted #FFFFFF
        byte a = 255;//assume fully visible unless specified in hex
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        //Only use alpha if the string has enough characters
        if (hex.Length == 8)
        {
            a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
        }
        return new Color32(r, g, b, a);
    }
    //public void picker (Color c)
    //{
    //    //do somthing
    //    for (int i = 1; i < obj.Length; i++)
    //    {
    //        Renderer rend = obj[i].GetComponent<Renderer>();
    //        rend.material.color = c;
    //        color = c;

    //    }
    //}

    // Update is called once per frame
    void Update () {
        CreditNumber.text =""+ PlayerPrefs.GetInt("Credits");
	}
}
