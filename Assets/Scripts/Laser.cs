using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        movement();
    }
    void movement()
    {
        float speed = 8f;
        Vector3 move = Vector3.up * speed * Time.deltaTime;
        transform.Translate(move);

        if (transform.position.y >= 7) { 
            Destroy(this.gameObject);
        }
    }
}
