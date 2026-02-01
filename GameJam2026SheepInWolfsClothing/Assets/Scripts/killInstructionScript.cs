using UnityEngine;

public class killInstructionScript : MonoBehaviour
{
    public float selfDestructTime = 50f;
    public float destructTimer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        destructTimer += Time.deltaTime;
        if (destructTimer > selfDestructTime || Input.GetKey(KeyCode.T))
        {
            Destroy(gameObject);
        }
    }
}
