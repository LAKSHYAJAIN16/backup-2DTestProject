using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ShootPoint;
    public GameObject[] potions;
    public float bulletForce;
    public float duration;

    void Start()
    {
        InvokeRepeating("Shoot", duration, duration);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Shoot()
    {
        int WhichPotion = Random.Range(0, potions.Length);
        GameObject bt = Instantiate(potions[WhichPotion], ShootPoint.position, ShootPoint.rotation);
        Rigidbody2D rb = bt.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootPoint.right * bulletForce, ForceMode2D.Impulse);
    }


}
