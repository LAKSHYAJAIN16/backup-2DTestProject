using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissle : MonoBehaviour
{
    private Transform Player;
    private Rigidbody2D rb;

    public float speed = 5f;
    public GameObject explprefab;
    public float rotatespoeed = 200f;
    // Start is called before the first frame update
    void Start()
    {
       Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)Player.position - rb.position;
        direction.Normalize();
        float rotateamount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateamount * rotatespoeed;
        rb.velocity = transform.up * speed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            GameObject effect = Instantiate(explprefab, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(effect, 1f);
        }
        if (other.collider.tag == "Enemy")
        {
            GameObject effect = Instantiate(explprefab, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(effect, 1f);
        }
        if (other.collider.tag == "wall")
        {
            GameObject effect = Instantiate(explprefab, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(effect, 1f);
        }
    }
}
