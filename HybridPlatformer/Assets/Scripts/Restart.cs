using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    public void RestartGame(){

        GameSceneManager.instance.GameOver = false;
        GameSceneManager.instance.GameStarted = false;
        GameSceneManager.instance.PlayerActive = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
