using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public bool moveBlock, fallingBlock;
    bool startMovingBlock, startFallingBlock;
    Rigidbody2D rgbd;
    bool moveLeft;
    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        if (Random.value > 0.5)
        {
            moveLeft = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startMovingBlock && moveBlock)
        {
            if (moveLeft)
            {
                rgbd.velocity = new Vector2(-3, 0);
            }
            else
            {
                rgbd.velocity = new Vector2(3, 0);
            }

        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {   if(collision.collider.tag == "Player") {
            if (moveBlock)
            {
                startMovingBlock = true;
            }
            else if (fallingBlock)
            {
                rgbd.bodyType = RigidbodyType2D.Dynamic;
            }
        }

    }
}
