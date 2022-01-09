using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public GameObject explPrerfab;
    public Transform ExplosionCenter;
    public float radius;
    public PlayerMovement pm;
    public GameObject wholething;
    public float shockeffect = 0.1f;
    public LayerMask whatIsExplodable;
    public float explforce;
    public float ad = 30f;
    public MouseFace a;
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
            Explode();
            GetComponent<BoxCollider2D>().enabled = false;
            wholething.SetActive(false);
        }
        if (other.tag == "Enemy")
        {
            Explode();
            GetComponent<BoxCollider2D>().enabled = false;
            wholething.SetActive(false);
        }
        if (other.tag == "Bullet")
        {
            Explode();
            GetComponent<BoxCollider2D>().enabled = false;
            wholething.SetActive(false);
        }
    }

    private void Explode()
    {
        //Visual
        GameObject effect = Instantiate(explPrerfab, transform.position, transform.rotation);
        Destroy(effect, 1f);
        CameraShake.Instance.ShakeCamera(30f, 1f);

        //BackEnd
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(ExplosionCenter.position, radius,whatIsExplodable);

        foreach (Collider2D enemy in hitenemies)
        {
            Debug.Log("We hit Enemy");
            Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
            PlayerHelath ph = enemy.GetComponent<PlayerHelath>();
            if (rb != null)
            {
                Debug.Log("found");
                pm.enabled = false;
                a.boom(shockeffect);
                rb.AddTorque(ad * Time.deltaTime);
                //Shock
                Invoke("shock", shockeffect);
            }

            if(ph!= null)
            {
                ph.Explosion(100);
                rb.velocity = Vector2.left * explforce;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ExplosionCenter.position, radius);
    }

    private void shock()
    {
        pm.enabled = true;
        this.enabled = false;
        Debug.Log("Shock ended");

    }
}
