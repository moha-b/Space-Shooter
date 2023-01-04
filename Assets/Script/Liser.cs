using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liser : MonoBehaviour
{
    float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        Destroy(this.gameObject,5);
    }
}
