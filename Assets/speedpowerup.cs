using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedpowerup : MonoBehaviour
{
    public PlayerMovement player;
    public MouseFace gun;
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
            player.IncreaseSpeed();
            gun.IncreaseSpeed();
            Debug.Log("Increased Speed");
        }
    }
}
