using UnityEngine;
using UnityEngine.SceneManagement;

public class StarController: MonoBehaviour
{
     void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            GameManager.Instance.IncrementScore();
            Destroy(gameObject);
        }
    }
}
