using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public static GameManager Instance;
    public TextMeshProUGUI scoreDisplay;
    public GameObject scorePanel;


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
    public void levelHandling(){
       
        RestartLevelScore();
        Destroy(GameObject.FindWithTag("Player"));// kill if lives <= 0
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  
    }
  
    public void RestartLevelScore()
    {
        scoreDisplay.text = ScoreManager.Instance.GetTotalScore().ToString();
        //ScoreManager.Instance.totalScore = ScoreManager.Instance.totalScore - ScoreManager.Instance.score;
        //score = 0;
        //PlayerPrefs.SetInt("totalScore", ScoreManager.Instance.totalScore);
       // PlayerPrefs.Save();
       // Debug.Log("Score: " + ScoreManager.Instance.totalScore);
    }


    public void EndOfLevelScore()
    {
       // ScoreManager.Instance.score = 0;
       // PlayerPrefs.SetInt("totalScore", ScoreManager.Instance.totalScore);
        PlayerPrefs.Save();
        //Debug.Log("Score: " + ScoreManager.Instance.totalScore);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        scorePanel.SetActive(true);
        if(Instance)
        {
            //scoreDisplay.text = "Score: " + ScoreManager.Instance.score.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
       // ScoreManager.Instance.totalScore = PlayerPrefs.GetInt("totalScore");
        scoreDisplay.text = "Score: " + ScoreManager.Instance.GetTotalScore();
    }
}
