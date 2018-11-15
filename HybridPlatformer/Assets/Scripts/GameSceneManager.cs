using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour {

    public static GameSceneManager instance = null;

    private int gameScore = 0;
    private int playerLives = 1;
    private bool playerActive = false;
    private bool gameStarted = false;
    private bool gameOver = false;

    private float shamrockCounter = 5;
    private float shamCountDown;


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


        if (instance == null){
            instance = this;
        }
        else if( instance != this){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        shamCountDown = shamrockCounter;
	}
	
	void Update () {
	}


    public void PlayerStartedGame(){

        playerActive = true;
    }

    public void PlayerLosesALife(){

        playerLives--;

        if(playerLives == 0){
            gameOver = true;
        }
        else{
            //
        }

    }

    public void ShamrockPickedUp(){

        gameScore += 100;
    }

    public void BeerPickedUp(){

        playerLives += 1;
    }
}
