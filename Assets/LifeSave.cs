using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSave : MonoBehaviour
{
    private PlayerHelath ph;
    // Start is called before the first frame update
    void Start()
    {
        ph = GetComponent<PlayerHelath>();
        AddALife();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddALife()
    {
        ph.AddLife();
    }
}
