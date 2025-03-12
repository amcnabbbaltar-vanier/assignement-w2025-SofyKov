using UnityEngine;

public class TrapRandomMovement : MonoBehaviour
{
    public float speed = 3f;
    public float movingTime = 2f;

    private float floorX;
    private float floorY;
 
    private Vector3 objDirection;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject floor = GameObject.Find("Floor");
        // float floorSize = floor.GetComponent<MeshRenderer>().bounds.size.magnitude;

         floorX = floor.GetComponent<MeshRenderer>().bounds.size.x;
         floorY = floor.GetComponent<MeshRenderer>().bounds.size.y;
        SetNewDirection();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(objDirection * speed * Time.deltaTime);

        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SetNewDirection();
        }
    }

    void SetNewDirection()
    {
        float randomX = Random.Range(-floorX / 2, floorY / 2);
        float randomZ = Random.Range(-floorX / 2, floorY / 2);
      
        objDirection = new Vector3(randomX, 0, randomZ).normalized;
        timer = movingTime;
    }
}
