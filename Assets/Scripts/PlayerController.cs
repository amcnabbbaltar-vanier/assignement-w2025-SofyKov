using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController: MonoBehaviour
{
 
    public int maxHealth = 3;
    private int currHealth;
    public Slider healthBar;
    
    private static int score = 0;
    
    private static int aquired = 0;
    private AudioSource trapDamageAudioSource;
    private AudioSource runAudioSource;

    public void Start()
    {
        currHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currHealth;
    }

    public void trapDamage(int damage)
    {
        currHealth -= damage;
        healthBar.value = currHealth;
        if(currHealth <= 0)
        {
            Restart();
        }
    }

    void Restart()
    {
        currHealth = maxHealth;
        score -= aquired;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
