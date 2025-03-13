using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            GameManager.Instance.ResetLevelScore();
            Destroy(GameObject.FindWithTag("Player"));

            // Debug.Log(SceneManager.GetActiveScene().name);

            // if(SceneManager.GetActiveScene().name == "Level4")
            // {
            //     Debug.Log("In");
            //     GameManager.Instance.SaveAllData();
            // }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
