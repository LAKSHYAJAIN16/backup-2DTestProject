using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroymedkit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enable());
        GetComponent<BoxCollider2D>().enabled = false;
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
        }
    }

    IEnumerator enable()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<BoxCollider2D>().enabled = true;
        Debug.Log("HAHA");
    }
}
