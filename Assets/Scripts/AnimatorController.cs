using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private CharacterMovement characterMovement;
    private Rigidbody rb;
    public void Start()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
    }

    public void LateUpdate()
    {
       UpdateAnimator();
    }

    // TODO Fill this in with your animator calls
    void UpdateAnimator()
    {
        // animator.SetFloat("CharacterSpeed", rb.linearVelocity.magnitude);
        float speed =  characterMovement.groundSpeed;
        animator.SetFloat("CharacterSpeed", speed);
        animator.SetBool("IsGrounded", characterMovement.IsGrounded);

        if(!characterMovement.IsGrounded && characterMovement.jumpCounter == 2)
        {
            animator.SetTrigger("doFlip");
        }
    }

}
