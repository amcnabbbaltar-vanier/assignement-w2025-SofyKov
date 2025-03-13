using UnityEngine;

public class TrapRandomMovement : MonoBehaviour
{
    public float speed = 3f;
    public float movingTime = 2f;

    private float floorX;
    private float floorY;
 
    private Vector3 objDirection;
    private Vector3 targPosition;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetNewDirection();
    }

    // Update is called once per frame
    void Update()
    {
       MoveTrap();
    }

    void SetNewDirection()
    {
        
        GameObject floor = GameObject.Find("Floor");

        floorX = floor.GetComponent<MeshRenderer>().bounds.size.x;
        floorY = floor.GetComponent<MeshRenderer>().bounds.size.y;

        float randomX = Random.Range(-floorX / 2, floorY / 2) * transform.localScale.x;
        float randomZ = Random.Range(-floorX / 2, floorY / 2) * transform.localScale.z;
      
        targPosition = new Vector3(randomX, 0, randomZ);
        //timer = movingTime;
    }

    void MoveTrap()
    {
        transform.position = Vector3.MoveTowards(transform.position, targPosition, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, targPosition) < 0.05f)
        {
            SetNewDirection();
        }

        // timer -= Time.deltaTime;
        // if(timer <= 0)
        // {
        //     SetNewDirection();
        // }
    }
}
