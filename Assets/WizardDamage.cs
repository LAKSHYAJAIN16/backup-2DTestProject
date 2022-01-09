using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardDamage : MonoBehaviour
{
    public float Health = 100;
    public GameObject deatheffect;
    public float damagewhichinflicts;
    public int hasInvised;
    private Animator anim;
    private SpriteRenderer sr;
    public GameObject invisPot;
    public float durationBetweenVisualandLogic;
    public float durationOfInvis = 3f;
    public GameObject InvisEffect;
    public ParticleSystem invisEffectParticlesIDKman;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
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

        if (Health <= 450)
        {
            if (hasInvised <= 0)
            {
                //make sure that we only invis once
                hasInvised++;
                invisPot.SetActive(true);
                Invoke("Invis", durationBetweenVisualandLogic);
                
            }
            else if (hasInvised >= 1)
            {
                Debug.Log("Can't invis m8 sorry");
            }
        }

        if (Health <= 0)
        {
            Debug.Log("Enemy Died");
            GameObject a = Instantiate(deatheffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            CameraShake.Instance.ShakeCamera(5f, 0.2f);
        }

    }

    private void Invis()
    {
        sr.enabled = false;
        invisPot.SetActive(false);
        InvisEffect.SetActive(true);
        invisEffectParticlesIDKman.Play();
        Invoke("reset", durationOfInvis);
    }

    private void reset()
    {
        sr.enabled = true;
        InvisEffect.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            TakeDamage(damagewhichinflicts);
        }
        if (other.tag == "sword")
        {
            TakeDamage(100f);
        }
    }
}
