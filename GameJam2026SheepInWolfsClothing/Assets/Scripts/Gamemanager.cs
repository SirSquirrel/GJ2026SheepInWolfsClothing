using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public int sheepcoin = 10;
    public int score = 0;
    public float survivalTime = 0;
    public List<GameObject> sheep = new List<GameObject>();
    public int lives = 3;

    public static GameManager Instance
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

    public void Restart()
    {
        sheepcoin = 10;
        score = 0;
        survivalTime = 0;
        lives = 3;
        var existingSheep = Object.FindObjectsOfType<sheepScript>();
        sheep = new List<GameObject>();
        for(int i = 0;i < existingSheep.Length;i++)
        {
            sheep.Add(existingSheep[i].gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        survivalTime = survivalTime + Time.deltaTime;
        if (lives <=0)
        {
            lives = 3;
            ReturnToMenu();
        }
    }

    public void AddSheepCoin(int coinAmount)
    {
        sheepcoin = sheepcoin + coinAmount;
        score += coinAmount;
    }

    public void SubtractSheepCoin(int coinAmount)
    {
        sheepcoin = sheepcoin - coinAmount;
    }

    public void LoseLife()
    {
        lives -= 1;
    }

    public void ReturnToMenu()
    {
        lives = 3;
        SceneManager.LoadScene("menu");
    }

}
