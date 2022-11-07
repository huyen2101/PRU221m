using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : Singleton<GameManager>
{
    void Start()
    {
        Lives = 10;
        Currency = 100;

    }

    private void Update()
    {

    }
    private int currency; 
    [SerializeField]
    private Text currencyText;
    public int Currency
    {
        get
        {
            return currency;
        }
        set
        {
            currency = value;
            currencyText.text = value.ToString();
        }
    }
    private int lives;
    [SerializeField]
    private Text livesTxt;
    private bool gameOver = false;
    [SerializeField]
    private GameObject gameOverMenu;

    // Start is called before the first frame update
    public int Lives
    {
        get { return lives; }
        set
        {
            lives = value;
            if (lives < 1)
            {
                lives = 0;
                GameOver();
            }

            livesTxt.text = value.ToString();

        }
    }

    public void GameOver()
    {
        if (!gameOver)

        {
            gameOver = true;
            gameOverMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
