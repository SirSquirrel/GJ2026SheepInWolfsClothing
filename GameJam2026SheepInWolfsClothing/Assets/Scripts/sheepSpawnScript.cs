using UnityEngine;

public class sheepSpawnScript : MonoBehaviour
{
    public GameObject sheep;
    public float timeBetweenSpawns = 15;
    public float spawnTimer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer = spawnTimer + Time.deltaTime;
        if(spawnTimer > timeBetweenSpawns)
        {
            spawnTimer = 0;
            GameObject newSheep = Instantiate(sheep, Vector3.zero, Quaternion.identity);
            GameManager._instance.sheep.Add(newSheep);
        }
    }
}
