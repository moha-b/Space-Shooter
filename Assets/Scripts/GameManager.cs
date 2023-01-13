using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool _isGameOver = false;

    // Update is called once per frame
    void Update()
    {
        restartGame();
    }

    void restartGame()
    {
        if (Input.GetKeyDown(KeyCode.M) && _isGameOver)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void gameOver()
    {
        _isGameOver = true;
    }

}
