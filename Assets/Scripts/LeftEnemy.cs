using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftEnemy : MonoBehaviour
{
    Player _player;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        movement();
    }
    void movement()
    {
        float speed = 4f;
        Vector3 move = Vector3.right * speed * Time.deltaTime;
        transform.Translate(move);

        if (transform.position.x >= 9)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PLAYER")
        {
            _player.damage();
            Destroy(this.gameObject);
        }
        if (collision.tag == "LASER")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            _player.addScore(10);
        }
    }
}
