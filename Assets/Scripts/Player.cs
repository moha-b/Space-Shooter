using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //[SerializeField] GameObject _liser;
    int _lives = 3;
    SpawnManager _spawnManager;
    [SerializeField] GameObject _laser;
    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("SpawnEnemies").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fire();
        }
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
        Instantiate(_laser, transform.position, Quaternion.identity);
    }
    public void damage()
    {
        _lives--;
        if (_lives < 1)
        {
            Destroy(this.gameObject);
            _spawnManager.onPlayerDeath();
        }
    }
}
