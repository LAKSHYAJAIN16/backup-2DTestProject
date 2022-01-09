using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectOnEnter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] allobjects;
    public int EndOfArray;
    public Transform[] releasepoints;
    public int EndOfReleasePoints;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            GenerateObject();
            CameraShake.Instance.ShakeCamera(5f, .02f);
        }
    }

    private void GenerateObject()
    {
        int a = Random.Range(0, EndOfArray);
        int b = Random.Range(0, EndOfReleasePoints);
        Instantiate(allobjects[a], releasepoints[b].position, releasepoints[b].rotation);
    }
}
