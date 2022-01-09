using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourPickUp : MonoBehaviour
{
    private PlayerHelath ph;
    public GameObject specificArmour;
    public Transform specificArmourTransform;
    public GameObject placeholder;
    public Transform ActiveArmourContainer;
    public GameObject EntireArmourContainer;


    void Start()
    {
        ph = FindObjectOfType<PlayerHelath>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
                Debug.Log("Picked up");

                placeholder.SetActive(false);
                specificArmour.SetActive(true);
                specificArmourTransform.SetParent(ActiveArmourContainer);
                EntireArmourContainer.SetActive(false);

            
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
