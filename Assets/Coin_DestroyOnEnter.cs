using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_DestroyOnEnter : MonoBehaviour
{
    private Rigidbody2D rb;
    public float releasespeed;
    public float durationbeforepickupable;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(enable());
        Debug.Log("Coroutine Started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
            AddScore();
            
        }
    }

    void AddScore()
    {
        //Empty Function, add this later
        Debug.Log("Added Score");
    }

    IEnumerator enable()
    {
        yield return new WaitForSeconds(durationbeforepickupable);
        GetComponent<BoxCollider2D>().enabled = true;
        Debug.Log("HAHA");
    }
}
