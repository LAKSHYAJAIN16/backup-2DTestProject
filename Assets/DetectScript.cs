using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectScript : MonoBehaviour
{

    //Add Variable whenever ur adding gun nerd
    public MouseFace mf;
    public MouseFace mf2;
    public MouseFace mf3;
    public MouseFace mf4;
    public MouseFace mf5;
    public MouseFace mf6;
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
        if(other.tag == "wall")
        {
            mf.Add();
            mf2.Add();
            mf3.Add();
            mf4.Add();
            mf5.Add();
            mf6.Add();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "wall")
        {
            mf.Subtract();
            mf2.Subtract();
            mf3.Subtract();
            mf4.Subtract();
            mf5.Subtract();
            mf6.Subtract();
        }
    }
}
