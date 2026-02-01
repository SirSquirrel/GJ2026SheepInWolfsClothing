using UnityEngine;

public class PanSlightlyScript : MonoBehaviour
{
    public float speed = 0.1f;
    public float maxDistance = 5f;
    public Vector2 startPosition = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < maxDistance)
            {
                transform.position += new Vector3(speed * Time.deltaTime,0,0);
            }
        }
        if(Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > -maxDistance)
            {
                transform.position += new Vector3(-speed * Time.deltaTime,0,0);
            }
        }
        if(Input.GetKey(KeyCode.W))
        {
            if (transform.position.y < maxDistance)
            {
                transform.position += new Vector3(0,speed * Time.deltaTime,0);
            }
        }
        if(Input.GetKey(KeyCode.S))
        {
            if (transform.position.y > -maxDistance)
            {
                transform.position += new Vector3(0,-speed * Time.deltaTime,0);
            }
        }
    }
}
