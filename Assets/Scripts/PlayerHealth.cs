using UnityEngine;using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    public int maxHealth = 3;
    private int currHealth;
    public Slider healthBar;
    private GameManager gameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currHealth; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            trapDamage();
        }
    }


    public void trapDamage()
    {
        currHealth -= 1;
        healthBar.value = currHealth;
        if(currHealth <= 0)
        {
            Restart();
        }
    }

    void Restart()
    {
        //
        currHealth = maxHealth;

        //Removes
        gameManager.RestartLevelScore();

        //Reloads the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
