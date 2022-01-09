using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFace : MonoBehaviour
{
    public Camera cam;
    public Rigidbody2D rb;
    public float MoveSpeed = 5f;

    [Header("Powerups")]
    public float durationForSpeedIncrease = 10f;
    public float IncreaseforSpeed = 25f;

    public float explforce = 100f;
    public Transform pos;
    //VECTORS
    //2D
    Vector2 mousePos;
    Vector2 movement;
    private int hey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        hey = 0;
        print(hey);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        movement.y = Input.GetAxisRaw("Vertical");
        if (hey <= 0)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            rb.isKinematic = false;
        }
        else if (hey >= 1)
        {
            movement.x = 0;
            rb.isKinematic = true;
        }
    }

    //Movement
    void FixedUpdate()
    {
        //Temporary private calculations
        Vector2 tempLookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(tempLookDir.y, tempLookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
        
    }

    public void IncreaseSpeed()
    {
        Debug.Log("Hey");
        MoveSpeed += IncreaseforSpeed;
        StartCoroutine(decreaseSpeed());
        Debug.Log(MoveSpeed);
    }

    IEnumerator decreaseSpeed()
    {
        yield return new WaitForSeconds(durationForSpeedIncrease);
        MoveSpeed -= IncreaseforSpeed;
        Debug.Log("SOda Ended");
    }

    public void Exploded()
    {
        rb.velocity = Vector2.right * explforce;
    }

    public void Add()
    {
        hey++;
    }
    public void Subtract()
    {
        hey--;
    }

    public void boom(float shockduration)
    {
        rb.isKinematic = true;
        Invoke("noboom", shockduration);
    }

    public void noboom()
    {
        rb.isKinematic = false;
    }
}
