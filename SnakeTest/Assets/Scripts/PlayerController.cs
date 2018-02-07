using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Text;
using System;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {
    
    public static int animation;
    public AudioClip audioclipeat;
    public AudioClip audioclip;
    public GameObject apple;
    public float maxTime;
    public float minSwipeDist;
    //private GameObject ground;
    //private GameObject ground2;
    float swipeDistance;
    float swipeTime;
    float startTime;
    float endTime;
    float time = 4f;
    float count = 0;
    //float RandomAppleX = 0;
    //float RandomAppleZ = 0;
    //float RandomEnemyX = 0;
    //float RandomEnemyZ = 0;
    float RandomX = 0;
    float RandomZ = 0;
    public float Position;
    float timer;
    public byte tempmask;
    int rank = 1;
    int tempscore;
    public static int Level3score = 250;
    public static int Score;
    public int countlevel = 0;
    public int secoundcountlevel = 0;
    public int Speed; // The Speed of the Head of the snake.
    public GameObject Pomme;
    public Vector3 thePosition;
    public AudioSource appleeat;
    public AudioSource appleburp;
    private string key_pressed;
    public Text GameOverText;
    public Text ScoreText;
    public Text CreditText;
    public Text LevelText;
    public Button btnpause;
    public bool pauseflag;
    public GameObject FirstBP;
    GameObject[] enemy1;
    BodyPart BP;
    Node<BodyPart> Head;
    public byte Mask;
    bool keyboard;
    bool dead1;
    public static int levelscore;
    //public const int redapple = 1;
    //public const int greenapple = 2;
    //public const int purpleapple = 3;
    //public const int goldapple = 5;
    int delay = 0;
    int steptime = 1;
    int distance = 2;
    bool dead = false;
    Vector3 startPos;
    Vector3 endPos;
    public int touch_1 = 0;
    //---------------------------------------------
    private float pos = 0.1f;
    public static int save;
    private float decreaser;
    private float counter;
    private Vector3 screenPoint;
    private Vector3 offset;
    int cc = 0;
    public Camera mainCam;
   // int generate = 0;
    public Text nextleveltxt;
    public Text highscoretext;
    public Text SnakeName;
    //---------------------------------------------
    public GameObject button_lvl1;
    public static AchivmentSys achivmentsystem;
    public static AchivmentsScores[] achivmentscores;
    public Texture Tex;
    public int check;
    public Slider slider;
    public static int Credits;
    public static System.Collections.Generic.List<string> AchivmentsUnlocked;
    
    // Use this for initialization
    void Start() {
        
        animation = 0;
        achivmentsystem = new AchivmentSys();
        achivmentsystem.InitiateAchivments();
        achivmentscores = achivmentsystem.getachivments();
        Credits = PlayerPrefs.GetInt("Credits",0);
        
        PlayerPrefs.SetString("ss", "thebbi");
        pauseflag = false;
        appleeat = GetComponent<AudioSource>();
        appleburp= GetComponent<AudioSource>(); 
        if(PlayerPrefs.GetInt("checkloc")==0)
        {
            PlayerPrefs.SetInt("checkloc", 1);
            PlayerPrefs.SetInt("saveloc", 4);
        }
        save = PlayerPrefs.GetInt("saveloc");
        formula();
        PlayerPrefs.SetInt("tempscoregoal", PlayerPrefs.GetInt("scoreaftergoal"));
        PlayerPrefs.SetInt("scoreaftergoal", 0);
        if (PlayerPrefs.GetInt("checklvl2") == 0)
            PlayerPrefs.SetInt("checklvl2", 1);
        if (PlayerPrefs.GetInt("checklvl3") == 0)
            PlayerPrefs.SetInt("checklvl3", 1);
        if (PlayerPrefs.GetInt("rank") == 0)
            PlayerPrefs.SetInt("rank", 1);
        if (PlayerPrefs.GetInt("LVL_ACCESS")==0)
            PlayerPrefs.SetInt("LVL_ACCESS", 1);
        if (PlayerPrefs.GetInt("Highscore") == 0)
            PlayerPrefs.SetInt("Highscore", 0);
        if (PlayerPrefs.GetInt("Totalscore") == 0)
            PlayerPrefs.SetInt("Totalscore", 0);
        if (PlayerPrefs.GetInt("Totalscore") == 0 && PlayerPrefs.GetInt("checklvl2") == 1)
        {
            PlayerPrefs.SetInt("checklvl2", 2);
            PlayerPrefs.SetInt("levelscore", 100);
        }
        if (PlayerPrefs.GetInt("Totalscore") >= 100 && PlayerPrefs.GetInt("checklvl3")==1)
        {
            PlayerPrefs.SetInt("checklvl3", 2);
            PlayerPrefs.SetInt("levelscore", 250-PlayerPrefs.GetInt("tempscoregoal"));
        }
        
        
        if (PlayerPrefs.GetInt("Totalscore") >= 350 && PlayerPrefs.GetInt("checklvl3") == 2)
        {
            PlayerPrefs.SetInt("checklvl3", 3);
            PlayerPrefs.SetInt("levelscore", 350 - PlayerPrefs.GetInt("tempscoregoal"));
        }
        if (PlayerPrefs.GetInt("Totalscore") >= 700 && PlayerPrefs.GetInt("checklvl3") == 3)
        {
            PlayerPrefs.SetInt("checklvl3", 4);
            PlayerPrefs.SetInt("levelscore", 500 - PlayerPrefs.GetInt("tempscoregoal"));
        }

        if (PlayerPrefs.GetInt("Totalscore") >= 1200 && PlayerPrefs.GetInt("checklvl3") == 4)
        {
            PlayerPrefs.SetInt("checklvl3", 5);
            PlayerPrefs.SetInt("levelscore", 550 - PlayerPrefs.GetInt("tempscoregoal"));
        }
        if (PlayerPrefs.GetInt("Totalscore") >= 1750 && PlayerPrefs.GetInt("checklvl3") == 5)
        {
            PlayerPrefs.SetInt("checklvl3", 6);
            PlayerPrefs.SetInt("levelscore", 600 - PlayerPrefs.GetInt("tempscoregoal"));
        }
        if (PlayerPrefs.GetInt("Totalscore") >= 2350 && PlayerPrefs.GetInt("checklvl3") == 6)
        {
            PlayerPrefs.SetInt("checklvl3", 7);
            PlayerPrefs.SetInt("levelscore", 650 - PlayerPrefs.GetInt("tempscoregoal"));
        }
         if (PlayerPrefs.GetInt("Totalscore") >= 3000 && PlayerPrefs.GetInt("checklvl3") == 7)
        {
            PlayerPrefs.SetInt("checklvl3", 8);
            PlayerPrefs.SetInt("levelscore", 1000 - PlayerPrefs.GetInt("tempscoregoal"));
        }
        if (PlayerPrefs.GetInt("Totalscore") >= 4000 && PlayerPrefs.GetInt("checklvl3") == 8)
        {
            PlayerPrefs.SetInt("checklvl3", 9);
            PlayerPrefs.SetInt("levelscore", 1500 - PlayerPrefs.GetInt("tempscoregoal"));
        }
        if (PlayerPrefs.GetInt("Totalscore") >= 5500 && PlayerPrefs.GetInt("checklvl3") == 9)
            nextleveltxt.text = "All Levels are Unlocked\nYou can buy the secret level!";
        else
            nextleveltxt.text = "Total Score left to next level : " + PlayerPrefs.GetInt("levelscore");

        Score = 0;
        check = 0;
        dead1 = false;
        Apple.ground = GameObject.Find("Ground");
        Apple.ground2 = GameObject.Find("Ground2");
        Apple.RandomApple();
        GameOverText.text = "";
        ScoreText.text = "Score : " + Score;
        CreditText.text = "Credits " + Credits;
        

        //----------------------
        for (int i =0;i<3;i++)
        AddGameObject();
        
        //----------------------
        StartCoroutine(wait());
        if (Application.loadedLevel>=2)
            LevelChallenge();

        //--------------------------

        SnakeName.text = PlayerPrefs.GetString("NameOfSnake") + " The Snake.";
        switch (Application.loadedLevel)
        {
            case 1:
                {
                    levelscore = 15;
                    break;
                }
            case 2:
                {
                    levelscore = 20;
                    break;
                }
            case 3:
                {
                    levelscore = 30;
                    break;
                }
            case 4:
                {
                    levelscore = 40;
                    break;
                }
            case 6:
                {
                    break;
                }
        }

       
    }
    private IEnumerator Pause()
    {
        Time.timeScale = 0;
        float pauseEndTime = Time.realtimeSinceStartup + 1;
        for (int i=3;i>0;i--)
        {
            while (Time.realtimeSinceStartup < pauseEndTime)
            {

                LevelText.text = Convert.ToString(i);
                yield return 0;

            }
            pauseEndTime = Time.realtimeSinceStartup + 1;

        }

        LevelText.text = "";
        Time.timeScale = 1;
       
    }
    public void Clicked()
    {
        if (!pauseflag)
        {
            btnpause.GetComponentInChildren<Text>().text = "►";
            Time.timeScale = 0;
            pauseflag = true;
        }
        else
        {
            btnpause.GetComponentInChildren<Text>().text = " ▌▌";
            StartCoroutine(Pause());
            pauseflag = false;
        }
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
    }

    void Level_Text()
    {
        switch(Application.loadedLevelName)
        {
            case "Level_1":
                {
                    LevelText.text = "LEVEL 1";
                    if(PlayerPrefs.GetInt("LVL_ACCESS")==1)
                    if (PlayerPrefs.GetInt("Highscore") >= 15)
                        PlayerPrefs.SetInt("LVL_ACCESS", 2);
                    break;
                }
            case "Level_2":
                {
                    LevelText.text = "LEVEL 2";
                    break;
                }
            case "Level_3":
                {
                    LevelText.text = "LEVEL 3";
                    break;
                }
            case "Level_4":
                {
                    LevelText.text = "LEVEL 4";
                    break;
                }
            case "Level_5":
                {
                    LevelText.text = "LEVEL 5";
                    break;
                }
            case "Level_6":
                {
                    LevelText.text = "LEVEL 6";
                    break;
                }
            case "Level_7":
                {
                    LevelText.text = "LEVEL 7";
                    break;
                }
            case "Level_8":
                {
                    LevelText.text = "LEVEL 8";
                    break;
                }
            case "Level_9":
                {
                    LevelText.text = "LEVEL 9";
                    break;
                }
            case "Level_10":
                {
                    LevelText.text = "LEVEL 10";
                    break;
                }
        }
    }
    IEnumerator wait()
    {
        keyboard = false;
        Head.GetInfo().SetMask(0);
        Level_Text();
        
        yield return new WaitForSeconds(1);
        LevelText.text = "3";
        yield return new WaitForSeconds(1);
        LevelText.text = "2";
        yield return new WaitForSeconds(1);
        LevelText.text = "1";
        

        yield return new WaitForSeconds(1);
        Head.GetInfo().SetMask(3);
        keyboard = true;
        LevelText.text = "Go!";
        

        yield return new WaitForSeconds(0.5f);
        LevelText.text = "";

    }
    IEnumerator StartScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MenuScene");
    }
    IEnumerator Waitforsecond()
    {
       
        yield return new WaitForSeconds(1);
        appleburp.clip = audioclip;
        appleburp.Play();
    }
   
   
        IEnumerator LeaderBoardTime()
    {
        
        float fadeTime = GameObject.Find("Head").GetComponent<FadeScene>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        
        SceneManager.LoadScene("ScoreScene");
    }
 
    int j = 1;
   public GameObject[] LevelChallenge()
    {
        GameObject[] Enemys = new GameObject[1];
        
        switch (Application.loadedLevelName)
        {
            case "Level_2":
                {
                    Enemys = new GameObject[2];
                    for (int i = 0; i < Enemys.Length; i++)
                        Enemys[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Enemys[0].transform.position = new Vector3(-2.66f, -0.25f,-3.25f);
                    Enemys[1].transform.position = new Vector3(-1.14f, -0.25f, 2.5f);
                    SetMatireal(Enemys);
                    break;
                }
            case "Level_3":
                {
                    Enemys = new GameObject[3];
                    for (int i = 0; i < Enemys.Length; i++)
                        Enemys[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Enemys[0].transform.position = new Vector3(-2.66f, -0.25f, -3.25f);
                    Enemys[1].transform.position = new Vector3(-1.14f, -0.25f, 2.5f);
                    Enemys[2].transform.position = new Vector3(2.34f, -0.25f, 6.92f);
                    SetMatireal(Enemys);
                    break;
                }
            case "Level_4":
                {
                    Enemys = new GameObject[4];
                    for(int i =0;i<Enemys.Length;i++)
                        Enemys[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Enemys[0].transform.position = new Vector3(-2.66f, -0.25f, -3.25f);
                    Enemys[1].transform.position = new Vector3(-1.14f, -0.25f, 2.5f);
                    Enemys[2].transform.position = new Vector3(2.34f, -0.25f, 6.92f);
                    Enemys[3].transform.position = new Vector3(1.38f, -0.25f, 1.6f);
                    SetMatireal(Enemys);
                    break;
                }
            case "Level_5":
                {
                    Enemys = new GameObject[2];
                    for (int i = 0; i < Enemys.Length; i++)
                        Enemys[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Enemys[0].transform.position = new Vector3(4.22f, -0.25f, 7.25f);
                    Enemys[1].transform.position = new Vector3(-4.24f, -0.25f, -1.93f);
                    SetMatireal(Enemys);
                    break;
                }
            case "Level_6":
                {
                    Enemys = new GameObject[2];
                    for (int i = 0; i < Enemys.Length; i++)
                        Enemys[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Enemys[0].transform.position = new Vector3(2.0f, -0.25f, 2.58f);
                    Enemys[1].transform.position = new Vector3(-5.23f, -0.25f, -1f);
                    //MoveBySteps(Enemys);

                    SetMatireal(Enemys);
                    enemy1 = Enemys;
                    break;
                }
            case "Level_7":
                {
                    Enemys = new GameObject[3];
                    for(int i =0;i<Enemys.Length;i++)
                        Enemys[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    Enemys[0].transform.position = new Vector3(3f, -0.25f, 3.5f);
                    Enemys[1].transform.position = new Vector3(-5.23f, -0.25f, -1.5f);
                    Enemys[2].transform.position = new Vector3(-4.45f, -0.25f, 3.5f);
                    SetMatireal(Enemys);
                    enemy1 = Enemys;
                    break;


                }
            case "Level_8":
                {
                    Enemys = new GameObject[3];
                    for (int i = 0; i < Enemys.Length; i++)
                        Enemys[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    Enemys[0].transform.position = new Vector3(4.36f, -0.25f, 6.73f);
                    Enemys[1].transform.position = new Vector3(6.58f, -0.25f, 2.31f);
                    Enemys[2].transform.position = new Vector3(-1.08f, -0.25f, -2.01f);
                    SetMatireal(Enemys);
                    enemy1 = Enemys;
                    break;


                }
            case "Level_9":
                {
                    Enemys = new GameObject[3];
                    for (int i = 0; i < Enemys.Length; i++)
                        Enemys[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    Enemys[0].transform.position = new Vector3(0.4f, -0.25f, 3.29f);
                    Enemys[1].transform.position = new Vector3(8.42f, -0.25f, 0.65f);
                    Enemys[2].transform.position = new Vector3(-1.68f, -0.25f, 8.46f);
                    SetMatireal(Enemys);
                    enemy1 = Enemys;
                    break;


                }
        }
        



        return Enemys;
            
    }
    void SetMatireal(GameObject[] enemys)
    {
        for (int i = 0; i < enemys.Length; i++)
        {

            Renderer rend = enemys[i].GetComponent<Renderer>();
            rend.material.color = Color.red;
            enemys[i].transform.localScale -= new Vector3(0.65f, 0.5f, 0.65f);
            enemys[i].tag = "Enemy";
        }
    }
    void MoveEnemy()
    {
        float x;
        x = 0f;
        while (x <= 5f)
        {
            LevelChallenge()[0].transform.position = new Vector3(0f+x, -0.25f, 2.58f);
            x += 0.2f;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Tail"))
        {
            dead1 = true;
            Time.timeScale = 0;
            //AchivmentsUnlocked = achivmentsystem.IfAchived();
            StartCoroutine(LeaderBoardTime());
            
            tempscore +=Score;

            Node<BodyPart> tmp = Head;
            while (tmp != null)
            {
                tmp.GetInfo().SetMask(0);
                tmp = tmp.GetNext();
            }
            Time.timeScale = 1;
            achivmentsystem.IfAchived();
            achivmentscores = achivmentsystem.getachivments();
            
            Debug.Log(achivmentsystem.AchivmnetTable()); 
        }
        
        EngageApple("RedApple", other,Apple.redapple);
        EngageApple("GreenApple", other,Apple.greenapple);
        EngageApple("PurpleApple", other,Apple.purpleapple);
        EngageApple("GoldApple", other, Apple.goldapple);
        

    }
    void EngageApple(string appletag, Collider other,int appletype)
    {
        if (other.gameObject.CompareTag(appletag))
        {
            if (ClickObk.mute == false)
            {
                if (appletag != "RedApple")
                {
                    appleeat.Play();
                    StartCoroutine(Waitforsecond());
                    appleeat.clip = audioclipeat;
                }
                else
                {
                    appleeat.clip = audioclipeat;
                    appleeat.Play();
                }
            }

            other.gameObject.tag = "non";//beacuse the function enters twice on the same object,the object does not have enougth time to disapeare.
            Destroy(other.gameObject);
            Score += appletype;
            Apple.generate++;
            Apple.RandomApple();
            AddGameObject();
            
            //anim.Play();
            
            if (PlayerPrefs.GetInt("levelscore") > 0)
            {

                PlayerPrefs.SetInt("levelscore", PlayerPrefs.GetInt("levelscore") - appletype);
                if (PlayerPrefs.GetInt("Totalscore") >= 1200 && PlayerPrefs.GetInt("checklvl3") == 4)
                    nextleveltxt.text = "All Levels are Unlocked\nWait For Final Release";
                else
                    nextleveltxt.text = "Total Score left to next level : " + PlayerPrefs.GetInt("levelscore");
            }
            if (PlayerPrefs.GetInt("levelscore") <= 0)
            {
                PlayerPrefs.SetInt("scoreaftergoal", PlayerPrefs.GetInt("scoreaftergoal") + 1);
                if (check == 0)
                {
                    PlayerPrefs.SetInt("rank", PlayerPrefs.GetInt("rank") + 1);
                    check = 1;
                }
                if (PlayerPrefs.GetInt("rank") == 2)
                {
                    nextleveltxt.text = "Level 2 is UNLOCKED! +" + PlayerPrefs.GetInt("scoreaftergoal");
                    nextleveltxt.color = Color.green;
                }
                if (PlayerPrefs.GetInt("rank") == 3)
                {
                    nextleveltxt.text = "Level 3 is UNLOCKED!+" + PlayerPrefs.GetInt("scoreaftergoal");
                    nextleveltxt.color = Color.green;
                }
                if (PlayerPrefs.GetInt("rank") == 4)
                {
                    nextleveltxt.text = "Level 4 is UNLOCKED!+" + PlayerPrefs.GetInt("scoreaftergoal");
                    nextleveltxt.color = Color.green;
                }
                if (PlayerPrefs.GetInt("rank") == 5)
                {
                    nextleveltxt.text = "Level 5 is UNLOCKED!+" + PlayerPrefs.GetInt("scoreaftergoal");
                    nextleveltxt.color = Color.green;
                }
                if (PlayerPrefs.GetInt("rank") == 6)
                {
                    nextleveltxt.text = "Level 6 is UNLOCKED!+" + PlayerPrefs.GetInt("scoreaftergoal");
                    nextleveltxt.color = Color.green;
                }
                if (PlayerPrefs.GetInt("rank") == 7)
                {
                    nextleveltxt.text = "Level 7 is UNLOCKED!+" + PlayerPrefs.GetInt("scoreaftergoal");
                    nextleveltxt.color = Color.green;
                }
                if (PlayerPrefs.GetInt("rank") == 8)
                {
                    nextleveltxt.text = "Level 8 is UNLOCKED!+" + PlayerPrefs.GetInt("scoreaftergoal");
                    nextleveltxt.color = Color.green;
                }
                if (PlayerPrefs.GetInt("rank") == 9)
                {
                    nextleveltxt.text = "Level 9 is UNLOCKED!+" + PlayerPrefs.GetInt("scoreaftergoal");
                    nextleveltxt.color = Color.green;
                }
                if (PlayerPrefs.GetInt("rank") == 10)
                {
                    nextleveltxt.text = "Level 10 is UNLOCKED!+" + PlayerPrefs.GetInt("scoreaftergoal");
                    nextleveltxt.color = Color.green;
                }
            }
             AchivmentsUnlocked = achivmentsystem.IfAchived();

            PlayerPrefs.SetInt("Totalscore", PlayerPrefs.GetInt("Totalscore") + appletype);
        }
        


    }
    
    void Update()
    {
        timer += Time.deltaTime;
  

        if (Input.touchCount > 0)//if there was a touch
        {
            touch_1 = 1;
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)//if the finger touched the screen
            {
                //startTime = Time.time;
                startPos = touch.position;
            }

            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)//if the finger left the screen
            {
                //endTime = Time.time;
                endPos = touch.position;

                swipeDistance = (endPos - startPos).magnitude;
                //swipeTime = endTime - startTime;

                if (swipeTime < maxTime && swipeDistance > minSwipeDist)
                {
                    swipe();
                }

            }
        }


    }
   
    public void ChangeSpeed(float value)
    {
        
        float temp = value;
        leaderboard.cc = 1;
        switch ((int)temp)
        {
            case 1:
                {
                    pos = 0.03125f;
                    leaderboard.tomp = pos;
                    formula();
                    PlayerPrefs.SetInt("saveloc", 1);
                    leaderboard. slider.value = 1;
                    break;
                }
            case 2:
                {
                    pos = 0.05f;
                    leaderboard.tomp = pos;
                    formula();
                    PlayerPrefs.SetInt("saveloc", 2);
                    leaderboard.slider.value = 2;
                    save = 2;
                    break;
                }
            case 3:
                {
                    pos = 0.0625f;
                    leaderboard.tomp = pos;
                    formula();
                    PlayerPrefs.SetInt("saveloc", 3);
                    leaderboard.slider.value = 3;
                    break;
                }
            case 4:
                {
                    pos = 0.1f;
                    leaderboard.tomp = pos;
                    formula();
                    PlayerPrefs.SetInt("saveloc", 4);
                    leaderboard.slider.value = 4;
                    break;
                }
            default:
                {
                    pos = 0.1f;
                    leaderboard.tomp = pos;
                    formula();
                    PlayerPrefs.SetInt("saveloc", 4);
                    leaderboard.slider.value = 4;
                    break;
                }
               
        }
    }
    public void formula()
    {
        if (leaderboard.cc == 1)
            Position = leaderboard.tomp;
        else
            Position = pos;
        counter = (-Position + 0.125f) / 0.01f;
        decreaser = counter / (0.5f / Position);
        BP = new BodyPart(0.1f, 0.2f, FirstBP,counter);
        Head = new Node<BodyPart>(BP);
    }
        void FixedUpdate () {

        //--------------------------------------------------
        ScoreText.text = "Score : " + Score;
        CreditText.text = "Credits " + Credits; 
        movement();
        
        
	
	}
    //void LocationOfApple(float applex1,float applex2,float applez1,float applez2)
    //{
    //    float bnddelta = 2f; 
    //    if (generate % 4 == 0)
    //    {
    //        RandomAppleX = UnityEngine.Random.Range(applex1, applex2);
    //        RandomAppleZ = UnityEngine.Random.Range(applez1, applez2);
    //        Node<BodyPart> temp2 = Head;
    //        while (temp2 != null)
    //        {

    //            while (Math.Abs(RandomAppleX - temp2.GetInfo().GetX()) < bnddelta && Math.Abs(RandomAppleZ - temp2.GetInfo().GetY()) < bnddelta && Math.Abs(RandomEnemyX - temp2.GetInfo().GetX()) < 0.8f && Math.Abs(RandomEnemyZ - temp2.GetInfo().GetY()) < 0.8f)
    //            {
    //                RandomAppleX = UnityEngine.Random.Range(applex1, applex2);
    //                RandomAppleZ = UnityEngine.Random.Range(applez1, applez2);
    //            }

    //            temp2 = temp2.GetNext();
    //        }
    //    }
    //    else
    //    {
    //        DefaultAppleLocation();
    //    }
           
    //}
    //void DefaultAppleLocation()
    //{
    //    float bnddelta = 2f;
    //        RandomAppleX = UnityEngine.Random.Range(-(ground.GetComponent<Renderer>().bounds.size.x / 2) + bnddelta, (ground.GetComponent<Renderer>().bounds.size.x / 2) - bnddelta);
    //        RandomAppleZ = UnityEngine.Random.Range(-(ground.GetComponent<Renderer>().bounds.size.z / 2) + bnddelta, (ground.GetComponent<Renderer>().bounds.size.z / 2) - bnddelta);
    //        Node<BodyPart> temp = Head;
    //        while (temp != null)
    //        {

    //            while (Math.Abs(RandomAppleX - temp.GetInfo().GetX()) < bnddelta && Math.Abs(RandomAppleZ - temp.GetInfo().GetY()) < bnddelta && Math.Abs(RandomEnemyX - temp.GetInfo().GetX()) < 0.8f && Math.Abs(RandomEnemyZ - temp.GetInfo().GetY()) < 0.8f)
    //            {
    //                RandomAppleX = UnityEngine.Random.Range(-(ground.GetComponent<Renderer>().bounds.size.x / 2) + bnddelta, (ground.GetComponent<Renderer>().bounds.size.x / 2) - bnddelta);
    //                RandomAppleZ = UnityEngine.Random.Range(-(ground.GetComponent<Renderer>().bounds.size.z / 2) + bnddelta, (ground.GetComponent<Renderer>().bounds.size.z / 2) - bnddelta);
    //            }

    //            temp = temp.GetNext();
    //        }
    //    }

    //void RandomApple()//function that generates new object each time it's called.
    //{
    //    switch (Application.loadedLevel)
    //    {
            
    //        case 3:
    //            {
    //                if (generate % 4 == 0)
    //                {
    //                    LocationOfApple(-0.2f, 4.6f, 5f, 9f);
    //                }
    //                else
    //                    DefaultAppleLocation();
    //                break;
    //            }
    //        case 4:
    //            {
    //                if (generate % 4 == 0)
    //                {
    //                    LocationOfApple(-4f, 4.6f, 5f, 9f);
    //                }
    //                else
    //                    DefaultAppleLocation();
    //                break;
    //            }
    //        case 5:
    //            {
    //                if (generate % 4 == 0)
    //                {
    //                    if (countlevel == 0)
    //                    {
    //                        countlevel = 1;
    //                        LocationOfApple(-6.2f, -2.2f, 5f, 9f);
    //                    }
    //                    else
    //                    {
    //                        countlevel = 0;
    //                        LocationOfApple(2.3f, 6.3f, 5f, 9f);
    //                    }
    //                }
    //                else
    //                    DefaultAppleLocation();
    //                break;
    //            }
    //        case 6:
    //            {
    //                if (generate % 4 == 0)
    //                    LocationOfApple(-6.5f, 6.5f, 4.5f, -4.5f);
    //                else
    //                    DefaultAppleLocation();
    //                break;
    //            }
    //        case 7:
    //            {
    //                if (generate % 4 == 0)
    //                {
    //                    LocationOfApple(2.3f, 6.3f, 5f, 9f);
    //                }
    //                else
    //                    DefaultAppleLocation();
    //                break;
    //            }
    //        case 8:
    //            {
    //                if (generate % 4 == 0)
    //                {
    //                    if (countlevel == 0)
    //                    {
    //                        countlevel = 1;
    //                        LocationOfApple(2.23f, 6.37f, 5f, 9f);
    //                    }
    //                    else
    //                    {
    //                        countlevel = 0;
    //                        LocationOfApple(4.5f, 8.15f, 4f, 1.22f);
    //                    }
    //                }
    //                else
    //                    LocationOfApple(-6.4f,3.3f, 4.17f,-4.16f);
    //                break;
    //            }
    //        case 9:
    //            {
    //                if (generate % 4 == 0)
    //                {
                        
    //                    if (countlevel == 0)
    //                    {
    //                        countlevel = 1;
    //                        LocationOfApple(-2.0f, 2.7f, 5.3f, 9f);
    //                    }
    //                    else if (countlevel == 1)
    //                    {
    //                        countlevel = 2;
    //                        LocationOfApple(-8.9f, -3.25f, 1.3f, 4f);
    //                    }
    //                    else
    //                    {
    //                        countlevel = 0;
    //                        LocationOfApple(3.57f, 9f, 1.3f, 4f);
    //                    }
    //                }
                   
    //                else
    //                {
    //                    secoundcountlevel = 0;
    //                    LocationOfApple(-1.8f, 2.6f, 0.3f, 4.3f);
    //                }
    //                break;

    //            }
    //        case 10:
    //            {
    //                if (generate % 4 == 0)
    //                {

    //                    if (countlevel == 0)
    //                    {
    //                        countlevel = 1;
    //                        LocationOfApple(-6.0f, 2.0f, 5.8f, 8.5f);
    //                    }
    //                    else if (countlevel == 1)
    //                    {
    //                        countlevel = 2;
    //                        LocationOfApple(3.2f, 6.3f, -0.5f, 8.5f);
    //                    }
    //                    else
    //                    {
    //                        countlevel = 0;
    //                        LocationOfApple(-2.8f, 6f, -3.5f, 1.7f);
    //                    }
    //                }

    //                else
    //                {
    //                    secoundcountlevel = 0;
    //                    LocationOfApple(-1.78f, 1.7f, 0.5f, 3.5f);
    //                }
    //                break;

    //            }

    //        default:
    //            {
    //                DefaultAppleLocation();
    //                break;
    //            }
    //    }

    //    switch(Application.loadedLevel)
    //    {
    //        case 1:
    //            {
    //                ApplePlacement(redapple);
    //                break;
    //            }
    //        case 2:
    //            {
    //                ApplePlacement(redapple, greenapple);
    //                break;
    //            }
    //        case 3:
    //            {
    //                ApplePlacement(redapple, greenapple);
    //                break;
    //            }
    //        case 4:
    //            {
    //                ApplePlacement(redapple, greenapple);
    //                break;
    //            }
    //        case 5:
    //            {
    //                ApplePlacement(redapple, greenapple,purpleapple);
    //                break;
    //            }
    //        case 6:
    //            {
    //                ApplePlacement(redapple, greenapple,purpleapple);
    //                break;
    //            }
    //        case 7:
    //            {
    //                ApplePlacement(greenapple, purpleapple);
    //                break;
    //            }
    //        case 8:
    //            {
    //                ApplePlacement(greenapple,purpleapple, goldapple);
    //                break;
    //            }
    //        case 9:
    //            {
    //                ApplePlacement(purpleapple, goldapple);
    //                break;
    //            }
    //        case 10:
    //            {
    //                ApplePlacement(purpleapple, goldapple);
    //                break;
    //            }
    //    }
    //}
    //void SetAppleTag(int appletype)
    //{
    //    float applesize = 1.5f;
    //    GameObject Apple = (GameObject)Instantiate(Resources.Load("Apple"));
    //    Apple.transform.position = new Vector3(RandomAppleX, -0.2f, RandomAppleZ);//each time the function called then,instansiate new object at random postion.
    //    MeshRenderer rend = Apple.GetComponent<MeshRenderer>();
    //    Apple.transform.localScale += new Vector3(applesize, applesize, applesize);
    //    SphereCollider spcolider = Apple.gameObject.AddComponent<SphereCollider>();// (SphereCollider)Apple.gameObject.AddComponent(typeof(SphereCollider));
    //    switch (appletype)
    //    {

    //        case 2:
    //            {
                
    //                foreach (var child in Apple.GetComponentsInChildren<Renderer>())
    //                    child.material.color = Color.green;
    //                Apple.tag = "GreenApple";
    //                Apple.transform.localScale += new Vector3(applesize, applesize, applesize);
    //                spcolider.center = new Vector3(0.14f, 0.04f, -0.045f);
    //                spcolider.radius = 0.05418529f;
                    
    //                break;
    //            }
    //        case 3:
    //            {
    //                foreach (var child in Apple.GetComponentsInChildren<Renderer>())
    //                    child.material.color = new Color(148, 0, 211);
                    
    //                Apple.tag = "PurpleApple";
    //                Apple.transform.localScale += new Vector3(applesize,applesize, applesize);
    //                spcolider.center = new Vector3(0.14f, 0.04f, -0.045f);
    //                spcolider.radius = 0.05418529f;
    //                break;
    //            }
    //        case 5:
    //            {
    //                foreach (var child in Apple.GetComponentsInChildren<Renderer>())
    //                    child.material.color = Color.yellow;
                    
    //                Apple.tag = "GoldApple";
    //                Apple.transform.localScale += new Vector3(applesize,applesize, applesize);
    //                spcolider.center = new Vector3(0.14f, 0.04f, -0.045f);
    //                spcolider.radius = 0.05418529f;
    //                break;
    //            }
    //        default:
    //            {
    //                rend.material.color = Color.blue;
    //                Apple.tag = "RedApple";
    //                Apple.transform.localScale += new Vector3(applesize, applesize, applesize);
    //                Apple.transform.position = new Vector3(RandomAppleX, -0.25f, RandomAppleZ);
    //                spcolider.center = new Vector3(0.135f, 0.04f, -0.05f);
    //                spcolider.radius = 0.05622346f;

    //                break;
    //            }
                

    //    }

    //}
    //public int ApplePlacement(int Apple1,int Apple2=0,int Apple3 = 0)
    //{


    //    if (generate % 8 == 0)
    //    {
    //        if (Apple3 == 0)
    //        {
    //            SetAppleTag(Apple1);
    //            return Apple1;
    //        }
    //        else
    //        {
    //            SetAppleTag(Apple3);
    //            return Apple3;
    //        }

    //    }
    //    else if (generate % 5 == 0&&Apple2!=0)
    //    {

    //        SetAppleTag(Apple2);
    //        return Apple2;
    //    }
    //    else
    //    {
    //        SetAppleTag(Apple1);
    //        return Apple1;
    //    }
        
    //}
    void AddGameObject()
    {
        
        int count = 1;
        GameObject NewTail = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Renderer rend = NewTail.GetComponent<Renderer>();
        rend.material.color = Color.blue;
        NewTail.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
        SphereCollider TailColider = (SphereCollider)NewTail.gameObject.AddComponent(typeof(SphereCollider));
        TailColider.center = Vector3.zero;
        //-----End of creating new gameobject for tail.
        Node<BodyPart> temp;
        BodyPart newbd = new BodyPart(0.0f,0.0f,NewTail,counter);
        temp = new Node<BodyPart>(newbd);

        Node<BodyPart> pos = Head;
        while (pos.GetNext() != null)
        {
            count++;
            pos = pos.GetNext();
        }
        if(count>3)
        {
            NewTail.tag = "Tail";
        }
        switch (pos.GetInfo().GetMask())
        {
            case 2://last node is moving up
                {
                 
                    temp.GetInfo().SetXY(pos.GetInfo().GetX(), pos.GetInfo().GetY() - 0.501f);
                    temp.GetInfo().SetMask(pos.GetInfo().GetMask());
                    
                    break;
                }
            case 3://last node is moving left
                {
                    temp.GetInfo().SetXY(pos.GetInfo().GetX() +0.501f, pos.GetInfo().GetY());
                    temp.GetInfo().SetMask(pos.GetInfo().GetMask());
                    break;
                }
            case 4://last node is moving down
                {
                    temp.GetInfo().SetXY(pos.GetInfo().GetX(), pos.GetInfo().GetY() +0.501f);
                    temp.GetInfo().SetMask(pos.GetInfo().GetMask());
                    break;
                }
            case 5://last node is moving right
                {
                    temp.GetInfo().SetXY(pos.GetInfo().GetX() - 0.501f, pos.GetInfo().GetY());
                    temp.GetInfo().SetMask(pos.GetInfo().GetMask());
                    break;
                }

        }
        temp.GetInfo().SetMask(pos.GetInfo().GetMask());
        pos.SetNext(temp);

       
  }
    void swipe()
    {
        if (keyboard == true)
        {
            Vector2 distance = endPos - startPos;

            if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
            {
                if (distance.x > 0)
                {
                    Debug.Log("Right Swipe");
                    key_pressed = "Right";
                }
                if (distance.x < 0)
                {
                    Debug.Log("Left Swipe");
                    key_pressed = "Left";
                }
            }
            else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
            {
                if (distance.y > 0)
                {
                    Debug.Log("Up Swipe");
                    key_pressed = "Up";
                }
                if (distance.y < 0)
                {
                    Debug.Log("Down Swipe");
                    key_pressed = "Down";
                }
            }
        }
    }
        void movement()//function that moves the obejct(Head of the snake)to the direction that the user will choose.
    {
        if (dead1 == false)
        {
            if (keyboard == true)
            {

                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    key_pressed = "Left";
                }
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.RightArrow))
                {
                    key_pressed = "Right";
                }
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.UpArrow))
                {
                    key_pressed = "Up";
                }
                if (Input.GetKey(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.DownArrow))
                {
                    key_pressed = "Down";

                }
            }

            switch (key_pressed)
            {
                case "Left":
                    {

                        //---------------------------------------------
                        if (Head.GetNext() != null && Head.GetInfo().GetMask() != Head.GetNext().GetInfo().GetMask() && Head.GetInfo().GetCounter() > 0)
                        {

                            Head.GetInfo().SetCounter(Head.GetInfo().GetCounter() - decreaser);
                        }
                        else {
                            Head.GetInfo().SetCounter(counter);
                            if (Head.GetInfo().GetMask() != 5)
                                Head.GetInfo().SetMask(3);
                        }
                        break;
                    }
                case "Right":
                    {

                        //--------------------------------------------
                        if (Head.GetNext() != null && Head.GetInfo().GetMask() != Head.GetNext().GetInfo().GetMask() && Head.GetInfo().GetCounter() > 0)
                        {

                            Head.GetInfo().SetCounter(Head.GetInfo().GetCounter() - decreaser);
                        }
                        else {
                            Head.GetInfo().SetCounter(counter);
                            if (Head.GetInfo().GetMask() != 3)
                                Head.GetInfo().SetMask(5);
                        }
                        break;
                    }
                case "Up":
                    {

                        //-----------------------------------------------------
                        if (Head.GetNext() != null && Head.GetInfo().GetMask() != Head.GetNext().GetInfo().GetMask() && Head.GetInfo().GetCounter() > 0)
                        {

                            Head.GetInfo().SetCounter(Head.GetInfo().GetCounter() - decreaser);
                        }
                        else {
                            Head.GetInfo().SetCounter(counter);
                            if (Head.GetInfo().GetMask() != 4)
                                Head.GetInfo().SetMask(2);
                        }

                        break;
                    }
                case "Down":
                    {

                        //----------------------------------------------
                        if (Head.GetNext() != null && Head.GetInfo().GetMask() != Head.GetNext().GetInfo().GetMask() && Head.GetInfo().GetCounter() > 0)
                        {

                            Head.GetInfo().SetCounter(Head.GetInfo().GetCounter() - decreaser);
                        }
                        else {
                            Head.GetInfo().SetCounter(counter);
                            if (Head.GetInfo().GetMask() != 2)
                                Head.GetInfo().SetMask(4);
                        }

                        break;
                    }



            }//END OF SWITCH
             //block to compute the mask of all nodes
            byte prevmask = Head.GetInfo().GetMask();
            Node<BodyPart> tmp = Head;
            
            while (tmp != null)
            {

                if (tmp.GetInfo().GetMask() != prevmask)
                {
                    if (tmp.GetInfo().GetCounter() > 0)
                        tmp.GetInfo().SetCounter(tmp.GetInfo().GetCounter() - decreaser);
                    else //when the counter equals 0 - we want to changing a node moving direction
                    {
                        tmp.GetInfo().SetCounter(counter);
                        tmp.GetInfo().SetMask(prevmask);
                    }




                }

                prevmask = tmp.GetInfo().GetMask();
                tmp = tmp.GetNext();

            }
            //s - 1
            //u - 2
            //l - 3
            //d - 4
            //r - 5
            
            tmp = Head;
            while (tmp != null)
            {
                switch (tmp.GetInfo().GetMask())
                {
                    case 1://stop

                        break;

                    case 2://up
                        {
                            Vector3 position_1 = tmp.GetInfo().GetVector3();
                            position_1.z +=Position;
                            tmp.GetInfo().SetVector3(position_1);
                            break;
                        }
                    case 3://left
                        {
                            Vector3 position_1 = tmp.GetInfo().GetVector3();
                            position_1.x -= Position;
                            tmp.GetInfo().SetVector3(position_1);
                            break;
                        }
                    case 4://down
                        {
                            Vector3 position_1 = tmp.GetInfo().GetVector3();
                            position_1.z -= Position;
                            tmp.GetInfo().SetVector3(position_1);
                            break;
                        }
                    case 5:////right
                        {
                            Vector3 position_1 = tmp.GetInfo().GetVector3();
                            position_1.x += Position;
                            tmp.GetInfo().SetVector3(position_1);
                            break;
                        }

                }
                tmp = tmp.GetNext();




            }
            switch (Application.loadedLevelName)
            {
                case "Level_6":
                    {
                        moveEnemy(0, "x","R");
                        moveEnemy(1, "z","U");
                        break;
                    }
                case "Level_7":
                    {
                        moveEnemy(0, "x","L");
                        moveEnemy(1, "z","U");
                        moveEnemy(2, "x","R");
                        break;
                    }
                case "Level_8":
                    {
                        moveEnemy(0, "z", "D");
                        moveEnemy(1, "x", "L");
                        //moveEnemy(2, "x", "R");
                        break;
                    }
                case "Level_9":
                    {
                        moveEnemy(1, "z", "U");
                        moveEnemy(2, "x", "R");
                        break;
                    }

            }
            
            
        }
    }
    void moveEnemy(int enemynumber ,string hight,string direc)
    {
      
        GameObject[] enemy = enemy1;
        
        Vector3 enemyposition = enemy1[enemynumber].transform.position;

        if (time > 0 && cc == 0)
        {
            time -= Time.deltaTime;
            if (hight == "x"&&direc=="R")
                enemyposition.x += 0.03f;
            else if(hight =="x"&& direc =="L")
                enemyposition.x -= 0.03f;
            else if(hight=="z" && direc =="D")
                enemyposition.z -= 0.03f;
            else
                enemyposition.z += 0.03f;
            enemy[enemynumber].transform.position = enemyposition;

        }
        else
        {
            cc = 1;
            time += Time.deltaTime;
            if (time < 4f && cc == 1)
            {
                if (hight == "x"&&direc =="R")
                    enemyposition.x -= 0.03f;
                else if(hight== "x"&&direc =="L")
                    enemyposition.x += 0.03f;
                else if(hight =="z" && direc =="U")
                    enemyposition.z -= 0.03f;//distance
                else
                    enemyposition.z += 0.03f;
                enemy[enemynumber].transform.position = enemyposition;
            }
            else
            {
                cc = 0;
            }
        }
    }



}
