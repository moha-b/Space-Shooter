using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text gameOverText;
    [SerializeField] Text restartText;
    [SerializeField] Sprite[] _spriteImg;
    [SerializeField] Image _livesImg;

    GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score : " + 0;
        _livesImg.sprite = _spriteImg[3];
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    public void updateScore(int score)
    {
        scoreText.text = "Score : " + score;
    }

    public void updateLives(int live)
    {
        _livesImg.sprite = _spriteImg[live];
        if(live == 0)
        {
            gameOver();
        }
    }

    void gameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        _gameManager.gameOver();
        StartCoroutine(gameOverFlickerRouten());
    }
    IEnumerator gameOverFlickerRouten()
    {
        while (true) {
            gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
            gameOverText.text = "Game Over";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
