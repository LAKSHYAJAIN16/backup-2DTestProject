using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankArmRight : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
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
            Debug.Log("Hey");
            anim.SetTrigger("right");
            CameraShake.Instance.ShakeCamera(3f, .02f);
        }
    }
}
