using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : Singleton<GameManager>,IDataPersistence
{
    public bool waysIsChange = false;
    void Start()
    {
        Lives = lives;
        Currency = currency;

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
    public int lives;
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
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadData(GameData data)
    {
        this.Lives = data.lives;
        this.currency = data.currency;
    }

    public void SaveData(ref GameData data)
    {
        if (waysIsChange || SpawnMonster.instance.ways % 2 == 0)
        {
            data.lives = this.lives;
            data.currency = this.currency;
            waysIsChange = false;
        }
    }
}
