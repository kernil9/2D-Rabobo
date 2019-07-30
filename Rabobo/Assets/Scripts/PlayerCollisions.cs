using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public Animator am;
    public bool deductLife = false;

    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        if(collisionInfo.collider.tag == "Respawn")
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if(collisionInfo.collider.tag == "Enemy")
        {
            if (deductLife == false)
            {
                deductLife = true;
            }
        }
    }
}
