using UnityEngine;
using UnityEngine.SceneManagement;

public class StarController: MonoBehaviour
{
    public ParticleSystem particles;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            //Everytime Star collides with Player, add +1 to count the total number of stars a player collects.
            //starCounter ++;

            //Call the IncrementScore method form the GameManager class/script 
            GameManager.Instance.IncrementStarScore();

            Vector3 contactPoint = transform.position;

            // Instantiate the particle system at the contact point
            Instantiate(particles, contactPoint, Quaternion.identity);

            //Destory star upon collision
            Destroy(gameObject);

            //Save into PlayerPrefs the number of star collected to display at the end in the EndScrren.
            //PlayerPrefs.SetInt("StarCounter", starCounter);
        }
    }
}
