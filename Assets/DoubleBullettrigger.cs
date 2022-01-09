using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBullettrigger : MonoBehaviour
{
    public SMG doubley;
    public DoubleSMG normal;

    [Header("Stats")]
    public float durationOfPowerup = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject);
            Debug.Log("Picked up");
            doubley.enabled = true;
            normal.enabled = false;
            StartCoroutine(back());
        }
    }

    IEnumerator back()
    {
        Debug.Log("HAHAHAHAHAHAHH");
        yield return new WaitForSeconds(1);
        doubley.enabled = false;
        normal.enabled = true;
        Debug.Log("Ended");
    }
}
