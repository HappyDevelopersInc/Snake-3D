using UnityEngine;
using System.Collections;
using System;

public class Apple : MonoBehaviour {


    public static float RandomAppleX = 0;
    public static float RandomAppleZ = 0;
    public static float RandomEnemyX = 0;
    public static float RandomEnemyZ = 0;
    public static int countlevel = 0;
    public static int secoundcountlevel = 0;
    public static int generate = 0;
    public static int redapple = 1;
    public static int greenapple = 2;
    public static int purpleapple = 3;
    public static int goldapple = 5;
    public static GameObject ground;
    public static GameObject ground2;
    public GameObject apple;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    void OnTriggerEnter(Collider other)
    {
        other = apple.GetComponent<Collider>();
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Tail"))
        {
            RandomApple();
        }
    }
    public static void RandomApple()//function that generates new object each time it's called.
    {
        switch (Application.loadedLevel)
        {

            case 3:
                {
                    if (generate % 4 == 0)
                    {
                        LocationOfApple(-0.2f, 4.6f, 5f, 9f);
                    }
                    else
                        DefaultAppleLocation();
                    break;
                }
            case 4:
                {
                    if (generate % 4 == 0)
                    {
                        LocationOfApple(-4f, 4.6f, 5f, 9f);
                    }
                    else
                        DefaultAppleLocation();
                    break;
                }
            case 5:
                {
                    if (generate % 4 == 0)
                    {
                        if (countlevel == 0)
                        {
                            countlevel = 1;
                            LocationOfApple(-6.2f, -2.2f, 5f, 9f);
                        }
                        else
                        {
                            countlevel = 0;
                            LocationOfApple(2.3f, 6.3f, 5f, 9f);
                        }
                    }
                    else
                        DefaultAppleLocation();
                    break;
                }
            case 6:
                {
                    if (generate % 4 == 0)
                        LocationOfApple(-6.5f, 6.5f, 4.5f, -4.5f);
                    else
                        DefaultAppleLocation();
                    break;
                }
            case 7:
                {
                    if (generate % 4 == 0)
                    {
                        LocationOfApple(2.3f, 6.3f, 5f, 9f);
                    }
                    else
                        DefaultAppleLocation();
                    break;
                }
            case 8:
                {
                    if (generate % 4 == 0)
                    {
                        if (countlevel == 0)
                        {
                            countlevel = 1;
                            LocationOfApple(2.23f, 6.37f, 5f, 9f);
                        }
                        else
                        {
                            countlevel = 0;
                            LocationOfApple(4.5f, 8.15f, 4f, 1.22f);
                        }
                    }
                    else
                        LocationOfApple(-6.4f, 3.3f, 4.17f, -4.16f);
                    break;
                }
            case 9:
                {
                    if (generate % 4 == 0)
                    {

                        if (countlevel == 0)
                        {
                            countlevel = 1;
                            LocationOfApple(-2.0f, 2.7f, 5.3f, 9f);
                        }
                        else if (countlevel == 1)
                        {
                            countlevel = 2;
                            LocationOfApple(-8.9f, -3.25f, 1.3f, 4f);
                        }
                        else
                        {
                            countlevel = 0;
                            LocationOfApple(3.57f, 9f, 1.3f, 4f);
                        }
                    }

                    else
                    {
                        secoundcountlevel = 0;
                        LocationOfApple(-1.8f, 2.6f, 0.3f, 4.3f);
                    }
                    break;

                }
            case 10:
                {
                    if (generate % 4 == 0)
                    {

                        if (countlevel == 0)
                        {
                            countlevel = 1;
                            LocationOfApple(-6.0f, 2.0f, 5.8f, 8.5f);
                        }
                        else if (countlevel == 1)
                        {
                            countlevel = 2;
                            LocationOfApple(3.2f, 6.3f, -0.5f, 8.5f);
                        }
                        else
                        {
                            countlevel = 0;
                            LocationOfApple(-2.8f, 6f, -3.5f, 1.7f);
                        }
                    }

                    else
                    {
                        secoundcountlevel = 0;
                        LocationOfApple(-1.78f, 1.7f, 0.5f, 3.5f);
                    }
                    break;

                }

            default:
                {
                    DefaultAppleLocation();
                    break;
                }
        }

        switch (Application.loadedLevel)
        {
            case 1:
                {
                    ApplePlacement(redapple);
                    break;
                }
            case 2:
                {
                    ApplePlacement(redapple, greenapple);
                    break;
                }
            case 3:
                {
                    ApplePlacement(redapple, greenapple);
                    break;
                }
            case 4:
                {
                    ApplePlacement(redapple, greenapple);
                    break;
                }
            case 5:
                {
                    ApplePlacement(redapple, greenapple, purpleapple);
                    break;
                }
            case 6:
                {
                    ApplePlacement(redapple, greenapple, purpleapple);
                    break;
                }
            case 7:
                {
                    ApplePlacement(greenapple, purpleapple);
                    break;
                }
            case 8:
                {
                    ApplePlacement(greenapple, purpleapple, goldapple);
                    break;
                }
            case 9:
                {
                    ApplePlacement(purpleapple, goldapple);
                    break;
                }
            case 10:
                {
                    ApplePlacement(purpleapple, goldapple);
                    break;
                }
        }
    }
    public static void LocationOfApple(float applex1, float applex2, float applez1, float applez2)
    {

        float bnddelta = 2f;
        if (generate % 4 == 0)
        {
            RandomAppleX = UnityEngine.Random.Range(applex1, applex2);
            RandomAppleZ = UnityEngine.Random.Range(applez1, applez2);
            //Node<BodyPart> temp2 = Head;
            //while (temp2 != null)
            //{

            //    while (Math.Abs(RandomAppleX - temp2.GetInfo().GetX()) < bnddelta && Math.Abs(RandomAppleZ - temp2.GetInfo().GetY()) < bnddelta && Math.Abs(RandomEnemyX - temp2.GetInfo().GetX()) < 0.8f && Math.Abs(RandomEnemyZ - temp2.GetInfo().GetY()) < 0.8f)
            //    {
            //        RandomAppleX = UnityEngine.Random.Range(applex1, applex2);
            //        RandomAppleZ = UnityEngine.Random.Range(applez1, applez2);
            //    }

            //    temp2 = temp2.GetNext();
            //}
        }
        else
        {
            DefaultAppleLocation();
        }

    }
    public static void DefaultAppleLocation()
    {
        float bnddelta = 2f;
        RandomAppleX = UnityEngine.Random.Range(-(ground.GetComponent<Renderer>().bounds.size.x / 2) + bnddelta, (ground.GetComponent<Renderer>().bounds.size.x / 2) - bnddelta);
        RandomAppleZ = UnityEngine.Random.Range(-(ground.GetComponent<Renderer>().bounds.size.z / 2) + bnddelta, (ground.GetComponent<Renderer>().bounds.size.z / 2) - bnddelta);
        //Node<BodyPart> temp = Head;
        //while (temp != null)
        //{

        //    while (Math.Abs(RandomAppleX - temp.GetInfo().GetX()) < bnddelta && Math.Abs(RandomAppleZ - temp.GetInfo().GetY()) < bnddelta && Math.Abs(RandomEnemyX - temp.GetInfo().GetX()) < 0.8f && Math.Abs(RandomEnemyZ - temp.GetInfo().GetY()) < 0.8f)
        //    {
        //        RandomAppleX = UnityEngine.Random.Range(-(ground.GetComponent<Renderer>().bounds.size.x / 2) + bnddelta, (ground.GetComponent<Renderer>().bounds.size.x / 2) - bnddelta);
        //        RandomAppleZ = UnityEngine.Random.Range(-(ground.GetComponent<Renderer>().bounds.size.z / 2) + bnddelta, (ground.GetComponent<Renderer>().bounds.size.z / 2) - bnddelta);
        //    }

        //    temp = temp.GetNext();
        //}
    }
    public static int ApplePlacement(int Apple1, int Apple2 = 0, int Apple3 = 0)
    {


        if (generate % 8 == 0)
        {
            if (Apple3 == 0)
            {
                SetAppleTag(Apple1);
                return Apple1;
            }
            else
            {
                SetAppleTag(Apple3);
                return Apple3;
            }

        }
        else if (generate % 5 == 0 && Apple2 != 0)
        {

            SetAppleTag(Apple2);
            return Apple2;
        }
        else
        {
            SetAppleTag(Apple1);
            return Apple1;
        }

    }
    public static void SetAppleTag(int appletype)
    {
        float applesize = 1.5f;
        GameObject Apple = (GameObject)Instantiate(Resources.Load("Apple"));
        Apple.transform.position = new Vector3(RandomAppleX, 3f, RandomAppleZ);//each time the function called then,instansiate new object at random postion.
        MeshRenderer rend = Apple.GetComponent<MeshRenderer>();
        Apple.transform.localScale += new Vector3(applesize, applesize, applesize);
        SphereCollider spcolider = Apple.gameObject.AddComponent<SphereCollider>();// (SphereCollider)Apple.gameObject.AddComponent(typeof(SphereCollider));
        switch (appletype)
        {

            case 2:
                {

                    foreach (var child in Apple.GetComponentsInChildren<Renderer>())
                        child.material.color = Color.green;
                    Apple.tag = "GreenApple";
                    Apple.transform.localScale += new Vector3(applesize, applesize, applesize);
                    spcolider.center = new Vector3(0.14f, 0.04f, -0.045f);
                    spcolider.radius = 0.05418529f;

                    break;
                }
            case 3:
                {
                    foreach (var child in Apple.GetComponentsInChildren<Renderer>())
                        child.material.color = new Color(148, 0, 211);

                    Apple.tag = "PurpleApple";
                    Apple.transform.localScale += new Vector3(applesize, applesize, applesize);
                    spcolider.center = new Vector3(0.14f, 0.04f, -0.045f);
                    spcolider.radius = 0.05418529f;
                    break;
                }
            case 5:
                {
                    foreach (var child in Apple.GetComponentsInChildren<Renderer>())
                        child.material.color = Color.yellow;

                    Apple.tag = "GoldApple";
                    Apple.transform.localScale += new Vector3(applesize, applesize, applesize);
                    spcolider.center = new Vector3(0.14f, 0.04f, -0.045f);
                    spcolider.radius = 0.05418529f;
                    break;
                }
            default:
                {
                    rend.material.color = Color.blue;
                    Apple.tag = "RedApple";
                    Apple.transform.localScale += new Vector3(applesize, applesize, applesize);
                    Apple.transform.position = new Vector3(RandomAppleX, 3f, RandomAppleZ);
                    spcolider.center = new Vector3(0.135f, 0.04f, -0.05f);
                    spcolider.radius = 0.05622346f;

                    break;
                }


        }

    }
}
