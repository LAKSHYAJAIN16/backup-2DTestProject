using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int slotno;
    [Header("Pistol")]
    public GameObject PistolUI;
    public Transform PistolTransform;
    [Header("BurstGun")]
    public GameObject VurstGunUI;
    public Transform BurstGunTransform;
    [Header("LMG")]
    public GameObject LMGUI;
    public Transform LMGTransform;

    [Header("Slots")]
    public Transform[] slots;
    // Start is called before the first frame update
    void Start()
    {
        slotno = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pistol()
    {
        if (slotno <= 3)
        {
            PistolUI.SetActive(true);
            PistolTransform.position = slots[slotno].transform.position;
            PistolTransform.rotation = slots[slotno].transform.rotation;
        }
        else
        {
            Debug.Log("AllSlots filled, we can't pick up");
        }
    }
    public void BurstGun()
    {
        if (slotno <= 3)
        {
            VurstGunUI.SetActive(true);
            BurstGunTransform.position = slots[slotno].transform.position;
            BurstGunTransform.rotation = slots[slotno].transform.rotation;
        }
        else
        {
            Debug.Log("AllSlots filled, we can't pick up");
        }
    }
    public void LMG()
    {
        if (slotno <= 3)
        {
            LMGUI.SetActive(true);
            LMGTransform.position = slots[slotno].transform.position;
            LMGTransform.rotation = slots[slotno].transform.rotation;
        }
        else
        {
            Debug.Log("AllSlots filled, we can't pick up");
        }
    }

    public void Add()
    {
        slotno++;
    }
}
