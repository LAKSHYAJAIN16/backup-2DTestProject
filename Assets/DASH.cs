using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DASH : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerMovement pm;
    public GameObject ActiveGuns;
    private int Side;

    public HealthBar healthbar;
    public float dash_speed = 100f;
    public float delayfactor = 0.2f;

    public float dashCooldown;
    private TrailRenderer tr;
    public float time;

    private int isDashing;
    private int canDash;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        isDashing = 0;
        canDash = 0;
        rb = GetComponent<Rigidbody2D>();
        Side = 0;
        pm = GetComponent<PlayerMovement>();
        tr = GetComponent<TrailRenderer>();
        healthbar.SetMaxHealthf(dashCooldown);
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.SetHealthf(time);
        MyInput();
        if (isDashing <= 0)
        {
            Debug.Log("Called");
            time += Time.deltaTime;
            if (time >= dashCooldown)
            {
                canDash++;
                isDashing++;
            }
        }

        else if (isDashing >= 1)
        {

        }
        
    }
    void Reset()
    {
        pm.enabled = true;
        ActiveGuns.SetActive(true);
        tr.enabled = false;

        //ResetCooldown
        canDash--;
        time = 0;
        isDashing--;
    }

    void MyInput()
    {
        if (canDash >= 1)
        {
            if (Input.GetKey(KeyCode.A))
            {
                Side = 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Side = 2;
            }
            if (Input.GetKey(KeyCode.W))
            {
                Side = 3;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Side = 4;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                startdash();
            }
        }

        else if (canDash <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Can't Dash noob");
        }
    }

    private void startdash()
    {
        //InitiateDash
        Debug.Log("Works");
        pm.enabled = false;
        ActiveGuns.SetActive(false);
        Invoke("Reset", delayfactor);
        tr.enabled = true;
        CameraShake.Instance.ShakeCamera(5f, delayfactor);
        //Side $#!7
        if (Side == 1)
        {
            rb.velocity = Vector2.left * dash_speed;
        }
        if (Side == 2)
        {
            rb.velocity = Vector2.right * dash_speed;
        }
        if (Side == 3)
        {
            rb.velocity = Vector2.up * dash_speed;
        }
        if (Side == 4)
        {
            rb.velocity = -Vector2.up * dash_speed;
        }
    }
}
