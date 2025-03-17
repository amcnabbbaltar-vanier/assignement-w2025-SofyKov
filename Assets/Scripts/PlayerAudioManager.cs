using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    public AudioSource jumpAudioSource;
    private Animator animator;

    public PlayerAudioManager Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        jumpAudioSource = GetComponent<AudioSource>();
    }

    // void Awake()
    // {
    //     if (Instance == null)
    //     {
    //         Instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayJumpSound()
    {
        jumpAudioSource.Play();
    }
}
