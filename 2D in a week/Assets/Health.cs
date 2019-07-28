using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public PlayerCollisions playerCollisions;
    public int hp = 3;
    public Image im;
    public Sprite fullHealth;
    public Sprite twoHealth;
    public Sprite oneHealth;
    public Sprite noHealth;
    public Animator am;

    // Start is called before the first frame update
    void Start()
    {
        playerCollisions = FindObjectOfType<PlayerCollisions>();
        am = GetComponent<Animator>();
        im.sprite = fullHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Reducing hp accordingly.
        if(playerCollisions.deductLife)
        {
            am.SetBool("isHurt", true);
            hp -= 1;
            playerCollisions.deductLife = false;
        }

        //Changing the sprite according to the hp.
        if (hp == 3)
        {
            im.sprite = fullHealth;
        }
        else if (hp == 2)
        {
            im.sprite = twoHealth;
        }
        else if (hp == 1)
        {
            im.sprite = oneHealth;
        }
        else if(hp == 0)
        {
            im.sprite = noHealth;
        }

    }
}
