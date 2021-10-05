using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject GameOverText;
    private int point = 0;

    private float spawnRangeX = 3.5f;
    private float spawnPosZ = 4;
    private float startDelay = 2;
    private float spawnInterval = 2.0f;

    private bool m_GameOver = false;

    public Text ScoreText;
    public Text PlayerNameText;
    public Text BestScoreText;
    public Text BestPlayerText;

    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
        BestScoreText.text = $"Best Score : {ScoreManager.Instance.BestScore}";
        BestPlayerText.text = $"Best Doctor : {ScoreManager.Instance.BestPlayerName}";
        PlayerNameText.text = $"Doctor : {ScoreManager.Instance.PlayerName}";
        ScoreText.text = $"Score : {point}";
    }

    void Update()
    {
        if (m_GameOver)
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                ScoreManager.Instance.LoadData();
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                ScoreManager.Instance.LoadData();
                SceneManager.LoadScene(0);
            }
        }


    }

    void SpawnRandomEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0.3f, spawnPosZ);
        if (m_GameOver == false)
        {
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }

    }

    public void GameOver()
    {
        m_GameOver = true;
        Debug.Log($"Game Over!");
        GameOverText.SetActive(true);
        ScoreManager.Instance.SaveData();
    }

    public void OnTriggerEnter(Collider other)
    {
        point += 1;
        Debug.Log($"Point + {point}");
        ScoreText.text = $"Score : {point}";
        ScoreManager.Instance.SaveData();
        Destroy(other.gameObject);
        UpdateBestPlayer();
    }

    void UpdateBestPlayer()
    {
        if (point > ScoreManager.Instance.BestScore)
        {
            ScoreManager.Instance.BestScore = point;
            ScoreManager.Instance.BestPlayerName = ScoreManager.Instance.PlayerName;
            BestScoreText.text = $"Best Score : {point}";
            BestPlayerText.text = $"Best Doctor : {ScoreManager.Instance.BestPlayerName}";
        }
    }
}
