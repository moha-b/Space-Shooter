using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //[SerializeField] GameObject _liser;
    int _lives = 3;
    int _score = 0;
    SpawnManager _spawnManager;
    UiManager _uiManager;
    [SerializeField] GameObject _laser;
    [SerializeField] AudioClip _laserClip;
    AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _laserClip;     
        _spawnManager = GameObject.Find("SpawnEnemies").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        fire();
    }

    void movement()
    {
        float xAxis = Input.GetAxisRaw("H");
        float yAxis = Input.GetAxisRaw("V");
        float speed = 6f;
        Vector3 move = new Vector3(xAxis, yAxis, 0f) * speed * Time.deltaTime;
        
        transform.Translate(move);

        if (transform.position.x >= 8)
        {
            transform.position = new Vector3(8f,transform.position.y,0f);
        }
        else if (transform.position.x <= -8)
        {
            transform.position = new Vector3(-8f, transform.position.y, 0f);
        }
        if (transform.position.y >= 4)
        {
            transform.position = new Vector3(transform.position.x, 4f, 0f);
        }
        else if (transform.position.y <= -4)
        {
            transform.position = new Vector3(transform.position.x, -4f, 0f);
        }
    }
    void fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_laser, transform.position, Quaternion.identity);
            _audioSource.Play();
        }

    }
    public void damage()
    {
        _lives--;
        _uiManager.updateLives(_lives);
        if (_lives < 1)
        {
            Destroy(this.gameObject);
            _spawnManager.onPlayerDeath();
        }
    }
    public void addScore(int points)
    {
        _score += points;
        _uiManager.updateScore(_score);
    }
}
