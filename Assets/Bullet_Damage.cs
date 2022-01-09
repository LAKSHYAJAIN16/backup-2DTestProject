using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Damage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 3f);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("Destroyed_Bullet_via_contact");
        }
        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
