using UnityEngine;

public class HoverRotateMovement : MonoBehaviour
{
    public float hoverSpeed = 2f;
    public float hoverHeight = 0.5f;
    public float rotationSpeed = 50f;

    private Vector3 ogPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ogPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newYaxis = ogPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
        transform.position = new Vector3(ogPosition.x, newYaxis, ogPosition.z);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
