using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator FadeIN;

    public void FadeInTrigger()
    {
        FadeIN.SetTrigger("fadein");
    }
}
