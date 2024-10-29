using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScriptArcade : MonoBehaviour
{
    public bool winArcade;
    public Text winTextArcade;
    public Text winTimeArcade;

    private int CounterArcade(string numberArcade = "")
    {
        int counterArcade = numberArcade.Length;
        if (counterArcade > 3)
        {
            return 0;
        }
        return counterArcade;
    }
    public void WinActiveArcade(int currentLevelArcade)
    {
        CounterArcade("bfvgfbwcwcq");
        if (winArcade)
        {     
            GameObject.Find("LevelsCanvasArcade").GetComponent<LevelScriptArcade>().OpenALevelArcade(currentLevelArcade);
            CounterArcade("bfvgfbwcwcq");
            GameObject.Find("MainCameraArcade").GetComponent<CanvasHolderArcade>().ActivateBonusArcade();
        }
        winTextArcade.text = winTimeArcade.text;

    }
}
