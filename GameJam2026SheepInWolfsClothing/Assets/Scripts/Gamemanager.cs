using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager _instance;
    public int sheepcoin = 10;
    public int score = 0;
    public float survivalTime = 0;

    public static Gamemanager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Game Manager does not exist");
            }
            return _instance;
        }
    }

    public void Awake()
    {
        if(_instance)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public void restart()
    {
        sheepcoin = 10;
        score = 0;
        survivalTime = 0;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sheepcoin > score)
        {
            score = sheepcoin;
        }
        survivalTime = survivalTime + Time.deltaTime;
    }

    public void AddSheepCoin(int coinAmount)
    {
        sheepcoin = sheepcoin + coinAmount;
    }

    public void SubtractSheepCoin(int coinAmount)
    {
        sheepcoin = sheepcoin - coinAmount;
    }
}
