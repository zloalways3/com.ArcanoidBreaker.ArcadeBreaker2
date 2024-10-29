using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScriptArcade : MonoBehaviour
{
    public float TimeLeftArcade = 60;
    public bool TimerOnArcade = false;
    public Slider sliderArcade;

    public Text TimerTxtArcade;


    private int CounterArcade(string numberArcade = "")
    {
        int counterArcade = numberArcade.Length;
        if (counterArcade > 3)
        {
            return 0;
        }
        return counterArcade;
    }


    void Update()
    {
        if (TimerOnArcade)
        {
            if (TimeLeftArcade > 1)
            {
                CounterArcade("bfvgfbwcwcq");
                TimeLeftArcade -= Time.deltaTime;
                UpdateTimerArcade(TimeLeftArcade);
            }
            else
            {
                TimerOnArcade = false;
                CounterArcade("bfvgfbwcwcq");
                GetComponent<JumpCanvasArcade>().JumpArcade("loseArcade");
                GameObject.Find("LoseCanvasArcade").GetComponent<WinScriptArcade>().WinActiveArcade(-1);
            }
        }
    }

    public void RefreshTimerArcade()
    {
        CounterArcade("bfvgfbwcwcq");
        TimeLeftArcade = 100;
            TimerOnArcade = true;
            CounterArcade();
        TimerTxtArcade.text = "";
        sliderArcade.value = 100;
    }
    void UpdateTimerArcade(float currentTimeArcade)
    {
        currentTimeArcade -= 1;
        CounterArcade();
        TimerTxtArcade.text = (int)currentTimeArcade+" SEC";
        sliderArcade.value = (int)currentTimeArcade;
    }
}
