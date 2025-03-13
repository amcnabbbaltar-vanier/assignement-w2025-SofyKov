using UnityEngine;

public class TrapRandomMovement : MonoBehaviour
{
    public float speed = 3f;
    public float movingTime = 2f;

    private float floorX;
    private float floorZ;
 
    private Vector3 objDirection;
    private Vector3 targPosition;

    Renderer floor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        floor = GameObject.Find("Floor").GetComponent<Renderer>();
        
        if(floor == null)
        {
            Debug.LogError("No floor");
            return;
        }

        
       // Debug.Log("Floor centered" + floor.bounds.center);
       // Debug.Log("Floor size: " + floor.bounds.size);

        SetNewDirection();
    }

    // Update is called once per frame
    void Update()
    {
       MoveTrap();
    }

    void SetNewDirection()
    {

        floorX = floor.GetComponent<MeshRenderer>().bounds.size.x /2;
        floorZ = floor.GetComponent<MeshRenderer>().bounds.size.y / 2;

        float randomX = Random.Range(-floorX, floorZ) * transform.localScale.x;
        float randomZ = Random.Range(-floorX, floorZ) * transform.localScale.z;

        Vector3 floorCentered = floor.bounds.center;

        targPosition = new Vector3(randomX, 1, randomZ);
    }

    void MoveTrap()
    {
        transform.position = Vector3.MoveTowards(transform.position, targPosition, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, targPosition) < 0.05f)
        {
            SetNewDirection();
        }
    }
}
