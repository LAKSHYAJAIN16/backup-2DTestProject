using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSPawner : MonoBehaviour
{
    [Header("Environmentboiz")]
    public GameObject[] envioronmentstuff;
    public Transform[] envioronmentSpawnPoints;

    //int
    public int numberOfEnfvironmentTOBeSpawned;
    public int spawnedyet;
    // Start is called before the first frame update
    void Start()
    {
        spawnedyet = 0;

    }

    // Update is called once per frame
    void Update()
    {
        while (spawnedyet <= numberOfEnfvironmentTOBeSpawned)
        {
            //add spawnedyet
            spawnedyet++;
            Debug.Log(spawnedyet);
            int spt = Random.Range(0, envioronmentSpawnPoints.Length);
            int whichpart1 = Random.Range(0, envioronmentstuff.Length);
            Instantiate(envioronmentstuff[whichpart1], envioronmentSpawnPoints[spt].position, Quaternion.identity);
            Debug.Log("Spawnmed");
        }
    }
}
