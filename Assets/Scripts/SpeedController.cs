using UnityEngine;

public class SpeedController : MonoBehaviour
{
    private CharacterMovement characterMovement;
    public ParticleSystem particles;
    private bool isRunning = false;

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
        if(collider.CompareTag("Player"))
        {
            Vector3 contactPoint = transform.position;

            Instantiate(particles, contactPoint, Quaternion.identity);

            Destroy(gameObject);

            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                DetermineSpeed();
            }
        }
    }

    private void DetermineSpeed()
    {
        if (isRunning)
        {
            // Reset to normal walking speed
            characterMovement.speedMultiplier = 1.0f;
            isRunning = false;
        }
        else
        {
            // Increase speed
            characterMovement.speedMultiplier = 4.0f;  // Example: double the speed, adjust as needed
            isRunning = true;
        }

        Debug.Log("Running Speed: " + characterMovement.speedMultiplier);
    }
}
