using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float _speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -7) {
            transform.position = new Vector3(Random.Range(-5,5),8,0f);
        }
    }
    // if we collide with the player
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collide");
        // if the player hit the enemy then destroy the ememy
        if (other.tag == "PLAYER" ) {
            Debug.Log("player destroyed");
            other.transform.GetComponent<Player>().damage();
        }
        // if the fire hit the enemy then destroy both enemy and the fire
        if (other.tag == "LASER")
        {
            Debug.Log("enemy destroyed");
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }

    }
}
