using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHelath : MonoBehaviour
{
    /// <summary>
    /// VARIABLES AND VARIABLES AND VARIABLES
    /// </summary>
    public int MaxHealth = 100;
    private int CurrentHealth;
    private int CanRespawn;
    private dropArmour da;
    public HealthBar healthbar;
    public Animator anim;
    public PlayerMovement pm;
    public MouseFace gun;
    public GameObject dedui;
    public Rigidbody2D rb;
    public Timer timer;
    public ScoreController sc;
    public TextMeshProUGUI currentHealthDisplay;
    public GameObject CheatedDeathText;
    public GameObject Totem_Icon;
    public GameObject Double_Icon;
    public GameObject ActiveGuns;
    public GameObject ParalysisText;
    public float ParalysisDuration;
    void Start()
    {
        CurrentHealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        CanRespawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.SetHealth(CurrentHealth);
        currentHealthDisplay.text = CurrentHealth.ToString();
        if (CurrentHealth <= 0)
        {
            if(CanRespawn <= 0)
            {
                Debug.Log("DED");
                dedui.SetActive(true);
                pm.enabled = false;
                rb.velocity = Vector2.left * 100;
                timer.ded();
                sc.DED();
            }

            else if (CanRespawn >= 1)
            {
                Debug.Log("Cheated Death!");
                CanRespawn--;
                Debug.Log(CanRespawn);
                CurrentHealth = MaxHealth;

                //Visual
                CheatedDeathText.SetActive(true);
                Totem_Icon.SetActive(false);
                Invoke("reset", 2f);
            }

        }
    }       

    void reset()
    {
        CheatedDeathText.SetActive(false);
    }
    public void Boom()
    {
        Debug.Log("BOOM");
        pm.Exploded();
        gun.Exploded();
        CurrentHealth -= 40;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        anim.SetTrigger("Pd");
        da = FindObjectOfType<dropArmour>();
        if (da != null)
        {
            da.takedamage(damage);
        }
        CameraShake.Instance.ShakeCamera(5f, .02f);
    }

    public void medkit()
    {
        CurrentHealth = MaxHealth;
    }

    public void Explosion(int damage)
    {
        CurrentHealth -= damage;
    }

    public void addarmour(int add)
    {
        MaxHealth += add;
        CurrentHealth = MaxHealth;
        Debug.Log(MaxHealth);
        healthbar.SetMaxHealth(MaxHealth);
    }

    public void Paralysis()
    {
        pm.enabled = false;
        ParalysisText.SetActive(true);
        ActiveGuns.SetActive(false);
        Invoke("resetPar", ParalysisDuration);
        
    }

    private void resetPar()
    {
        pm.enabled = true;
        ParalysisText.SetActive(false);
        ActiveGuns.SetActive(true);
    }
    //Health relatecd shop items
    public void health2x()
    {
        MaxHealth = 600;
        CurrentHealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
        Debug.Log("HealthIs" + MaxHealth);
        Double_Icon.SetActive(true);
    }

    public void AddLife()
    {
        CanRespawn++;
        Totem_Icon.SetActive(true);
    }
}
