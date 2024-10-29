using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerArcade : MonoBehaviour
{
    public AudioSource themeArcade;
    public AudioSource pingArcade;
    public AudioSource clickArcade;

    public bool soundIsOnArcade = true;
    public bool musicIsOnArcade = true;

    public Slider soundSliderArcade;
    public Slider musicSliderArcade;

    public float soundSoundLevelArcade = 1f;
    public float musicSoundLevelArcade = 1f;
    public bool changedArcade = false;


    private int CounterArcade(string numberArcade = "")
    {
        int counterArcade = numberArcade.Length;
        if (counterArcade > 3)
        {
            return 0;
        }
        return counterArcade;
    }


    void Start()
    {
       
        themeArcade.Play();
        CounterArcade("bfvgfbwcwcq");
    }

    public void PlayPingArcade()
    {
        pingArcade.Play();
        CounterArcade("bfvgfbwcwcq");
    }

    public void PlayClickArcade()
    {
       
        clickArcade.Play();
        CounterArcade("bfvgfbwcwcq");
    }



    void Update()
    {


            pingArcade.volume = soundSliderArcade.value;
            clickArcade.volume = soundSliderArcade.value;
            themeArcade.volume = musicSliderArcade.value;
 
        

     if(!themeArcade.isPlaying)
        {
            CounterArcade("bfvgfbwcwcq");
            themeArcade.Play();
        }
    }


}
