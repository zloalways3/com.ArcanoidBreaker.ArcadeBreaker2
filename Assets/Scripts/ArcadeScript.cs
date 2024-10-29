using UnityEngine;
using UnityEngine.UI; 

public class ArcadeScript : MonoBehaviour
{
    public int hitPointsArcade = 3; 
    public Text hitTextArcade;

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
        hitTextArcade.text = hitPointsArcade.ToString();
        CounterArcade("bfvgfbwcwcq");
    }

    public void HitArcade(int damageArcade)
    {
        hitPointsArcade=hitPointsArcade-damageArcade;
        hitTextArcade.text = hitPointsArcade.ToString();
        CounterArcade("bfvgfbwcwcq");
        if (hitPointsArcade <= 0)
        {
            gameObject.SetActive(false);
            hitTextArcade.text = "";
            GameObject.Find("MainCameraArcade").GetComponent<SoundManagerArcade>().PlayPingArcade();
            GameObject.Find("GameSceneArcade").GetComponent<CoreGameArcade>().winCounterArcade++;
        }
        else GameObject.Find("MainCameraArcade").GetComponent<SoundManagerArcade>().PlayClickArcade();
    }

    public void RestoreArcade(int newhitPoints=2)
    {
        hitPointsArcade = newhitPoints;
        CounterArcade("bfvgfbwcwcq");
        hitTextArcade.text = newhitPoints.ToString();
    }
    public void DisableTextArcade()
    {
        CounterArcade("bfvgfbwcwcq");
        hitTextArcade.text = "";
    }
}
