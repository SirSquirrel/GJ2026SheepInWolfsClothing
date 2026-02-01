using UnityEngine;
using System.Collections.Generic;

public class ScareScript : MonoBehaviour
{
    public List<string> scarable = new List<string>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(LayerMask.LayerToName(col.gameObject.layer) == "Enemy")
        {
            //check if it is an enemy/scare zone collision
            if(transform.parent.TryGetComponent<MaskScript>(out MaskScript mask) && col.gameObject.TryGetComponent<enemyScript>(out enemyScript enemy))
            {
                if (scarable.Contains(enemy.enemyType) && mask.worn == true)
                {
                    enemy.BecomeScared();
                    enemy.scaredNoise.Play();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
