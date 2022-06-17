using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool dontSpawnLevel = false;

    [HideInInspector]
    public int level;
    [HideInInspector]
    public int totalBallCount;
    int ballCount = 0;
    bool gameOver = false;
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (GameManager)FindObjectOfType(typeof(GameManager));
                if (instance == null)
                {
                    var singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<GameManager>();
                    singletonObject.name = typeof(GameManager).ToString();
                }
                instance.Init();
            }
            return instance;
        }
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        Application.targetFrameRate = 60;

        level = PlayerPrefs.GetInt("Level", 0);

    }

    public void StartGame()
    {
    }

    public void Load()
    {
        SceneManager.LoadScene(0);
    }

    public void AddBall()
    {
        totalBallCount++;
    }

    public void OnBallHit()
    {
        if (gameOver)
            return;
        ballCount++;
        if (ballCount >= totalBallCount)
        {
            gameOver = true;
            level++;
            PlayerPrefs.SetInt("Level", level);
            PlayerPrefs.SetInt("Win", 1);
            UIManager.Instance.GameOver();
        }
    }
}
