using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;
    private CharacterMovement characterMovement;

    private int value = 50;

    private event Action<int> ScoreChanged;

    private static int totalScore = 0;
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
       
       //Look for the score display TextMeshProUGUI and if it can't find one, 
        //instantiate a new one. The reason I do this is because, for some reason probably
        //due to the various DontDestroyOnLoad or Destroys, its nullified.
        scoreDisplay = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();

        //For debugging purposes
        if(scoreDisplay == null)
        {
            Debug.Log("score dispplay");
        }
        if(totalScore == null)
        {
            Debug.Log("total score ");
        }

        //Display the score at level start
        scoreDisplay.text = "Score: " + totalScore;
    }
    public void ResetLevelScore(){
        levelScore = 0;
    }
   

    public void IncrementStarScore()
    {
        levelScore += value;
        totalScore += value;
        ScoreChanged?.Invoke(totalScore);
        Debug.Log("TotalScore: " +totalScore);
        //Increment level score by 50 points every time it collides with a star
        //levelScore += value;

        //Assign the level score to the total score. I keep a seperate levelScore varibale
        //To if the level restarts, remove points acquiered during game and restart.

        //use to be only =
        //totalScore = levelScore;

        //Look for the score display TextMeshProUGUI and if it can't find one, 
        //instantiate a new one. The reason I do this is because, for some reason probably
        //due to the various DontDestroyOnLoad or Destroys, its nullified.
        scoreDisplay = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();

        //Display score in the TextMeshProUGUI for score display
        scoreDisplay.text = "Score: " + totalScore;
    }


    public void levelHandling()
    {
        //Call the ResartLevelScore method in order to set the levelScor to 0 and remove
        //preciously score points from the totalscore
        RestartLevelScore();

        //I destory the player because if not it will affect the gaem function alities such as 
        //duplicating the player and nulify certain fields that are necessary
        Destroy(GameObject.FindWithTag("Player")); 

        //Reload the current screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //Look for the score display TextMeshProUGUI and if it can't find one, 
        //instantiate a new one. The reason I do this is because, for some reason probably
        //due to the various DontDestroyOnLoad or Destroys, its nullified.
        scoreDisplay = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
    }

    public void RestartLevelScore()
    {
        //Set the levelscore to 0 as the game restarts to be able to 
        //count the score for the level from start
        
        totalScore = totalScore - levelScore;
        levelScore = 0;
        ScoreChanged?.Invoke(totalScore);
        Debug.Log("Total Score(restartlevel): " +totalScore);
        Debug.Log("level Score(restartlevel): " +levelScore);

        //Rmove score aquiered previously from the total score.
    }



    public void ActivatFlip()
    {
        //Set allowDoubleJump varibale to true from the CharacterMovement to trigger the Flip animation
        characterMovement.allowDoubleJump = true;
        Debug.Log("Do a flip");
    }

    // public void SetSpeed()
    // {
    //     characterMovement = GetComponent<CharacterMovement>();
    //     characterMovement.speedMultiplier = 5.0f;
    // }

    void Update()
    {
        FindPLayer();

        // Continuously update the score display
    }

    public void SaveAllData()
    {
        // PlayerPrefs.SetInt("TotalScore", totalScore);
        // PlayerPrefs.SetInt("StarScore", (totalScore/50));
        // PlayerPrefs.SetFloat("PlayerTime", 0f);
        Debug.Log("Done");
    }

    public int GetTotalScore()
    {
        return totalScore;
    }


    void FindPLayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null )
        {
            characterMovement = player.GetComponent<CharacterMovement>();
        }
        else
        {
            Debug.Log("No player");
        }
    }
}