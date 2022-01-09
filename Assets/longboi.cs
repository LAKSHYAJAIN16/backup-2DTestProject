using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longboi : MonoBehaviour
{
    public CountdownTimer timer;
    public GameObject Icon;
    // Start is called before the first frame update
    void Start()
    {
        timer.Powered();
        Icon.SetActive(true);
        Debug.Log("TIMER ACTIVATED");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
