using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropArmour : MonoBehaviour
{
    private PlayerHelath ph;

    [Header("Armour Stats")]
    public int ArmourAddHealth;

    //Armour Durability
    public int MaxArmourDurabilty = 100;
    public int currentArmourDurabilty;
    // Start is called before the first frame update
    void Start()
    {
        currentArmourDurabilty = MaxArmourDurabilty;
        ph = FindObjectOfType<PlayerHelath>();
        if (ph != null)
        {
            Debug.Log("Found ph");
            ph.addarmour(ArmourAddHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takedamage(int whatwetook)
    {
        currentArmourDurabilty -= whatwetook;
        if (currentArmourDurabilty <= 0)
        {
            Debug.Log("ArmourBroke");
            this.gameObject.SetActive(false);
        }
    }
}
