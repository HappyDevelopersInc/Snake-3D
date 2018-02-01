using UnityEngine;
using System.Collections;

public class AchivmentsScores : MonoBehaviour {

    //----------Achivment Class OBJECT------------------

    // Use this for initialization
    private string _Achivment;
    private int _AchivmentScore;
    private int _Credits; //temp variable
    private int _levelunlock;
    private int _IsAchived;

    
    public AchivmentsScores(string Achivment,int AchivmentScore,int Credits,int LevelUnlock)
    {
        this._Achivment = Achivment;
        this._AchivmentScore = AchivmentScore;
        this._Credits = Credits;
        this._levelunlock = LevelUnlock;
        
    }
    public AchivmentsScores(int i)
    {
        this._Achivment = "achivment";
        this._IsAchived = PlayerPrefs.GetInt("isachived", 0);
        switch (i)
        {
            case 0:
                {
                    
                    this._IsAchived = PlayerPrefs.GetInt("firstbeggingisachived",0);
                    break;
                }
            case 1:
                {
                   
                    this._IsAchived = PlayerPrefs.GetInt("therightdirectionisachived",0);
                    break;
                }
            case 2:
                {
                    
                    this._IsAchived = PlayerPrefs.GetInt("welcomtotheclubisachived",0);
                    break;
                }
            case 3:
                {
                   
                    this._IsAchived = PlayerPrefs.GetInt("likeaproisachived",0);
                    break;
                }
            case 4:
                {
                    
                    this._IsAchived = PlayerPrefs.GetInt("thepoweriswithyouisachived",0);
                    break;
                }
            case 5:
                {
                    this._IsAchived = PlayerPrefs.GetInt("themajorleageisachived",0);
                    break;
                }
            case 6:
                {
                    
                    this._IsAchived = PlayerPrefs.GetInt("masterisachived",0);
                    break;
                }
            case 7:
                {
                   
                    this._IsAchived = PlayerPrefs.GetInt("thenextlevelisachived",0);
                    break;
                }
            case 8:
                {
                    
                    this._IsAchived = PlayerPrefs.GetInt("successisonthewayisachived",0);
                    break;
                }
            case 9:
                {
                   
                    this._IsAchived = PlayerPrefs.GetInt("championoftheyearisachived",0);
                    break;
                }
            case 10:
                {
                   
                    this._IsAchived = PlayerPrefs.GetInt("thegodofsnakesisachived",0);
                    break;
                }
            
        }
        this._AchivmentScore = 1;
        this._levelunlock = 1;
        this._Credits = 0;
        this._levelunlock = 0;
    }


    public string AchivmentName
    {
        get { return AchivmentName; }
        set { AchivmentName = value; }
    }

    //---------Gets---------
    public string GetAchivmentName()
    {
        return this._Achivment;
    }
    public int GetAchivmentScore()
    {
        return this._AchivmentScore;
    }
    public int GetAchivmentCredits()
    {
        return this._Credits;
    }
    public int GetLevelUnlock()
    {
        return this._levelunlock;
    }
    public int GetIsAchived()
    {
        return this._IsAchived;
    }
    

    //------Sets---------
    public void SetAchivmentName(string AchivmentName)
    {
        this._Achivment = AchivmentName;
    }
    public void SetAchivmentScore(int AchivmentScore)
    {
        this._AchivmentScore = AchivmentScore;
    }
    public void SetAchivmentCredits(int AchivmentCredits)
    {
        this._Credits = AchivmentCredits;
        
    }
    public void SetLevelUnlock(int LevelUnlock)
    {
        this._levelunlock = LevelUnlock;
    }
    
    public void SetIsAchived(int _isachived,int _index)
    {

        sortachivments(_isachived, _index);
    }
    public void sortachivments(int isachived, int index)
    {

        switch (index)
        {
            case 0:
                {
                    PlayerPrefs.SetInt("firstbeggingisachived", isachived);
                    this._IsAchived = PlayerPrefs.GetInt("firstbeggingisachived");
                    break;
                }
            case 1:
                {
                    PlayerPrefs.SetInt("therightdirectionisachived", isachived);
                    this._IsAchived = PlayerPrefs.GetInt("therightdirectionisachived");
                    break;
                }
            case 2:
                {
                    PlayerPrefs.SetInt("welcomtotheclubisachived", isachived);
                    this._IsAchived = PlayerPrefs.GetInt("welcomtotheclubisachived");
                    break;
                }
            case 3:
                {
                    PlayerPrefs.SetInt("likeaproisachived", isachived);
                    this._IsAchived = PlayerPrefs.GetInt("likeaproisachived");
                    break;
                }
            case 4:
                {
                    PlayerPrefs.SetInt("thepoweriswithyouachived", isachived);
                    this._IsAchived = PlayerPrefs.GetInt("youarethemanisachived");
                    break;
                }
            case 5:
                {
                    PlayerPrefs.SetInt("themajorleageisachived", isachived);
                    this._IsAchived = PlayerPrefs.GetInt("themajorleageisachived");
                    break;
                }
            case 6:
                {
                    PlayerPrefs.SetInt("masterisachived", isachived);
                    this._IsAchived = PlayerPrefs.GetInt("masterisachived");
                    break;
                }
            case 7:
                {
                    PlayerPrefs.SetInt("thenextlevelisachived", isachived);
                    this._IsAchived = PlayerPrefs.GetInt("thenextlevelisachived");
                    break;
                }
            case 8:
                {
                    PlayerPrefs.SetInt("successisonthewayisachived", isachived);
                    this._IsAchived = PlayerPrefs.GetInt("successisonthewayisachived");
                    break;
                }
            case 9:
                {
                    PlayerPrefs.SetInt("championoftheyearisachived", isachived);
                    this._IsAchived = PlayerPrefs.GetInt("championoftheyearisachived");
                    break;
                }
            case 10:
                {
                    PlayerPrefs.SetInt("thegodofsnakesisachived", isachived);
                    this._IsAchived = PlayerPrefs.GetInt("themysteriouslevelisachived");
                    break;
                }
           
        }
    }

    }
