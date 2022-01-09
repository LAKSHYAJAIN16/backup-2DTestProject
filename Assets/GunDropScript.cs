using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDropScript : MonoBehaviour
{
    public Transform AllGuns;
    public GameObject thisGun;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropGun();
        }
    }

    public void DropGun()
    {
        transform.SetParent(AllGuns);
        thisGun.SetActive(false);
    }
}
