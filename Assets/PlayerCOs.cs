using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCOs : MonoBehaviour
{
    private PlayerMovement ps;
    private PlayerHelath ph;
    private SMG smg;
    public ScoreController sc;
    private BurstSMG bsmg;
    private MagicShroom mgshcroom;
    public GameObject Ammo_Add_Desiplay;
    public float Blindnessduratrion;
    public GameObject Blindnesseffect;
    public GameObject BlindnessText;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<PlayerMovement>();
        ph = GetComponent<PlayerHelath>();
        mgshcroom = GetComponent<MagicShroom>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ammo();
            
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Chest
        if(other.collider.tag == "Chest")
        {
            CameraShake.Instance.ShakeCamera(5f, .02f);
        }
        if(other.collider.tag == "medkit")
        {
            CameraShake.Instance.ShakeCamera(5f, .02f);
            ph.medkit();
        }
        if(other.collider.tag == "ammo")
        {
            CameraShake.Instance.ShakeCamera(5f, 0.2f);
            ammo();

        }
        if (other.collider.tag == "dani")
        {
            CameraShake.Instance.ShakeCamera(5f, 0.2f);
            mgshcroom.dani();

        }
        if (other.collider.tag == "infinteammo")
        {
            CameraShake.Instance.ShakeCamera(5f, 0.2f);
            mgshcroom.Collided();

        }
        if (other.collider.tag == "missile")
        {
            CameraShake.Instance.ShakeCamera(5f, 0.2f);
            ph.TakeDamage(100);
            Debug.Log("Col");

        }

        if(other.collider.tag == "coin")
        {
            //Add Functionality Later
            Debug.Log("Idk man");
            CameraShake.Instance.ShakeCamera(3f, 0.2f);
            sc.Add();
        }
        if(other.collider.tag =="bp")
        {
            Invoke("reset", Blindnessduratrion);
            Blindnesseffect.SetActive(true);
            BlindnessText.SetActive(true);
        }
    }
    void ammo()
    {
        //We find active gun
        smg = FindObjectOfType<SMG>();
        if (smg != null)
        {
            Debug.Log("Added");
            smg.AddAmmo(10);
            Ammo_Add_Desiplay.SetActive(true);
            Invoke("ha", 1f);
        }
        else if(smg = null)
        {
            bsmg = FindObjectOfType<BurstSMG>();
            bsmg.AddAmmo(10);
        }

    }

    void ha()
    {
        Ammo_Add_Desiplay.SetActive(false);
    }
    void reset()
    {
        Blindnesseffect.SetActive(false);
        BlindnessText.SetActive(false);
    }
}
