using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D ct;
    public Animator animator;
    public float runSpeed = 40f;
   
    float hMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        hMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        //Animations - Logic
        animator.SetFloat("Speed", Mathf.Abs(hMove));
        //Checking for jump and crouch
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    public void onCrouching(bool IsCrouching)
    {
        animator.SetBool("IsCrouching", IsCrouching);
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void Hurt()
    {
        animator.SetBool("isHurt", false);
    }

    void FixedUpdate()
    {   
        //move character
        ct.Move(hMove * Time.fixedDeltaTime, crouch,jump);
        jump = false;
    }
}
