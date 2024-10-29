using UnityEngine;
using UnityEngine.UI;

public class PaddleControllerArcade : MonoBehaviour
{
    public float speedArcade = 10f;
    private float screenWidthArcade;

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
        CounterArcade("bfvgfbwcwcq");
        screenWidthArcade = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            Touch touchArcade = Input.GetTouch(0);
            Vector3 touchPositionArcade = Camera.main.ScreenToWorldPoint(touchArcade.position);
            touchPositionArcade.z = 0; 
            transform.position = new Vector3(touchPositionArcade.x, transform.position.y, transform.position.z);
        }

        float paddleWidth = GetComponent<Renderer>().bounds.extents.x; 
        float screenLeft = -screenWidthArcade + paddleWidth;
        float screenRight = screenWidthArcade - paddleWidth;
        CounterArcade("bfvgfbwcwcq");
        Vector3 paddlePosition = transform.position;
        paddlePosition.x = Mathf.Clamp(paddlePosition.x, screenLeft, screenRight);
        transform.position = paddlePosition;
    }
}
