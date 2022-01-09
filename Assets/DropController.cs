using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour
{
    public Transform placeHolder;
    public int hey;
    // Start is called before the first frame update\

    void Awake()
    {
        hey = 0;
    }

    void Start()  
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hey >= 1)
        {
            transform.position = placeHolder.transform.position;
            transform.rotation = placeHolder.transform.rotation;
        }
    }

    public void set()
    {
        hey++;
    }
}
