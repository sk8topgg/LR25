using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsObject : MonoBehaviour
{
    Transform[] childObj;

    public GameObject Points1;
    public int force;
    public bool hasBroke;
   public void Explode()
    {
        hasBroke = true;
        Points1.SetActive(true);
        Points1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Points1.GetComponent<Rigidbody2D>().AddForceAtPosition(Vector2.up * force * 3 / 2, Points1.transform.position);
        foreach (Transform t in transform)
        {
            Rigidbody2D rgbd = t.GetComponent<Rigidbody2D>();
            if (rgbd != null)
            {
                //shake camera 
                rgbd.bodyType = RigidbodyType2D.Dynamic;
                rgbd.AddForceAtPosition(Vector2.up * force, 
                    new Vector2(Random.Range(t.position.x - 2, t.position.x + 2), t.position.y));
                //play sound
            }

        }
    }
}
