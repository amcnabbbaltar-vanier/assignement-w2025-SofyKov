using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private  int totalScore = 0;
    private  int score = 0;
     public static ScoreManager Instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
     void Awake()
    {
       // totalScore = PlayerPrefs.GetInt("totalScore");

        if(Instance == null)
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore()
    {
        score += 50;
        totalScore = score;
        Debug.Log("Score: " + totalScore);
    }
    public int minus()
    {
        totalScore -= score;
        score = 0;
        return totalScore;
    }

    public int GetTotalScore()
    {
        PlayerPrefs.SetInt("totalScore", totalScore);
        PlayerPrefs.Save();
        Debug.Log("Score1 : " + totalScore);
        Debug.Log("Score2 : " + PlayerPrefs.GetInt("totalScore"));
        return totalScore;
    }

}
