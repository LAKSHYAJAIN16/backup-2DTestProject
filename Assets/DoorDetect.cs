using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDetect : MonoBehaviour
{
    public GameObject Door;
    public DoorAudioScript ds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D PlayerFrick)
    {
        if(PlayerFrick.tag == "Player")
        {
            Door.SetActive(true);
            Debug.Log("$#!7");
            ds.PlayDoor();
            DoorAudioScript.Instance.PlayDoor();
        }
    }
}
