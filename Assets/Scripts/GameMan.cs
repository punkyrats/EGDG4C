using TMPro;
using UnityEngine;

public class GameMan : MonoBehaviour
{

    //SCORE MAN START
    public static GameMan Instance;
    public TextMeshProUGUI ScoreNumber;
    public static int Scoretotal = 00;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        UpdateScore();
    }
    void UpdateScore()
    {
        InvokeRepeating("SpawnEnemy", 0f, 4f);
        
        if (ScoreNumber != null)
        {
            ScoreNumber.text = Scoretotal.ToString();
        }
    }
    public void AddScore(int amount)
    {
        Scoretotal += amount;
        UpdateScore();
    }

    //SCORE MAN END
    public GameObject Enemy;
    public Vector3 MinimumArea;
    public Vector3 MaximumArea;
    public int Enemycount = 0;
    public int MaxEnemycount = 15;

    //Chunk of code for spawn area and limiting spawns
    void SpawnEnemy()
    {
        if (Enemycount < MaxEnemycount)
        {
            float randomX = Random.Range(MinimumArea.x, MaximumArea.x);

            Vector3 randomSpawnPosition = new Vector3(randomX, 6, 0);

            GameObject Newobject = Instantiate(Enemy, randomSpawnPosition, Quaternion.identity);
            Destroy(Newobject, 4f);

            Enemycount++;
        }
        else
        {
            CancelInvoke("SpawnEnemy");
        }
    }

}
