using UnityEngine;
using System.Collections.Generic;

public class ClickAndDragScript : MonoBehaviour
{
    private CircleCollider2D collider;
    public bool grabbed = false;

    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
    }
    void OnMouseDown()
    {
        grabbed = true;
        collider.enabled = false;
        if(TryGetComponent<MaskScript>(out MaskScript mask))
        {
            mask.Unsnap();
        }
    }

    void Update()
    {
        if(grabbed == true)
        {
            Vector3 newpos = new Vector3();
            newpos.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            newpos.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            newpos.z = transform.position.z;
            transform.position = newpos;
        }
    }

    void OnMouseUp()
    {
        grabbed = false;
        collider.enabled = true;
        if(TryGetComponent<MaskScript>(out MaskScript mask))
        {
            GameObject sheep = GetCollidedSheep();
            if(sheep is not null)
            {
                mask.SnapToSheep(sheep);
            }
           
        }
    }

    public GameObject GetCollidedSheep()
    {
        
        int overlaps = 0;
        List<Collider2D> collidedObjects = new List<Collider2D>();
        ContactFilter2D contactFilter = new ContactFilter2D();
        LayerMask mask = LayerMask.GetMask("Sheep");
        contactFilter.useLayerMask = true;
        contactFilter.layerMask = mask;
        overlaps = collider.Overlap(contactFilter,collidedObjects);
        if(overlaps > 0)
        {
            //just grab the first sheep in the contact list
            return collidedObjects[0].gameObject;
        }
        else
        {
            return null;
        }

    }


}
