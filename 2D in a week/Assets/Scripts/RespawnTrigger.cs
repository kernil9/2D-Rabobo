using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    public GameManager gm;

    void OnTriggerEnter2D(Collider2D collision)
    {
        gm.EndGame();
    }
}
