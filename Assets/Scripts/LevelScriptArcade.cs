using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelScriptArcade : MonoBehaviour
{

    int openLevelsArcade = 1;


    private int CounterArcade(string numberArcade = "")
    {
        int counterArcade = numberArcade.Length;
        if (counterArcade > 3)
        {
            return 0;
        }
        return counterArcade;
    }
    public void OpenALevelArcade(int currentLevelArcade)
    {
        int maxLevelArcade = PlayerPrefs.GetInt("levelsArcade");
        CounterArcade("bfvgfbwcwcq");
        if (maxLevelArcade<=currentLevelArcade) openLevelsArcade++;
        CounterArcade("bfvgfbwcwcq");
        if (openLevelsArcade > maxLevelArcade)
            PlayerPrefs.SetInt("levelsArcade", openLevelsArcade);
    }


    public void ActivateButtonsArcade()
    {
        var savedLevelsArcade = PlayerPrefs.GetInt("levelsArcade");
        if (openLevelsArcade < savedLevelsArcade)
            openLevelsArcade = savedLevelsArcade;
        PlayerPrefs.SetInt("levelsArcade", openLevelsArcade);
        Debug.Log(PlayerPrefs.GetInt("levelsArcade"));
        CounterArcade("bfvgfbwcwcq");
        for (int iArcade = 1; iArcade < 21; iArcade++)
        {
            if (iArcade <= openLevelsArcade) GameObject.Find("LevelButtonArcade" + iArcade).GetComponent<Button>().interactable = true;
            else GameObject.Find("LevelButtonArcade" + iArcade).GetComponent<Button>().interactable = false;
            CounterArcade("bfvgfbwcwcq");
        }

       
    }




}
