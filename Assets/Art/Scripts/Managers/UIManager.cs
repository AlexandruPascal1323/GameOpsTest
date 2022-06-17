using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public float showGameoverDelay = 2;
    public GameObject menuPanel;
    public GameObject gameoverPanel;
    public GameObject playPanel;
    public GameObject Start;
    public ParticleSystem fxConfetti;

    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (UIManager)FindObjectOfType(typeof(UIManager));
                if (instance == null)
                {
                    var singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<UIManager>();
                    singletonObject.name = typeof(UIManager).ToString();
                }
            }
            return instance;
        }
    }

  
    public void StartGame()
    {
        GameManager.Instance.StartGame();
        menuPanel.SetActive(false);
        playPanel.SetActive(true);
        Start.SetActive(false);
    }

    public void GameOver()
    {
        Invoke("ShowGameoverPanel", showGameoverDelay);
    }

    void ShowGameoverPanel()
    {
        playPanel.SetActive(false);
        gameoverPanel.SetActive(true);
        fxConfetti.Play();
    }

    public void LoadLevel()
    {
        GameManager.Instance.Load();
    }
}
