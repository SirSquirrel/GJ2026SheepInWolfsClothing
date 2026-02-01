using UnityEngine;

public class MaskScript : MonoBehaviour
{
    public bool worn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        worn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SnapToSheep(GameObject Sheep)
    {
        worn = true;
        gameObject.transform.SetParent(Sheep.transform);
        gameObject.transform.position = Sheep.transform.position + new Vector3(0,0,-1);
    }

    public void Unsnap()
    {
        gameObject.transform.SetParent(null);
        worn = false;
    }
}
