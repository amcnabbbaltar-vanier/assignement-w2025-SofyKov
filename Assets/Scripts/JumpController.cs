using UnityEngine;

public class JumpController : MonoBehaviour
{
    public ParticleSystem particles;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (GameManager.Instance == null)
            {
                Debug.LogError("GameManager is not initialized!");
                return; // Return early if GameManager is not available
            }
            GameManager.Instance.ActivatFlip();

            Vector3 contactPoint = transform.position;

            Instantiate(particles, contactPoint, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
