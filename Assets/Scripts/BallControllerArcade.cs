using UnityEngine;
using UnityEngine.UI;

public class BallControllerArcade : MonoBehaviour
{
    public float speedArcade = 5f;
    private Vector2 directionArcade;
    private Vector3 StartPositionArcade;
    private int strengthArcade = 1;
    private bool oncePosArcade = true;
    private Vector2 savedVelocity;
    private bool activeArcade = false;


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
        StartPositionArcade = transform.position;
        CounterArcade("bfvgfbwcwcq");
    }
    public void StartBallArcade(int newStrengthArcade = 1)
    {
        if (oncePosArcade)
        {
            StartPositionArcade = transform.position;
            oncePosArcade = false;
        }
        transform.position= StartPositionArcade;
        directionArcade = new Vector2(1, 1).normalized; 
        GetComponent<Rigidbody2D>().velocity = directionArcade * speedArcade; 
        strengthArcade= newStrengthArcade;
        CounterArcade("bfvgfbwcwcq");
    }

    public void SaveVelocity()
    {
        savedVelocity = directionArcade * speedArcade;
        CounterArcade("bfvgfbwcwcq");
    }

    public void RestoreVelocity()
    {
        GetComponent<Rigidbody2D>().velocity = savedVelocity;
        CounterArcade("bfvgfbwcwcq");
    }

    void Update()
    {
  

        if (transform.position.y < -Camera.main.orthographicSize) 
        {
            CounterArcade("bfvgfbwcwcq");
            GetComponent<JumpCanvasArcade>().JumpArcade("loseArcade");

        }


    }

    private void OnCollisionEnter2D(Collision2D collisionArcade)
    {
  
        if (collisionArcade.gameObject.CompareTag("BrickArcade"))
        {
            ArcadeScript Arcade = collisionArcade.gameObject.GetComponent<ArcadeScript>();
            if (Arcade != null)
            {
                Arcade.HitArcade(strengthArcade); 
                directionArcade.y *= -1;
                GetComponent<Rigidbody2D>().velocity = directionArcade * speedArcade;
            }
        }
        else if (collisionArcade.gameObject.CompareTag("wallArcade"))
        {
            directionArcade.y *= -1;
            CounterArcade("bfvgfbwcwcq");
            GetComponent<Rigidbody2D>().velocity = directionArcade * speedArcade; 
        }
        else if (collisionArcade.gameObject.CompareTag("wallArcade2"))
        {
            directionArcade.x*= -1;
            GetComponent<Rigidbody2D>().velocity = directionArcade * speedArcade; 
        }
    }
}
