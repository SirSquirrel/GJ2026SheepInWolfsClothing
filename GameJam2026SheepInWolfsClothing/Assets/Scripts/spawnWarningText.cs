using UnityEngine;

public class spawnWarningText : MonoBehaviour
{
    public float tigerWarningTime = 25f;
    public float poacherWarningTime = 55f;
    public float dragonWarningTime = 95f;
    public float timeFromLastMessage = 0f;
    public float messageLifespan = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float curTime = GameManager._instance.survivalTime;
        timeFromLastMessage += Time.deltaTime;
        if(curTime > tigerWarningTime)
        {
            GetComponent<TMPro.TextMeshProUGUI>().text = "Tigers will spawn soon";
            tigerWarningTime = float.PositiveInfinity;
            timeFromLastMessage = 0f;
        }
        if(timeFromLastMessage > messageLifespan)
        {
            ClearText();
            timeFromLastMessage = 0f;
        }
    }

    public void ClearText()
    {
        GetComponent<TMPro.TextMeshProUGUI>().text = "" ;
    }
}
