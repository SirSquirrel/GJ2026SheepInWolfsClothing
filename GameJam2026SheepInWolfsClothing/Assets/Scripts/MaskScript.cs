using UnityEngine;

public class MaskScript : MonoBehaviour
{
    public bool worn = false;
    private Rigidbody2D mover;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        worn = false;
        mover = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SnapToSheep(GameObject Sheep)
    {
        worn = true;
        gameObject.transform.SetParent(Sheep.transform);
        gameObject.transform.position = Sheep.transform.position;
        mover.simulated = false;
    }

    public void Unsnap()
    {
        mover.simulated = true;
        gameObject.transform.SetParent(null);
        worn = false;
    }
}
