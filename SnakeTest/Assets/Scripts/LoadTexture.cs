using UnityEngine;
using System.Collections;

public class LoadTexture : MonoBehaviour {
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
    public static Texture PassTexture;
    // Use this for initialization
    void Start () {
        SortTexture(PlayerPrefs.GetString("Texture"));
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

            default: return null;
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
