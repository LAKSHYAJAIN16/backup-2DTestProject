using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmingPotorEnemyBullet : MonoBehaviour
{
    public float damage;
    private PlayerHelath ph;
    // Start is called before the first frame update
    void Start()
    {
        ph = FindObjectOfType<PlayerHelath>();
        Invoke("destroy", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void destroy()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag =="Player")
        {
            ph.TakeDamage(100);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
