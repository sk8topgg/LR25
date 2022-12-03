using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFuctionality : MonoBehaviour
{
    Rigidbody2D rgbd;
    public float forceAppliedInUpwardDirection, higherForceAppliedInUpwardDirection;

    public bool jumpHigher;
    Manager manager;

    public bool hasElectricity;
    SpriteRenderer sr;
    public Color electricitySprite;
    Color originalColor;
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        score = FindObjectOfType<Score>();
        originalColor = sr.color;
        manager = FindObjectOfType<Manager>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {   if (!manager.startGame) return;
        if (collision.collider.tag == "JumpingBlock")
        {
            if (jumpHigher)
            {
                Debug.Log("Applying higher force");
                rgbd.AddForce(new Vector2(0, higherForceAppliedInUpwardDirection));
                jumpHigher = false;
            }
            else
            {
                rgbd.AddForce(new Vector2(0, forceAppliedInUpwardDirection));
            }

        }
        if (collision.collider.tag == "ElectricityBlock")
        {   //gameover
            if (hasElectricity) {
                rgbd.AddForce(new Vector2(0, forceAppliedInUpwardDirection)); return; }
            else
            {
                Debug.Log("Dead");
                manager.RestartTheGame();
            }
           
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!manager.startGame) return;
        if (collision.tag == "spring")
        {
            jumpHigher = true;
            Destroy(collision.gameObject);
        }
        if (collision.tag == "TimeSlower")
        {
            //call function to slow the game
            manager.slowTimerStart();
            Destroy(collision.gameObject);
        }if (collision.tag == "TimeFaster")
        {
            //call function to slow the game
            manager.FastTimerStart();
            Destroy(collision.gameObject);
        }if (collision.tag == "ElectricityPower")
        {
            //change the sprite to charge sprite
            //screen flashes
            Destroy(collision.gameObject);
            StartCoroutine(electricity());
        }
        if (collision.tag == "PointObject")
        {
            //add point
            if (!collision.GetComponent<PointsObject>().hasBroke)
            {
                score.AddScore();

            }

            collision.GetComponent<PointsObject>().Explode();

        }

    }
    IEnumerator electricity()
    {
        hasElectricity = true;
        sr.color = electricitySprite;
        yield return new WaitForSeconds(2f);
        hasElectricity = false;
        sr.color = originalColor;

    }
}
