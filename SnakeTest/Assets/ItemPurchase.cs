using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemPurchase : MonoBehaviour {

    public GameObject[] obj;
    public static string ItemName;
    public Text ItemNameTXT;
    public Text ItemDescription;
    public Image ItemImage;
    public Sprite[] ItemSprite;
   
	// Use this for initialization
	void Start () {
        
        switch(ItemName)
        {
            case ("StandartSkin_15c"):
                {
                    ItemNameTXT.text = "Standtard Skin";
                    ItemImage.sprite = ItemSprite[0];
                    break;
                }
            case ("RareSkin_25c"):
                {
                    ItemNameTXT.text = "Rare Skin";
                    ItemImage.sprite = ItemSprite[1];
                    break;
                }
            case ("EpicSkin_40c"):
                {
                    ItemNameTXT.text = "Epic Skin";
                    ItemImage.sprite = ItemSprite[2];
                    break;
                }
            case ("Another_Live_10c"):
                {
                    ItemNameTXT.text = "Another Live";
                    ItemImage.sprite = ItemSprite[3];
                    break;
                }
            case ("Small_Creature_15c"):
                {
                    ItemNameTXT.text = "Small Creature";
                    ItemImage.sprite = ItemSprite[4];
                    break;
                }
            case ("2Apples_OneSwallow_15c"):
                {
                    ItemNameTXT.text = "2 Apples One Swallow";
                    ItemImage.sprite = ItemSprite[5];
                    ItemNameTXT.fontSize = 20;
                    break;
                }
            case ("Purchase_Credits"):
                {
                    ItemNameTXT.text = "Purchase Credits";
                    ItemImage.sprite = ItemSprite[6];
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
            rend.material.color = Color.red;
        }
    }
    public void omefunction (Color c)
    {
        //do somthing
        for (int i = 1; i < obj.Length; i++)
        {
            Renderer rend = obj[i].GetComponent<Renderer>();
            rend.material.color =c;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
