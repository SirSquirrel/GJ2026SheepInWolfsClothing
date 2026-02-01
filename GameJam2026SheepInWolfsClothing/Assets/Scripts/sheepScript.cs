using UnityEngine;

public class sheepScript : MonoBehaviour
{
    public float timeSinceLastCoin = 0;
    public float coinTime = 3;
    public float timeSinceLastWander = 0;
    public float timeToNextWander = 5;
    public float wanderTime = 5;
    public bool wandering = false;
    public Vector2 wanderDirection = new Vector2(0,0);
    public float speed = 2;

    private Rigidbody2D mover;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mover = GetComponent<Rigidbody2D>();
        timeToNextWander = Random.Range(8, 16);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastCoin =timeSinceLastCoin + Time.deltaTime;
        if (timeSinceLastCoin > coinTime)
        {
            gainCoin();
            timeSinceLastCoin = 0;
        }

        timeSinceLastWander = timeSinceLastWander + Time.deltaTime;
        Wander();
    }

    public void gainCoin()
    {
        GameManager._instance.AddSheepCoin(1);
    }

    //detach mask on right click
    public void OnMouseOver () 
    {
        if(Input.GetMouseButtonDown(1))
        {
            MaskScript maskWorn = GetComponentInChildren<MaskScript>();
            if(maskWorn is not null)
            {
                maskWorn.Unsnap();
            }
        }
    }   

    public void Wander()
    {
        if(!wandering && timeSinceLastWander > wanderTime)
        {
            timeSinceLastWander = 0;
            wanderTime = Random.Range(4, 8);
            wanderDirection = Random.insideUnitCircle.normalized;
            mover.linearVelocity = wanderDirection * speed;
            wandering = true;
        }
        else if(wandering && timeSinceLastWander > wanderTime)
        {
            timeSinceLastWander = 0;
            wanderTime = Random.Range(8, 16);
            wandering = false;
            mover.linearVelocity = Vector2.zero;
        }
    }

}
