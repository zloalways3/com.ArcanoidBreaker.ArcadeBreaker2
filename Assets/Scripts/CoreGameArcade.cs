using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreGameArcade : MonoBehaviour
{

    public Text LevelTextArcade;
    public int winCounterArcade = 0;
    bool winOnceArcade = false;
    int currentLevelArcade = -1;
    int goalPointsArcade = 16;
 

    public GameObject brickArcade1;
    public GameObject brickArcade2;
    public GameObject brickArcade3;
    public GameObject brickArcade4;
    public GameObject brickArcade5;
    public GameObject brickArcade6;
    public GameObject brickArcade7;
    public GameObject brickArcade8;
    public GameObject brickArcade9;
    public GameObject brickArcade10;
    public GameObject brickArcade11;
    public GameObject brickArcade12;
    public GameObject brickArcade13;
    public GameObject brickArcade14;
    public GameObject brickArcade15;
    public GameObject brickArcade16;
    public GameObject brickArcade17;
    public GameObject brickArcade18;
    public GameObject brickArcade19;
    public GameObject brickArcade20;

    List<GameObject> BricksArcade;


    private int CounterArcade(string numberArcade = "")
    {
        int counterArcade = numberArcade.Length;
        if (counterArcade > 3)
        {
            return 0;
        }
        return counterArcade;
    }

    public void RestartGameArcade(int levelArcade = 1)
    {
        currentLevelArcade = levelArcade;
        BricksArcade = new List<GameObject>
        {
             brickArcade1,
             brickArcade2,
             brickArcade3,
             brickArcade4,
             brickArcade5,
             brickArcade6,
             brickArcade7,
             brickArcade8,
             brickArcade9,
             brickArcade10,
             brickArcade11,
             brickArcade12,
             brickArcade13,
             brickArcade14,
             brickArcade15,
             brickArcade16,
             brickArcade17,
             brickArcade18,
             brickArcade19,
             brickArcade20
        };
        CounterArcade("bfvgfbwcwcq");
        GetComponent<TimerScriptArcade>().RefreshTimerArcade();
        LevelTextArcade.text = "Level "+ levelArcade.ToString();
        int powerArcade = 2;
        if (GameObject.Find("MainCameraArcade").GetComponent<CanvasHolderArcade>().bonusIsActiveArcade)
        {
            if (GameObject.Find("ButtonPowerX2OnArcade").GetComponent<ButtonComponentArcade>().currentStateArcade)
            {
                powerArcade = 4;
            }
            if (GameObject.Find("ButtonPowerX3OnArcade").GetComponent<ButtonComponentArcade>().currentStateArcade)
            {
                powerArcade = 6;
            }
            if (GameObject.Find("ButtonPowerX5OnArcade").GetComponent<ButtonComponentArcade>().currentStateArcade)
            {
                powerArcade = 10;
                CounterArcade("bfvgfbwcwcq");
            }
        }
        GameObject.Find("BallArcade").GetComponent<BallControllerArcade>().StartBallArcade(powerArcade);
        int count = 0;
        foreach (var Arcade in BricksArcade)
        {
            if (count < 16) Arcade.SetActive(true);
            else if (levelArcade%2==0) Arcade.SetActive(true);
            else
            {
                Arcade.SetActive(false);
                Arcade.GetComponent<ArcadeScript>().DisableTextArcade();
            }

            if (Arcade.activeSelf)
            {
                var hitArcade = 4;

                if(count%4==0 && count<16 && levelArcade>2) { hitArcade = 3 + levelArcade; }

                Arcade.GetComponent<ArcadeScript>().RestoreArcade(hitArcade);

            }

            count++;
        }
        CounterArcade("bfvgfbwcwcq");
        winCounterArcade = 0;
        winOnceArcade = false;
        if (levelArcade % 2 == 0) goalPointsArcade = 20;
        else goalPointsArcade = 16;
    }


    private void Update()
    {
        if (!winOnceArcade&&winCounterArcade>=goalPointsArcade)
        {
            winOnceArcade= true;
            winCounterArcade = 0;
            CounterArcade("bfvgfbwcwcq");
            GetComponent<JumpCanvasArcade>().JumpArcade("winArcade");
            GameObject.Find("WinCanvasArcade").GetComponent<WinScriptArcade>().WinActiveArcade(currentLevelArcade);
        }
    }


}
