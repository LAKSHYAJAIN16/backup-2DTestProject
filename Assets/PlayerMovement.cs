using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    public float MoveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    //Mouse$#!7
    public Camera cam;
    Vector2 mousePos;
    public MouseFace gun;

    [Header("Powerups")]
    public float durationForSpeedIncrease = 10f;
    public float IncreaseforSpeed = 25f;

    public float explforce = 100f;

    // Update is called once per frame
    void Update()
    {
        movement.y = Input.GetAxisRaw("Vertical");
        movement.x = Input.GetAxisRaw("Horizontal");

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }

    public void IncreaseSpeed()
    {
        MoveSpeed += IncreaseforSpeed;
        StartCoroutine(decreaseSpeed());
        gun.IncreaseSpeed();
    }

    IEnumerator decreaseSpeed()
    {
        yield return new WaitForSeconds(durationForSpeedIncrease);
        MoveSpeed -= IncreaseforSpeed;
        Debug.Log("SOda Ended");
    }

    public void Exploded()
    {
        Debug.Log("Hey?");
        rb.velocity = Vector2.right * explforce;
    }
}
