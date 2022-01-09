using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float Health = 100;
    public GameObject deatheffect;
    public float damagewhichinflicts;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("We took " + damage + "Damage");
        Health -= damage;
        anim.SetTrigger("Damage");
        Debug.Log(damage);
        
        if (Health <= 0)
        {
            Debug.Log("Enemy Died");
            GameObject a = Instantiate(deatheffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            CameraShake.Instance.ShakeCamera(5f, 0.2f);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
        {
            TakeDamage(damagewhichinflicts);
        }
        if(other.tag == "sword")
        {
            TakeDamage(100f);
        }
    }
}
