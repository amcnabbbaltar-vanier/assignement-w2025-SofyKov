using UnityEngine;

public class JumpController : MonoBehaviour
{
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
            Destroy(gameObject);
        }
    }
}
