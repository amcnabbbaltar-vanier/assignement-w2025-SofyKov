using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private CharacterMovement characterMovement;
    private Rigidbody rb;
    public AudioSource audioSource;

    public float duration = 0.30f;
    public static AnimatorController Instance;
    private float fallLevel = -10f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        if(transform.position.y < fallLevel)
        {
            GameManager.Instance.levelHandling();
        }
    }

    public void Start()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
        audioSource = GetComponent<AudioSource>();
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

        //Debug.Log(allowDoubleJump);
        //Debug.Log("isGorunde: " + characterMovement.IsGrounded + ", jump counter: " + characterMovement.jumpCounter + " , allow jump: " + characterMovement.allowDoubleJump);
       
        if(!characterMovement.IsGrounded && characterMovement.jumpCounter == 2 && characterMovement.allowDoubleJump == true)
        {
            EnableDoubleJump(duration);
        }
    }

    public void EnableDoubleJump(float duration)
    {
       // allowDoubleJump = true;
        // animator.SetBool("allowDoubleJump", true);
        animator.SetTrigger("doFlip");
        audioSource.Play();
        Invoke("DisableDoubleJump", duration);
    }

    public void DisableDoubleJump()
    {
    characterMovement.allowDoubleJump = false;
       //animator.SetBool("allowDoubleJump", false);
    }

}
