using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float _speed = 3.5f;
    float _moveX = 0f;
    float _moveY = 0f;
    Vector3 _movement;
    [SerializeField]
    GameObject _laser;
    float _fire = 0.2f;
    float _canFire = 0.0f;
    static float _live = 3;
    SpawnManager _manager;

  
    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        initialMovment();
        fire();

    }
    void initialMovment()
    {
        _moveX = Input.GetAxisRaw("H");
        _moveY = Input.GetAxisRaw("V");
        _movement = new Vector3(_moveX, _moveY, 0f);
        transform.Translate(_movement * _speed * Time.deltaTime);
        // check up
        //if (transform.position.y >= 5)
        //{
        //    transform.position = new Vector3(transform.position.x, 5f, 0f);
        //}
        //// check down
        //else if (transform.position.y <= -3.5)
        //{
        //    transform.position = new Vector3(transform.position.x, -3.5f, 0f);
        //}
        // we can do this instead of the if and else
        transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,-3.5f,5f),0f);
        // check left
        if (transform.position.x <= -5)
        {
            transform.position = new Vector3(-5f, transform.position.y, 0f);
        }
        //check right
        else if (transform.position.x >= 5)
        {
            transform.position = new Vector3(5f, transform.position.y, 0f);
        }
    }

    void fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fire;
            Instantiate(_laser, transform.position + new Vector3(0f, 0.8f, 0f), Quaternion.identity);
        }
    }

    public void damage()
    {
        _live--;
        Debug.Log(_live);
        if (_live < 1)
        {
            _manager.playerDeath();
            Destroy(this.gameObject);
        }
    }
}