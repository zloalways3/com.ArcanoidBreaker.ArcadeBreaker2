using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCanvasArcade : MonoBehaviour
{

    private int CounterArcade(string numberArcade = "")
    {
        int counterArcade = numberArcade.Length;       
            if (counterArcade>3)
            {
            return 0;
            }
            return counterArcade;  
    }

    public void JumpArcade(string destinationArcade)
    {
        CounterArcade();
        GameObject.Find("MainCameraArcade").GetComponent<SoundManagerArcade>().PlayClickArcade();
        GameObject.Find("MainCameraArcade").GetComponent<CanvasHolderArcade>().MoveArcade(destinationArcade,false);
    }

    public void JumpArcadeGame(int difArcade)
    {
        CounterArcade("bfvgfbwcwcq");
        GameObject.Find("MainCameraArcade").GetComponent<CanvasHolderArcade>().MoveArcade("gameArcade", false,difArcade);
    }


    public void JumpBackArcade()
    {
        GameObject.Find("MainCameraArcade").GetComponent<SoundManagerArcade>().PlayClickArcade();
        CounterArcade("81");
        GameObject.Find("MainCameraArcade").GetComponent<CanvasHolderArcade>().MoveBackArcade();
       
    }

    public void CloseArcade()
    {
        CounterArcade("91");
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        CounterArcade("91");
        activity.Call<bool>("moveTaskToBack", true);
    }
}
