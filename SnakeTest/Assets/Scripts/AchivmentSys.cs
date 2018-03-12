using System.Collections.Generic;
using UnityEngine;


public class AchivmentSys : MonoBehaviour {

    // Use this for initialization
    private AchivmentsScores[] Achivments;
    private string achivmentname;
    private int score;
    private int credits;
    private int LevelUnlock;
    public static List<string> achivedlist = new List<string>();
    public static List<string> AchivedListArr;
    string table;
    
    public AchivmentSys ()
    {
        
    }
    public AchivmentsScores [] InitiateAchivments()
    {
        
        Achivments = new AchivmentsScores[11];
        for (int i = 0; i < Achivments.Length; i++) Achivments[i] = new AchivmentsScores(i);
        for (int i = 0; i < Achivments.Length; i++)
        {
            setvalues(i);
            if (i >= 7)
                Achivments[i].SetLevelUnlock(LevelUnlock);
            Achivments[i].SetAchivmentName(achivmentname);
            Achivments[i].SetAchivmentScore(score);
            Achivments[i].SetAchivmentCredits(credits);
           
        }
        return Achivments;

    }
    public string AchivmnetTable()
    {
        for(int i =0;i<Achivments.Length;i++)
        {
            table += (Achivments[i].GetAchivmentName() + "Is Achieved :" + Achivments[i].GetIsAchived() + "\n");
        }
        return table;
    }
   public AchivmentsScores [] getachivments()
    {
        return Achivments;
    }
    public List<string> IfAchived()
    {
        
        
        for(int i =0;i<Achivments.Length;i++)
        {
            if(Achivments[i].GetAchivmentScore() <= PlayerController.Score && Achivments[i].GetIsAchived()==0 && Achivments[i].GetLevelUnlock() <= PlayerPrefs.GetInt("Totalscore"))
            {

                achiv.achivmenttext = ("Achievement unlocked :" + Achivments[i].GetAchivmentName() +" +"+Achivments[i].GetAchivmentCredits()+" credits");
                PlayerController.animation = 1;
                achivedlist.Add(Achivments[i].GetAchivmentName());
                PlayerPrefs.SetInt("Credits", PlayerPrefs.GetInt("Credits")+ Achivments[i].GetAchivmentCredits());
                PlayerController.Credits = PlayerPrefs.GetInt("Credits");
                Achivments[i].SetIsAchived(1, i);

            }
           
        }

        //if (achivedlist.Count > 0)
        //{
        //    int i = 0;
        //    foreach (string achivment in achivedlist)
        //    {
        //        AchivedListArr.Add(achivment);
        //        i++;
        //    }
        //}

        return achivedlist;
        
    }
    private void setvalues(int i)
    {
        
       
            switch (i)
            {
                case 0:
                    {
                        
                        achivmentname = "First Beggining";
                        score = 10;
                        credits = 5;
                        break;
                    }
                case 1:
                    {
                        achivmentname = "The Right Direction";
                        score = 20;
                        credits = 10;
                        break;
                    }
                case 2:
                    {
                        achivmentname = "Welcome to the club!";
                        score = 35;
                        credits = 15;
                        break;
                    }
            case 3:
                {
                    achivmentname = "Like A Pro!";
                    score = 45;
                    credits = 20;
                    break;
                }
            case 4:
                {
                    achivmentname = "The power is with you !";
                    score = 55;
                    credits = 25;
                    break;
                }
            case 5:
                {
                    achivmentname = "The major leage";
                    score = 65;
                    credits = 40;
                    break;
                }
            case 6:
                {
                    achivmentname = "Master!";
                    score = 70;
                    credits = 50;
                    break;
                }
         
            case 7:
                {
                    achivmentname = "The next level";
                    LevelUnlock = 100;//total score of 100 points
                    score = 1;
                    credits = 10;
                    break;
                }
            case 8:
                {
                    achivmentname = "Success is on the Way!";
                    LevelUnlock = 1200;//total score of 1200 points
                    score = 1;
                    credits = 25;
                    break;
                }
            case 9:
                {
                    achivmentname = "Champion of the Year!";
                    LevelUnlock = 4000;//total score of 4000 points
                    score = 1;
                    credits = 50;
                    break;
                }
            case 10:
                {
                    achivmentname = "The God of snakes!";
                    LevelUnlock = 5500;//total score of 5500 points
                    score = 1;
                    credits = 100;
                    break;
                }
            
        }
       
        
    }

}
