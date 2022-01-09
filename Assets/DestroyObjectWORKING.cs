using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectWORKING : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Reset", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }

    void Reset()
    {
    }
}
