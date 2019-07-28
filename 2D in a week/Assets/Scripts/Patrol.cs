using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private bool movingLeft = true;
    public Transform groundDetection;
    public float rayDistance = 2f;
    public Collider2D cld;
    public bool gotHit = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Patroling using Raycasting
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position,Vector2.down, rayDistance);

        if(groundInfo.collider == false)
        {
            if(movingLeft == true)
            {
                transform.eulerAngles = new Vector3(0,-180,0);
                movingLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingLeft = true;
            }
        }

        //Checking if we hit the player
        if (gotHit)
        {
           
            gotHit = false;
        }
        else
        {
            enableCollider();
        }

    }

    //Disable collider to avoid getting hit twice.
    void disableCollider()
    {
        cld.enabled = false;
    }

    //Enabling collider.
    void enableCollider()
    {
        cld.enabled = true;
    }

    //collisions -----
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            disableCollider();
            gotHit = true;
        }
    }

}
