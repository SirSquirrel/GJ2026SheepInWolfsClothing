using UnityEngine;

public class CoinUpdateScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "SheepCoin: " + GameManager._instance.sheepcoin.ToString() ;

    }
}
