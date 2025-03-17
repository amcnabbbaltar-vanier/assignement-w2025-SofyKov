using UnityEngine;

public class JumpController : MonoBehaviour
{
    public ParticleSystem particles;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            GameManager.Instance.ActivatFlip();

            Vector3 contactPoint = transform.position;

            Instantiate(particles, contactPoint, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
