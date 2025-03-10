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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void LateUpdate()
    {
       UpdateAnimator();
    }

    // TODO Fill this in with your animator calls
    void UpdateAnimator()
    {
        // animator.SetFloat("CharacterSpeed", rb.linearVelocity.magnitude);
    }
}
