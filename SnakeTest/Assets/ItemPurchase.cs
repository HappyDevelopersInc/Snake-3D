using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemPurchase : MonoBehaviour {
    
    GameObject[] obj;
    public GameObject[] StandardSkinNode;
    public GameObject[] RareSkinNode;
    public GameObject[] EpicSkinNode;
    public static string ItemName;
    public Text ItemNameTXT;
    public Text ItemDescription;
    public Text CreditNumber;
    public Text CostAmount;
    public Image ItemImage;
    public Sprite[] ItemSprite;
    public Texture Tex;
    public static Color color;
    public static Item item;
    public string hex;
    float R, G, B;
    public string tempgo;
    string texture;
    int live;
    public Text AnotherLives;
    public static Texture PassTexture;
    //------------------------GAMEOBJECTS----
    public GameObject StandardSkin;
    public GameObject RareSkin;
    public GameObject EpicSkin;
    public GameObject StandardSkins;
    public GameObject RareSkins;
    public GameObject EpicSkins;
    public GameObject Live;
    public GameObject BuyPanel;
    public GameObject AnotherLive;
    public GameObject Arrows;
    //------RareSkinTextures---------
    public Texture RareSkinTexture1;
    public Texture RareSkinTexture2;
    public Texture RareSkinTexture3;
    public Texture RareSkinTexture4;
    public Texture RareSkinTexture5;
    public Texture RareSkinTexture6;
    public Texture RareSkinTexture7;
    public Texture RareSkinTexture8;
    public Texture RareSkinTexture9;
    public Texture RareSkinTexture10;
    public Texture RareSkinTexture11;
    public Texture RareSkinTexture12;
    //-----EpicSkinTextures----------
    public Texture EpicSkinTexture;
    public Texture EpicSkinTexture1;
    public Texture EpicSkinTexture2;
    public Texture EpicSkinTexture3;
    public Texture EpicSkinTexture4;
    public Texture EpicSkinTexture5;
    public Texture EpicSkinTexture6;
    public Texture EpicSkinTexture7;
    public Texture EpicSkinTexture8;
    public Texture EpicSkinTexture9;
    public Texture EpicSkinTexture10;
    public Texture EpicSkinTexture11;
    public Texture EpicSkinTexture12;
    public Texture EpicSkinTexture13;
    public Texture EpicSkinTexture14;
    public Texture EpicSkinTexture15;
    public Texture EpicSkinTexture16;
    // Use this for initialization
    void Start () {
        //--------SnakeSkinActivity-----
        StandardSkin.SetActive(false);
        RareSkin.SetActive(false);
        EpicSkin.SetActive(false);
        //-------TextureActivity--------
        StandardSkins.SetActive(false);
        RareSkins.SetActive(false);
        EpicSkins.SetActive(false);
        //-------SnakeLiveActivity------
        Live.SetActive(false);
        AnotherLive.SetActive(false);
        BuyPanel.SetActive(false);
        Arrows.SetActive(true);
        hex = "1";
        PassTexture = SortTexture(PlayerPrefs.GetString("Texture"));
        tempgo = PlayerPrefs.GetString("checkcolor","");
        live = PlayerPrefs.GetInt("Live", 0);
      
         texture = PlayerPrefs.GetString("Texture", "");
        switch (ItemName)
        {
            case ("StandartSkin_15c"):
                {
                    obj = StandardSkinNode;
                    StandardSkins.SetActive(true);
                    StandardSkin.SetActive(true);
                    item = new Item(ItemName, 15);
                    ItemNameTXT.text = "Standtard Skin";
                    ItemImage.sprite = ItemSprite[0];
                    CostAmount.text = ""+item.GetItemWorthCredits();
                    ChangeColorOfObj(obj, ItemName);

                    break;
                }
            case ("RareSkin_25c"):
                {
                    obj = RareSkinNode;
                    RareSkins.SetActive(true);
                    RareSkin.SetActive(true);
                    item = new Item(ItemName, 25);
                    ItemNameTXT.text = "Rare Skin";
                    ItemImage.sprite = ItemSprite[1];
                    CostAmount.text = "" + item.GetItemWorthCredits();
                    ChangeColorOfObj(obj, ItemName);

                    break;
                }
            case ("EpicSkin_40c"):
                {
                    obj = EpicSkinNode;
                    EpicSkins.SetActive(true);
                    EpicSkin.SetActive(true);
                    item = new Item(ItemName, 40);
                    ItemNameTXT.text = "Epic Skin";
                    ItemImage.sprite = ItemSprite[2];
                    CostAmount.text = "" + item.GetItemWorthCredits();
                    ChangeColorOfObj(obj, ItemName);

                    break;
                }
            case ("Another_Live_10c"):
                {
                    AnotherLive.SetActive(true);
                    Live.SetActive(true);
                    
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
       
        
    }
    public void ClosePanel()
    {
        BuyPanel.SetActive(false);
        Arrows.SetActive(true);
    }
    void ChangeColorOfObj(GameObject[] obj,string itemname)
    {
      switch(itemname)
        {
            case ("StandartSkin_15c"):
                {
                    for (int i = 1; i < obj.Length; i++)
                    {
                        Renderer rend = obj[i].GetComponent<Renderer>();
                        //Initiates each object node in the snake a color
                        if (PlayerPrefs.GetString("Texture") == "")
                        {
                            R = PlayerPrefs.GetFloat("R");
                            G = PlayerPrefs.GetFloat("G");
                            B = PlayerPrefs.GetFloat("B");
                            rend.material.color = new Color(R, G, B);
                        }
                        else
                        {
                            rend.material.color = Color.white;
                            rend.material.mainTexture = SortTexture(PlayerPrefs.GetString("Texture"));
                        }
                    }
                    break;
                }
            case ("RareSkin_25c"):
                {
                    for (int i = 1; i < obj.Length; i++)
                    {
                        Renderer rend = obj[i].GetComponent<Renderer>();
                        //Initiates each object node in the snake a color
                        if (PlayerPrefs.GetString("Texture") == "")
                        {
                            R = PlayerPrefs.GetFloat("R");
                            G = PlayerPrefs.GetFloat("G");
                            B = PlayerPrefs.GetFloat("B");
                            rend.material.color = new Color(R, G, B);
                        }
                        else
                        {
                            rend.material.color = Color.white;
                            rend.material.mainTexture = SortTexture(PlayerPrefs.GetString("Texture"));
                        }
                    }
                    break;
                }
            case ("EpicSkin_40c"):
                {
                    for (int i = 1; i < obj.Length; i++)
                    {
                        Renderer rend = obj[i].GetComponent<Renderer>();
                        //Initiates each object node in the snake a color
                        if (PlayerPrefs.GetString("Texture") == "")
                        {
                            R = PlayerPrefs.GetFloat("R");
                            G = PlayerPrefs.GetFloat("G");
                            B = PlayerPrefs.GetFloat("B");
                            rend.material.color = new Color(R, G, B);
                        }
                        else
                        {
                            rend.material.color = Color.white;
                            rend.material.mainTexture = SortTexture(PlayerPrefs.GetString("Texture"));
                        }
                    }
                    break;
                }
        }
       

       
    }
  
    public static Texture GetTexture()
    {
        
        return PassTexture;
    }
    public Texture SortTexture(string TextureName)
    {
        switch (TextureName)
        {
            case ("RareSkinTexture1"):
                {
                    PassTexture = RareSkinTexture1;
                    return RareSkinTexture1;
                }
            case ("RareSkinTexture2"):
                {
                    PassTexture = RareSkinTexture2;
                    return RareSkinTexture2;
                }
            case ("RareSkinTexture3"):
                {
                    PassTexture = RareSkinTexture3;
                    return RareSkinTexture3;
                }
            case ("RareSkinTexture4"):
                {
                    PassTexture = RareSkinTexture4;
                    return RareSkinTexture4;
                }
            case ("RareSkinTexture5"):
                {
                    PassTexture = RareSkinTexture5;
                    return RareSkinTexture5;
                }
            case ("RareSkinTexture6"):
                {
                    PassTexture = RareSkinTexture6;
                    return RareSkinTexture6;
                }
            case ("RareSkinTexture7"):
                {
                    PassTexture = RareSkinTexture7;
                    return RareSkinTexture7;
                }
            case ("RareSkinTexture8"):
                {
                    PassTexture = RareSkinTexture8;
                    return RareSkinTexture8;
                }
            case ("RareSkinTexture9"):
                {
                    PassTexture = RareSkinTexture9;
                    return RareSkinTexture9;
                }
            case ("RareSkinTexture10"):
                {
                    PassTexture = RareSkinTexture10;
                    return RareSkinTexture10;
                }
            case ("RareSkinTexture11"):
                {
                    PassTexture = RareSkinTexture11;
                    return RareSkinTexture11;
                }
            case ("RareSkinTexture12"):
                {
                    PassTexture = RareSkinTexture12;
                    return RareSkinTexture12;
                }
            case ("EpicSkinTexture"):
                {
                    PassTexture = EpicSkinTexture;
                    return EpicSkinTexture;
                }
            case ("EpicSkinTexture1"):
                {
                    PassTexture = EpicSkinTexture1;
                    return EpicSkinTexture1;
                }
            case ("EpicSkinTexture2"):
                {
                    PassTexture = EpicSkinTexture2;
                    return EpicSkinTexture2;
                }
            case ("EpicSkinTexture3"):
                {
                    PassTexture = EpicSkinTexture3;
                    return EpicSkinTexture3;
                }
            case ("EpicSkinTexture4"):
                {
                    PassTexture = EpicSkinTexture4;
                    return EpicSkinTexture4;
                }
            case ("EpicSkinTexture5"):
                {
                    PassTexture = EpicSkinTexture5;
                    return EpicSkinTexture5;
                }
            case ("EpicSkinTexture6"):
                {
                    PassTexture = EpicSkinTexture6;
                    return EpicSkinTexture6;
                }
            case ("EpicSkinTexture7"):
                {
                    PassTexture = EpicSkinTexture7;
                    return EpicSkinTexture7;
                }
            case ("EpicSkinTexture8"):
                {
                    PassTexture = EpicSkinTexture8;
                    return EpicSkinTexture8;
                }
            case ("EpicSkinTexture9"):
                {
                    PassTexture = EpicSkinTexture9;
                    return EpicSkinTexture9;
                }
            case ("EpicSkinTexture10"):
                {
                    PassTexture = EpicSkinTexture10;
                    return EpicSkinTexture10;
                }
            case ("EpicSkinTexture11"):
                {
                    PassTexture = EpicSkinTexture11;
                    return EpicSkinTexture11;
                }
            case ("EpicSkinTexture12"):
                {
                    PassTexture = EpicSkinTexture12;
                    return EpicSkinTexture12;
                }
            case ("EpicSkinTexture13"):
                {
                    PassTexture = EpicSkinTexture13;
                    return EpicSkinTexture13;
                }
            case ("EpicSkinTexture14"):
                {
                    PassTexture = EpicSkinTexture14;
                    return EpicSkinTexture14;
                }
            case ("EpicSkinTexture15"):
                {
                    PassTexture = EpicSkinTexture15;
                    return EpicSkinTexture15;
                }
            case ("EpicSkinTexture16"):
                {
                    PassTexture = EpicSkinTexture16;
                    return EpicSkinTexture16;
                }

            default:return null;
        }
    }
    public string ToHex()//Converts Color Object(RGB) to Hex Value
    {
        Color color = new Color(R, G, B);
        Color32 c = color;
        var hex = string.Format("{0:X2}{1:X2}{2:X2}{3:X2}", c.r, c.g, c.b, c.a);
        return hex;
    }
    public void SetTexture(Texture tex)
    {
        
        string go = EventSystem.current.currentSelectedGameObject.name;
        if(go!=tempgo)
        {
            hex = "0";
            for (int i = 1; i < obj.Length; i++)
            {
                Renderer rend = obj[i].GetComponent<Renderer>();
                rend.material.color = Color.white;
                rend.material.mainTexture = tex;
                Tex = tex;
                //color = hexToColor(hexString);
            }

        }
        else { hex = "1"; }
        tempgo = go;
        PlayerPrefs.SetString("checkcolor", tempgo);
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
                rend.material.mainTexture = null;
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
        BuyPanel.SetActive(true);
        Arrows.SetActive(false);
        //if (ItemName == "StandartSkin_15c" || ItemName == "RareSkin_25c" || ItemName == "EpicSkin_40c")
        //{
        //    if (hex != "1")
        //    {
        //        item.Purchase(Tex);
        //        hex = "1";
        //    }
        //}
        //else if (ItemName == "Another_Live_10c")
        //{
        //    BuyPanel.SetActive(true);

        //    item.Purchase();
        //}

    }
    public void BuyItem()
    {
        if (ItemName == "StandartSkin_15c" || ItemName == "RareSkin_25c" || ItemName == "EpicSkin_40c")
        {
            if (hex != "1")
            {
                if (item.Purchase(Tex))
                    ClosePanel();
                hex = "1";
            }
        }
        else if (ItemName == "Another_Live_10c")
        {
            if (item.Purchase())
                ClosePanel();
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

        AnotherLives.text = "Another Lives :" + PlayerPrefs.GetInt("Live");
	}
}
