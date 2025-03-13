using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //private float startTime;
    
    public void StartGame()
    {
        Destroy(GameObject.FindWithTag("Player"));
        //startTime = startTime.time;
        PlayerPrefs.SetFloat("PlayerTime", Time.time);
        SceneManager.LoadScene("Level1");
    }

    public void EndGame()
    {
        if(Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
