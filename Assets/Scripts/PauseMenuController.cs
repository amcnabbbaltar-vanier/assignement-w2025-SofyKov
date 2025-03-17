using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pausMenuPanel;
    private bool isPaused = false;
    private PauseMenuController Instance;

    public void Awake()
    {
        // if (Instance == null)
        // {
        //     Instance = this;
        //     DontDestroyOnLoad(gameObject);
        // }
        // else
        // {
        //     Destroy(gameObject);
        // }
       // pausMenuPanel = pausMenuPanel.GetComponent<GameObject>();    
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(pausMenuPanel == null)
        {
            pausMenuPanel = GameObject.Find("PauseMenuPanel")?.GetComponent<GameObject>();
        }
        else
        {
            pausMenuPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //If isPaused is true
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        Debug.Log("Resume");
        pausMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        pausMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void RestartGame()
    {
        Debug.Log("Restart");
        //Destroy(GameObject.FindWithTag("Player"));
        // pausMenuPanel.SetActive(false);
        // Time.timeScale = 1f;
        GameManager.Instance.levelHandling();
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        pausMenuPanel.SetActive(false);
        Destroy(GameObject.FindWithTag("Player")); 
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        isPaused = false;
    }
}
