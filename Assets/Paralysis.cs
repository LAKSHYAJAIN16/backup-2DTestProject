using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralysis : MonoBehaviour
{
    private PlayerHelath player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHelath>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("Destroyed_Bullet_via_contact");
        }
        if (other.tag == "Player")
        {
            player.Paralysis();
        }
    }
}
