using UnityEngine;

public class ClickAndDragScript : MonoBehaviour
{
    private Rigidbody2D mover;
    public bool grabbed = false;

    void Start()
    {
        mover = GetComponent<Rigidbody2D>();
    }
    void OnMouseDown()
    {
        grabbed = true;   
    }

    void Update()
    {
        if(grabbed == true)
        {
            mover.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    void OnMouseUp()
    {
        grabbed = false;
    }
}
