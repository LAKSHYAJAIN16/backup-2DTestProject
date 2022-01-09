using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xHealth : MonoBehaviour
{
    private PlayerHelath ph;
    // Start is called before the first frame update
    void Start()
    {
        ph = GetComponent<PlayerHelath>();
        Initiate2xHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Initiate2xHealth()
    {
        ph.health2x();
    }
}
