using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBoi : MonoBehaviour
{
    //Assignables
    public GameObject explosioneffect;
    public float explosionforce;
    public float forcerange = 0.5f;
    public LayerMask thingswhichshouldbeeffectes;
    private PlayerHelath ph;
    // Start is called before the first frame update
    void Start()
    {
        ph = FindObjectOfType<PlayerHelath>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Boom();
            Destroy(gameObject);
            GameObject effect = Instantiate(explosioneffect, transform.position, transform.rotation);
            Destroy(effect, 1f);
            Debug.Log("Detected");
            CameraShake.Instance.ShakeCamera(10f, 1f);

        }
    }

    private void Boom()
    {
        ph.Boom();
        Destroy(gameObject);
    }
}
