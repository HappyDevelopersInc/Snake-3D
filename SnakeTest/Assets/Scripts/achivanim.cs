using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class achivmentanim : MonoBehaviour
{
    public static Animator anim;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.animation == 1)
        {
            anim.SetBool("Achivment", true);
            PlayerController.animation = 0;
        }

    }
}
