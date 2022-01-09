using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BurstSMG : MonoBehaviour
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
    public int TotalAmmo;

    protected float nextTimeToFire = 0f;
    public ParticleSystem reloadparticlesystem1;
    public ParticleSystem reloadParticleSystem2;
    public TextMeshProUGUI AmmoText;
    public TextMeshProUGUI MaxAmmoText;
    public GameObject outofAmmoText;
    private int isReloading;
    // Start is called before the first frame update

    void Awake()
    {
        isReloading = 0;
    }
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
        if (TotalAmmo <= 0)
        {
            return;
        }
        if (isReloading >= 1)
        {
            return;
        }
        //For NOTautomatic guns
        else if (isReloading <= 0)
        {
            CheckForAmmo();
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                if (CurrentAmmo >= 1)
                {
                    Shoot();
                    Invoke("Shoot", 0.1f);
                    Invoke("Shoot", 0.2f);
                    nextTimeToFire = Time.time + 1f / FireRate;
                }

                else if (CurrentAmmo == 0)
                {
                    Debug.Log("Don't have Ammo, how should we shoot?");
                    outofAmmoText.SetActive(true);
                    Invoke("DestroyTxt", 1f);
                }
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
        isReloading++;
        Debug.Log(isReloading);
        yield return new WaitForSeconds(ReloadDuration);
        CurrentAmmo = maxAmmo;
        TotalAmmo -= maxAmmo;
        isReloading--;
        //after reload is done

    }

    public void TextDisplay()
    {
        AmmoText.text = CurrentAmmo.ToString();
        MaxAmmoText.text = TotalAmmo.ToString();
    }

    public void AddAmmo(int amount)
    {
        TotalAmmo += amount;
    }
}
