using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class achiv : MonoBehaviour
{
    public static Animation anim;
    public Text achivmentname;
    public static string achivmenttext;

    // Use this for initialization
    int i = 0;
    void Start()
    {
        anim = GetComponent<Animation>();
        achivmenttext = "Test Achivment";
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.animation == 1)
            {
            
                achivmentname.text = achivmenttext;
                gameObject.GetComponent<Animation>().Play();
                PlayerController.animation = 0;
        }



    }
}
