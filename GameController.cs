using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text winText;
    public Text restartText;
    public Text gameOverText;
    public Text ScoreText;
    public AudioSource ma;
    public AudioSource fa;
    public AudioSource va;


    public int checker;

    private int score;

    private bool restart;
    private bool gameOver;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        fa.Stop();
        ma.Stop();
        ma.Play();
        va.Stop();
        
    }
    void Update()
    {
       
        
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                SceneManager.LoadScene("Space Shooter");
            }
        }
        if (Input.GetKey("escape"))
            Application.Quit();


    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)

            {
                restartText.text = "'T' Button for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;

        if (score >= 100)
        {
            va.Play();
            winText.text = "Game created by Conner Ramputi";
            restart = true;
            gameOver = true;
            checker = 1;
        }


    }

    public void GameOver()
    {
        gameOverText.text = "Game created by Conner Ramputi!";
        ma.Stop();
        fa.Play();
        gameOver = true;

    }
}