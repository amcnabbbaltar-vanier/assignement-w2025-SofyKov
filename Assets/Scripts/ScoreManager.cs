using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int totalScore = 0; // Static variable to store total score across scenes
    private int score = 0;             // Local score variable for current level
    public static ScoreManager Instance;

    // Called when the script is first initialized
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scene changes
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize the totalScore from PlayerPrefs (defaults to 0 if not found)
        totalScore = PlayerPrefs.GetInt("totalScore", 0);
        Debug.Log("Loaded totalScore: " + totalScore);
    }

    void Start() { }

    // Update is called once per frame (not needed for score management, so empty)
    void Update() { }
    
    public int Minus()
    {
        totalScore -= score;        // Deduct current level score from total score
        score = 0;                  // Reset current level score
        Debug.Log("Decreased Score: " + totalScore);

        // Save the updated score to PlayerPrefs
        PlayerPrefs.SetInt("totalScore", totalScore);
        PlayerPrefs.Save();
        return totalScore;
    }

    // Get the total score (used by GameManager to display score)
    public static int GetTotalScore()
    {
        // Return the loaded value from PlayerPrefs (ensuring it's up-to-date)
        Debug.Log("Current totalScore: " + totalScore);
        return totalScore;
    }
}