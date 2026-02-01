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

    public void SnapToSheep(GameObject sheep)
    {
        //check if the sheep already has a mask
        if(sheep.GetComponentInChildren<MaskScript>())
        {
            return;
        }
        worn = true;
        gameObject.transform.SetParent(sheep.transform);
        gameObject.transform.position = sheep.transform.position + new Vector3(0,0,-1);
    }

    public void Unsnap()
    {
        gameObject.transform.SetParent(null);
        worn = false;
    }
}
