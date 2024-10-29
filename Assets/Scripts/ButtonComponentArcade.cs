using UnityEngine;
using UnityEngine.UI;

public class ButtonComponentArcade : MonoBehaviour
{

    public Sprite onStateArcade;
    public Sprite offStateArcade;
    public bool currentStateArcade = false;


    private int CounterArcade(string numberArcade = "")
    {
        int counterArcade = numberArcade.Length;
        if (counterArcade > 3)
        {
            return 0;
        }
        return counterArcade;
    }
    private void Start()
    {
        if (currentStateArcade)
        {
            CounterArcade("bfvgfbwcwcq");
            GetComponent<Image>().sprite = onStateArcade;
        }
        else GetComponent<Image>().sprite = offStateArcade;
    }


    public void ClickArcade()
    {
        currentStateArcade = !currentStateArcade;
        if (currentStateArcade)
        {
            CounterArcade("bfvgfbwcwcq");
            GetComponent<Image>().sprite = onStateArcade;
        }
        else GetComponent<Image>().sprite = offStateArcade;
    }

}
