using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;
    private CharacterMovement characterMovement;
    //public Panel scorePanel;

    private static int totalScore = 0; // Static variable to store total score across scenes
    private static int levelScore = 0;  
    public static GameManager Instance;

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

    void Start()
    {
        FindPLayer();
       
        scoreDisplay = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();

        if(scoreDisplay == null)
        {
            Debug.Log("score dispplay");
        }
        if(totalScore == null)
        {
            Debug.Log("total score ");
        }

        scoreDisplay.text = "Score: " + totalScore;
    }

    public void IncrementScore()
    {
        levelScore = levelScore + 50;
        totalScore = levelScore;
        scoreDisplay = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
        scoreDisplay.text = "Score: " + totalScore;
    }


    public void levelHandling()
    {
        RestartLevelScore();
        //Destroy(GameObject.FindWithTag("Player")); // Destroy player on level restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                scoreDisplay = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();

    }

    public void RestartLevelScore()
    {
        levelScore = 0;
        totalScore = totalScore - levelScore;
    }

    public void ActivatFlip()
    {
        // if(animatorController == null)
        // {
        //     animatorController = GetComponent<AnimatorController>();
        // }
        characterMovement.allowDoubleJump = true;
        ///pl = true;
    }

    void Update()
    {
        // Continuously update the score display
    }

    void FindPLayer(){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null ){
            characterMovement = player.GetComponent<CharacterMovement>();
        }else{
            Debug.LogError("No player");
        }
    }

    
}