using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Enemies;
    [SerializeField] private int NextLevel;

    [SerializeField] private GameObject GameOverPanel;
    public bool GameOver;

    private void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemies.Count <= 0)
        {
            SceneManager.LoadScene(NextLevel);
        }

        if (GameOver == true)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }
    }
}
