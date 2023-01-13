using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player _player;
    AudioSource _audioSource;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        movement();
    }
    void movement()
    {
        float speed = 4f;
        Vector3 move = Vector3.down * speed * Time.deltaTime;
        transform.Translate(move);

        if (transform.position.y <= -7)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PLAYER")
        {
            _audioSource.Play();
            _player.damage();
            Destroy(this.gameObject);
        }
        if (collision.tag == "LASER")
        {
            _audioSource.Play();
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            _player.addScore(10);
        }
    }
}
