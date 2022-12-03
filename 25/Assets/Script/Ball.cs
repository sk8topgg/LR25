using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{    Rigidbody2D rgbd;
    public Vector2 maxForce;
    
    public float forceAppliedInSidewaysDirection;
    public bool moving;
      
    float sidewaysMovement;
    BallFuctionality ballFuctionality;
    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        ballFuctionality = GetComponent<BallFuctionality>();
    }

    // Update is called once per frame
    void Update()
    {
        // clampVeclocity();
      //  Debug.Log(rgbd.velocity);
        movement();
    }
    public void FixedUpdate()
    {
        if (!moving)
        {
            Vector2 vel = rgbd.velocity;
            vel.x = Mathf.Lerp(vel.x, 0, 0.2f);
            rgbd.velocity = vel;
        }
    }
    void clampVeclocity()
    {
        Vector2 vel = rgbd.velocity;

        if (Mathf.Abs(vel.x) >= maxForce.x)
        {
            vel.x = maxForce.x * Mathf.Sign(rgbd.velocity.x);
        }
        if ((vel.y) >= maxForce.y)
        {   if (ballFuctionality.jumpHigher) return;
            vel.y = maxForce.y;
        }
        rgbd.velocity = vel;
    }
    void movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rgbd.AddForce(new Vector2(-forceAppliedInSidewaysDirection, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rgbd.AddForce(new Vector2(forceAppliedInSidewaysDirection, 0));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moving = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            moving = false;
        }
    }
}
