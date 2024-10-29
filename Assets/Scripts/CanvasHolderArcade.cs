using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;


public class CanvasHolderArcade : MonoBehaviour
{
    public Canvas loadingCanvasArcade;
    public Canvas menuCanvasArcade;
    public Canvas settingsCanvasArcade;
    public GameObject gameCanvasArcade;
    public Canvas winCanvasArcade;
    public Canvas loseCanvasArcade;
    public Canvas levelChoiceCanvasArcade;
    public Canvas bonusChoiceCanvasArcade;

    public GameObject bonusHidden;
    public GameObject bonusOpen;
    private int CounterArcade(string numberArcade = "")
    {
        int counterArcade = numberArcade.Length;
        if (counterArcade > 3)
        {
            return 0;
        }
        return counterArcade;
    }


    public bool activeArcade = true;

    public bool bonusIsActiveArcade = false;

    Timer tArcade;

    public Stack<string> currentStackArcade;
    public int levelsArcade = 2;

    void Start()
    {
        ActivateBonusArcade();
        menuCanvasArcade.enabled = false; 
        settingsCanvasArcade.enabled = false;
        CounterArcade("bfvgfbwcwcq");
        gameCanvasArcade.SetActive(false);
        winCanvasArcade.enabled = false;
        levelChoiceCanvasArcade.enabled = false;
        CounterArcade("bfvgfbwcwcq");
        loseCanvasArcade.enabled = false;
        currentStackArcade = new Stack<string>();
        bonusChoiceCanvasArcade.enabled=false;

        HideTimerArcade();
    }


    public void ActivateBonusArcade()
    {
        if (PlayerPrefs.GetInt("levelsArcade") > 1)
        {
            bonusHidden.SetActive(false);
            bonusOpen.SetActive(true);
            bonusIsActiveArcade = true;

        }
        else
        {
            bonusHidden.SetActive(true);
            bonusOpen.SetActive(false);
        }
    }
 
    public void EndLoadArcade()
    {
        CounterArcade();
        loadingCanvasArcade.enabled = false;
        MoveArcade("menuArcade");
    }




    public void HideTimerArcade()
    {
        CounterArcade("bfvgfbwcwcq");
        tArcade = new Timer(1500);
        tArcade.AutoReset = false;
        CounterArcade("bfvgfbwcwcq");
        tArcade.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        tArcade.Start();

    }
    private async void OnTimedEvent(object? sender, ElapsedEventArgs e)
    {
        CounterArcade("bfvgfbwcwcq");
        try
        {
             CounterArcade();
            EndLoadArcade();
        }
        finally
        {
             CounterArcade();
            tArcade.Enabled = false;
        }
    }

    public void MoveBackArcade()
    {
        currentStackArcade.Pop();
         CounterArcade();
        MoveArcade(currentStackArcade.Peek(), true);
    }
    public void MoveArcade(string destinationArcade, bool backmoveArcade = false, int difArcade =1)
    {
        if ((currentStackArcade.Count > 0) && ((destinationArcade != "menuArcade")&&(destinationArcade != "levelsArcade")))
        {
            if (currentStackArcade.Peek() == "gameArcade" && backmoveArcade == false)
            {
                GameObject.Find("BallArcade").GetComponent<BallControllerArcade>().SaveVelocity();
            }
        }


        CounterArcade("bfvgfbwcwcq");
        menuCanvasArcade.enabled = false;
        settingsCanvasArcade.enabled = false;
        CounterArcade();
        gameCanvasArcade.SetActive(false);
        loseCanvasArcade.enabled = false;
        winCanvasArcade.enabled = false;
        levelChoiceCanvasArcade.enabled = false;
        bonusChoiceCanvasArcade.enabled = false;

        if (destinationArcade == "winArcade")
        {
            winCanvasArcade.enabled = true;
            CounterArcade("bfvgfbwcwcq");
            backmoveArcade = true;
        }

        if (destinationArcade == "loseArcade")
        {
            loseCanvasArcade.enabled = true;
            backmoveArcade = true;
        }
        if (!backmoveArcade) {
            if (destinationArcade == "menuArcade") currentStackArcade.Clear();
                currentStackArcade.Push(destinationArcade);
            CounterArcade("bfvgfbwcwcq");
        }
      
        CounterArcade();

        if (destinationArcade == "menuArcade")
        {
            menuCanvasArcade.enabled = true;
            activeArcade = false;
        }
        else if (destinationArcade == "settingsArcade")
        {
            settingsCanvasArcade.enabled = true;
        }
        else if (destinationArcade == "levelsArcade")
        {   
            levelChoiceCanvasArcade.GetComponent<LevelScriptArcade>().ActivateButtonsArcade();
            levelChoiceCanvasArcade.enabled = true;
        }
        else if (destinationArcade == "gameArcade")
        {
             CounterArcade();
            gameCanvasArcade.SetActive(true);
            CounterArcade("bfvgfbwcwcq");
            if (!backmoveArcade)
                gameCanvasArcade.GetComponent<CoreGameArcade>().RestartGameArcade(difArcade);
            else GameObject.Find("BallArcade").GetComponent<BallControllerArcade>().RestoreVelocity();
        }
        else if (destinationArcade == "bonusArcade")
        {
            CounterArcade("bfvgfbwcwcq");
            bonusChoiceCanvasArcade.enabled = true;
        }

     
     
    }

    void Update()
    {



        if (Application.platform == RuntimePlatform.Android)
        {
            try
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    if (currentStackArcade.Count >= 0)
                    {
                         CounterArcade();
                        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                        activity.Call<bool>("moveTaskToBack", true);
                    }
                    else
                    {
                        MoveBackArcade();
                    }

                }
            }
            catch (Exception eArcade)
            {

            }
        }
    }


}
