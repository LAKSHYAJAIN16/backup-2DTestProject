using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAudioScript : MonoBehaviour
{
    public static DoorAudioScript Instance { get; private set; }

    public AudioSource DoorSoundEffect;
    // Start is called before the first frame update

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        DoorSoundEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDoor()
    {
        DoorSoundEffect.Play();
    }
}
