using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public string enemyType;
    public AudioSource sheepDeathNoise;
    public AudioSource scaredNoise;
    public bool scared = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float summoningSickness = 5;
    public float summoningMax = 8f;
    public float summoningMin = 5f;
    public float reevaluateTargetTime = 1f;
    public Transform target;
    public float targetTimer = 0;
    public float spawnTimer = 0;
    public float speed = 2;
    private Rigidbody2D mover;
    public GameObject scareIcon;
    void Start()
    {
        summoningSickness = Random.Range(summoningMin,summoningMax);
        spawnTimer = 0;
        scared = false;
        targetTimer = 0;
        target = null;
        mover = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target is null)
        {
            findTarget();
        }
        spawnTimer = spawnTimer + Time.deltaTime;
        targetTimer += Time.deltaTime;
        if(spawnTimer > summoningSickness && !scared)
        {
            Hunt();
        }
        else if(spawnTimer > summoningSickness)
        {
            Flee();
        }
    }

    public void BecomeScared()
    {
        scared = true;
        GameObject icon = Instantiate(scareIcon, transform.position + new Vector3(0f,0.5f,0f), Quaternion.identity);
        icon.transform.SetParent(transform);
    }

    public void OnBecameInvisible()
    {
        if(scared)
        {
            Destroy(gameObject);
        }
    }

    public void Hunt()
    {
        if (targetTimer > reevaluateTargetTime)
        {
            targetTimer = 0;
            findTarget();
        }
        if (target is not null)
        {
            mover.linearVelocity = (target.position - transform.position).normalized * speed;
        }
    }

    public void Flee()
    {
        if (target is not null)
        {
            mover.linearVelocity = (target.position - transform.position).normalized * -speed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject bumper = collision.gameObject;
        if ( LayerMask.LayerToName(bumper.layer) == "Sheep" && !scared)
        {
            GameManager._instance.sheep.Remove(bumper);
            Destroy(bumper);
            target = null;
            GameManager._instance.LoseLife();
            sheepDeathNoise.Play();
            //they ate a sheep so they will leave
            scared = true;
        }
    }

    public void findTarget()
    {
        GameObject closestSheep = null;
        Vector3 closestLength = Vector3.positiveInfinity;
        for(int i = 0;i < GameManager._instance.sheep.Count;i++)
        {
            if((GameManager._instance.sheep[i].transform.position - gameObject.transform.position).magnitude < closestLength.magnitude)
            {
                closestSheep = GameManager._instance.sheep[i];
                closestLength = GameManager._instance.sheep[i].transform.position - gameObject.transform.position;
            }
        }
        if (closestSheep is not null)
        {
            target = closestSheep.transform;
        }
        
    }
}
