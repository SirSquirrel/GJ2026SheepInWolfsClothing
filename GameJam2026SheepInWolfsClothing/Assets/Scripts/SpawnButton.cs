using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public int cost;
    public void spawnSheep()
    {
        if(GameManager._instance.sheepcoin >= cost)
        {
            GameManager._instance.SubtractSheepCoin(cost);
            Instantiate(prefabToSpawn, Vector3.zero, Quaternion.identity);
        }
    }
}
