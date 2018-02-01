using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Achivment_Access : MonoBehaviour {
    //public Button FirstBeginning;
    //public Button TheRightDirection;
    //public Button WelcomeToTheClub;
    //public Button LikeAPro;
    //public Button ThePowerIsWithYou;
    //public Button TheMajorLeage;
    //public Button Master;
    //public Button TheNextLevel;
    //public Button SuccessIsOnTheWay;
    //public Button ChampionOfTheYear;
    //public Button TheGodOfSnakes;
    public Button[] AchivmentsBtns;
    public Sprite[] AchivmentsSprites;
    //-------------Textures(Achived)
    //public Sprite FirstBeginningtexture;
    //public Sprite TheRightDirectiontexture;
    //public Sprite WelcomeToTheClubtexture;
    //public Sprite LikeAProtexture;
    //public Sprite ThePowerIsWithYoutexture;
    //public Sprite TheMajorLeagetexture;
    //public Sprite Mastertexture;
    //public Sprite TheNextLeveltexture;
    //public Sprite SuccessIsOnTheWaytexture;
    //public Sprite ChampionOfTheYeartexture;
    //public Sprite TheGodOfSnakestexture;
    //---------Images--------------
    Image FirstBeginningimg;
    Image TheRightDirectionimg;
    Image WelcomeToTheClubimg;
    Image LikeAProimg;
    Image ThePowerIsWithYouimg;
    Image TheMajorLeageimg;
    Image Masterimg;
    Image TheNextLevelimg;
    Image SuccessIsOnTheWayimg;
    Image ChampionOfTheYearimg;
    Image TheGodOfSnakesimg;
   
    // Use this for initialization
    void Start () {
        //AchivmentsBtns = new Button[11];
        //FirstBeginningimg = FirstBeginning.GetComponent<Image>();
        //TheRightDirectionimg = TheRightDirection.GetComponent<Image>();
        //WelcomeToTheClubimg = WelcomeToTheClub.GetComponent<Image>();
        //LikeAProimg = LikeAPro.GetComponent<Image>();
        //ThePowerIsWithYouimg = ThePowerIsWithYou.GetComponent<Image>();
        //TheMajorLeageimg = TheMajorLeage.GetComponent<Image>();
        //Masterimg = Master.GetComponent<Image>();
        //TheNextLevelimg = TheNextLevel.GetComponent<Image>();
        //SuccessIsOnTheWayimg = SuccessIsOnTheWay.GetComponent<Image>();
        //ChampionOfTheYearimg = ChampionOfTheYear.GetComponent<Image>();
        //TheGodOfSnakesimg = TheGodOfSnakes.GetComponent<Image>();
        //------------------------------------------------------------
        FirstBeginningimg = AchivmentsBtns[0].GetComponent<Image>();
        TheRightDirectionimg = AchivmentsBtns[1].GetComponent<Image>();
        WelcomeToTheClubimg = AchivmentsBtns[2].GetComponent<Image>();
        LikeAProimg = AchivmentsBtns[3].GetComponent<Image>();
        ThePowerIsWithYouimg = AchivmentsBtns[4].GetComponent<Image>();
        TheMajorLeageimg = AchivmentsBtns[5].GetComponent<Image>();
        Masterimg = AchivmentsBtns[6].GetComponent<Image>();
        TheNextLevelimg = AchivmentsBtns[7].GetComponent<Image>();
        SuccessIsOnTheWayimg = AchivmentsBtns[8].GetComponent<Image>();
        ChampionOfTheYearimg = AchivmentsBtns[9].GetComponent<Image>();
        TheGodOfSnakesimg = AchivmentsBtns[10].GetComponent<Image>();
        for (int i = 0; i < AchivmentsBtns.Length; i++)
        {
            if (PlayerController.achivmentscores[i].GetIsAchived() == 1)
            {
                AchivmentsBtns[i].GetComponent<Button>().interactable = true;
                AchivmentsBtns[i].GetComponent < Image >().sprite = AchivmentsSprites[i];
            }
            

        }
        Debug.Log("hello world");
        //---------------------------------------------------------

        //AchivmentsBtns[0] = FirstBeginning;
        //AchivmentsBtns[1] = TheRightDirection;
        //AchivmentsBtns[2] = WelcomeToTheClub;
        //AchivmentsBtns[3] = LikeAPro;
        //AchivmentsBtns[4] = ThePowerIsWithYou;
        //AchivmentsBtns[5] = TheMajorLeage;
        //AchivmentsBtns[6] = Master;
        //AchivmentsBtns[7] = TheNextLevel;
        //AchivmentsBtns[8] = SuccessIsOnTheWay;
        //AchivmentsBtns[9] = ChampionOfTheYear;
        //AchivmentsBtns[10] = TheGodOfSnakes;

        //-------------buttons---------

        //FirstBeginning.interactable = false;
        //TheRightDirection.interactable = false;
        //WelcomeToTheClub.interactable = false;
        //LikeAPro.interactable = false;
        //ThePowerIsWithYou.interactable = false;
        //TheMajorLeage.interactable = false;
        //Master.interactable = false;
        //TheNextLevel.interactable = false;
        //SuccessIsOnTheWay.interactable = false;
        //ChampionOfTheYear.interactable = false;
        //TheGodOfSnakes.interactable = false;
    }
  
	
	// Update is called once per frame
	void Update () {
	
	}
}
