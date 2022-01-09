using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oncolforenemies : MonoBehaviour
{
    private PlayerHelath ph;
    public int damageWhichShouldbeInflicted;
    // Start is called before the first frame update
    void Start()
    {
        ph = FindObjectOfType<PlayerHelath>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            ph.TakeDamage(damageWhichShouldbeInflicted);
        }
    }
}
