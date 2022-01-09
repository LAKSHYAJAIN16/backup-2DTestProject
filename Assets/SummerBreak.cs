using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummerBreak : MonoBehaviour
{
    // Start is called before the first frame update
    public spawnerforenemies spawner;
    public GameObject Icon;
    void Start()
    {
        spawner.SummerBreak();
        Icon.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
