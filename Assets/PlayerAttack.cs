using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public GameObject Sword_Left;
    public GameObject Sword_Right;
    protected float nextTimeToFire = 0f;
    public float FireRate = 1f;

    //Layer for enemies
    public LayerMask enemyLayer;

    //Damage for specific enemies
    public int Damage = 30;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            PlayerAtacks();
            nextTimeToFire = Time.time + 1f / FireRate;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Sword_Left.SetActive(true);
            Sword_Right.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Sword_Left.SetActive(false);
            Sword_Right.SetActive(true);
        }
    }

    private void PlayerAtacks()
    {
        //anim
        anim.SetTrigger("attack");
        //Actual Physics
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, enemyLayer);

        //DAMAGEBOIUZ
        foreach (Collider2D enemy in hitenemies)
        {
            Debug.Log("We hit Enemy");
            //SinglePlayer:enemy.GetComponent<EnemyDamage>().TakeDamage(DamageForFollowBoiz);
            EnemyDamage ed = enemy.GetComponent<EnemyDamage>();
            if (ed != null)
            {
                Debug.Log("We Hit Frickin enemy yo");
                ed.TakeDamage(Damage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}