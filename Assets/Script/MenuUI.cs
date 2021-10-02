using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
[DefaultExecutionOrder(1000)]
public class MenuUI : MonoBehaviour
{
    public InputField inputName;
    public Text bestPlayer;

    void Awake()
    {
        ScoreManager.Instance.LoadData();
    }
    // Start is called before the first frame update
    void Start()
    {
        inputName.onValueChanged.AddListener(NewPlayerNameInput);
        bestPlayer.text = $"Best Score : {ScoreManager.Instance.BestPlayerName} : {ScoreManager.Instance.BestScore}";
        inputName.text = ScoreManager.Instance.BestPlayerName;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void NewPlayerNameInput(string playerName)
    {
        ScoreManager.Instance.PlayerName = playerName;
    }
}
