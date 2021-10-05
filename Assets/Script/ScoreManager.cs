using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public string PlayerName;
    public string BestPlayerName;
    public int BestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Serializable]
    public class BestPlayerData
    {
        public string BPlayerName;
        public int BScore;
    }

    public void SaveData()
    {
        Debug.Log($"Input {BestPlayerName} {BestScore}");
        BestPlayerData data = new BestPlayerData();
        data.BPlayerName = BestPlayerName;
        data.BScore = BestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
        Debug.Log("Save score: json=" + json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/save.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Debug.Log(path);
            BestPlayerData data = JsonUtility.FromJson<BestPlayerData>(json);

            BestPlayerName = data.BPlayerName;
            BestScore = data.BScore;
            Debug.Log("Load score: json=" + json);
        }
    }
}
