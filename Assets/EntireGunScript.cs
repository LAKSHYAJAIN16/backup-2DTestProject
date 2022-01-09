using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EntireGunScript : MonoBehaviour
{
    /// <summary>
    /// Prefab Shooting beacause hahahahahahahahahaha
    /// </summary>


    //sTUFF IDK
    public Transform ShootPoint;
    public GameObject bullet;
    public float bulletForce;
    public float FireRate = 1f;
    public int maxAmmo;
    private int CurrentAmmo;
    public float ReloadDuration = 2f;

    protected float nextTimeToFire = 0f;
    public ParticleSystem reloadparticlesystem1;
    public ParticleSystem reloadParticleSystem2;
    public TextMeshProUGUI AmmoText;
    public TextMeshProUGUI MaxAmmoText;
    public GameObject outofAmmoText;
    // Start is called before the first frame update
    void Start()
    {
        CurrentAmmo = maxAmmo;
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        TextDisplay();
    }
    void Update()
    {
        CheckForAmmo();
        //Input
        //For Automatic Guns
        /*if (Input.GetButtonDown("Fire1")) && Time.time>=nextTimeToFire 
        {
            //nextTimeToFire = Time.time + 1f /FireRate;
            Shoot();
        }
        */

        //For NOTautomatic guns
        if (Input.GetButtonDown("Fire1"))
        {
            if (CurrentAmmo >= 1)
            {
                Shoot();
            }

            else if (CurrentAmmo == 0)
            {
                Debug.Log("Don't have Ammo, how should we shoot?");
                outofAmmoText.SetActive(true);
                Invoke("DestroyTxt",1f);
            }
        }
    }

    void DestroyTxt()
    {
        outofAmmoText.SetActive(false);
    }

    private void Shoot()
    {
        GameObject bt = Instantiate(bullet, ShootPoint.position, ShootPoint.rotation);
        Rigidbody2D rb = bt.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootPoint.right * bulletForce, ForceMode2D.Impulse);
        CameraShake.Instance.ShakeCamera(3f, .02f);

        //Ammo
        CurrentAmmo--;
    }

    private void CheckForAmmo()
    {
        if (CurrentAmmo <= 0)
        {
            StartCoroutine(reload());
        }
    }

    IEnumerator reload()
    {
        //before reload is done
        reloadparticlesystem1.Play();
        reloadParticleSystem2.Play();
        Debug.Log("Reloading....");
        yield return new WaitForSeconds(ReloadDuration - 0.5f);
        CurrentAmmo = maxAmmo;
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Hey");
        //after reload is done

    }

    public void TextDisplay()
    {
        AmmoText.text = CurrentAmmo.ToString();
        MaxAmmoText.text = maxAmmo.ToString();
    }
}
