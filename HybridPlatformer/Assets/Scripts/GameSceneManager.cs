using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour {

    public static GameSceneManager instance = null;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject clearLevelMenu;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text playerLivesText;
    [SerializeField] private GameObject collectiblePrefab;

    private int gameScore = 0;
    private int playerLives = 3;
    private bool playerActive = false;
    private bool gameStarted = false;
    private bool gameOver = false;



    //Getters and Setters
    public bool PlayerActive{
        get { return playerActive; }
        set { playerActive = value; }
    }

    public bool GameOver{
        get { return gameOver; }
        set { gameOver = value; }
    }

    public bool GameStarted{
        get { return gameStarted; }
        set { gameStarted = value; }
    }

    public int GameScore{
        get { return gameScore; }
    }


    void Awake () {


        gameOverMenu.SetActive(false);
        clearLevelMenu.SetActive(false);
        if (instance == null){
            instance = this;
        }
        else if( instance != this){
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
        Assert.IsNotNull(mainMenu);
	}
	
	void Update () {
	}


    public void PlayerStartedGame(){

        playerActive = true;
    }

    public void PlayerLosesALife(){


            gameOver = true;
            gameStarted = false;
            gameOverMenu.SetActive(true);
            //scoreText.text = "Score: " + gameScore;
            Time.timeScale = 0;
    }

    public void PlayerClearsLevel(){

        Time.timeScale = 0;
        clearLevelMenu.SetActive(true);
    }

    public void EnterGame(){
        mainMenu.SetActive(false);
        gameStarted = true;
        Time.timeScale = 1;
        //PlayerStartedGame();

        scoreText.text = "Score: " + gameScore.ToString();
        playerLivesText.text = "1P: " + playerLives.ToString();
    }

    public void ShamrockPickedUp(){

        gameScore += 100;
        scoreText.text = "Score: " + gameScore.ToString();
    }
}
