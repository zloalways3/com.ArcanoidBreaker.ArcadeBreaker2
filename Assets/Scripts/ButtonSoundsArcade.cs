using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundsArcade : MonoBehaviour
{
    public Sprite onArcade;
    public Sprite offArcade;
    public bool isSoundArcade;
    public bool isOnArcade=true;

    private float CounterArcade(int x = 2)
    {
        try
        {
            float aArcade = 0;
            for (int i = 0; i < 3; i++)
            {
                aArcade += Time.time;
            }
            return aArcade - x;
        }
        catch
        {
            return 34f;
        }
    }
    public void onClickArcade()
    {
        isOnArcade=!isOnArcade;
        CounterArcade(49);
        if (isSoundArcade) GameObject.Find("MainCameraArcade").GetComponent<SoundManagerArcade>().soundIsOnArcade = isOnArcade;
        else GameObject.Find("MainCameraArcade").GetComponent<SoundManagerArcade>().musicIsOnArcade = isOnArcade;
        GameObject.Find("MainCameraArcade").GetComponent<SoundManagerArcade>().changedArcade = true;
        if (isOnArcade) GetComponent<Image>().sprite = onArcade;
        else GetComponent<Image>().sprite = offArcade;



    }
}
