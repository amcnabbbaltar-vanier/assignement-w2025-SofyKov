using UnityEngine;using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    public int maxHealth = 3;
    public static int currHealth;
    public Slider healthBar;
    public PlayerHealth Instance;

    void Awake()
    {
    
    }

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
            currHealth = maxHealth;
            GameManager.Instance.levelHandling();
        }
    }

}
