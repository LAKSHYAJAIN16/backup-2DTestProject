using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGun : MonoBehaviour
{
    public GameObject specificgun;
    public Transform Expirementgun;
    public GameObject placeholder;
    public int canPickup;
    public GameObject AmmoUI;
    public Transform ActiveGunCopjntainer;
    public GameObject EntireGunContainer;
    [Header("Drop")]
    public GunDropScript[] allguns;
    public int endOfGuns;
    public int numberoftimesran;

    void Awake()
    {
        Debug.Log(canPickup);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(canPickup <= 0)
            {
                Debug.Log("Picked up");

                //Add this value whenever ur adding
                allguns[5].DropGun();
                allguns[6].DropGun();
                allguns[7].DropGun();
                allguns[0].DropGun();
                allguns[1].DropGun();
                allguns[2].DropGun();
                allguns[3].DropGun();
                allguns[4].DropGun();

                placeholder.SetActive(false);
                specificgun.SetActive(true);
                Debug.Log(canPickup);
                AmmoUI.SetActive(true);
                Expirementgun.SetParent(ActiveGunCopjntainer);
                EntireGunContainer.SetActive(false);

            }
        }
    } 


}
