using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShroom : MonoBehaviour
{
    //Scale
    private Vector3 smallScale = new Vector3(0.5f, 0.5f, 1);
    public Vector3 normalScale = new Vector3(2.17f, 2.17f, 2);
    private Vector3 EnlargedScale = new Vector3(5f, 5f, 1);
    private Vector3 MinisculeScale = new Vector3(0.1f, 0.1f, 1);
    private Vector3 LONGScale = new Vector3(2.17f, 3f, 1);

    private Vector3 MEGAScale = new Vector3(10f, 1f, 1);
    private Vector3 Invis = new Vector3(0.0001f, 0.000001f, 1f);
    //Duration
    public float duration = 3f;

    private Vector3 daniSCALE = new Vector3(2.17f, 7f, 1);

    //other
    private int color_stop;
    private SpriteRenderer sr;
    public GameObject Enemies;
    public Color defaultcolor;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Debug.Log("Found sr");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (color_stop >= 1)
        {
            //initiate color;
            changecolor();
        }
    }

    public void dani()
    {
        transform.localScale = daniSCALE;
        Invoke("Reset", duration);
    }
    public void Collided()
    {
        //Random Element

        int index = Random.Range(1, 7);

        //Size
        if (index == 1)
        {
            Debug.Log("SMALL!");
            transform.localScale = smallScale;
            Invoke("Reset", duration);
        }
        if (index == 2)
        {
            Debug.Log("LARGE!");
            transform.localScale = EnlargedScale;
            Invoke("Reset", duration);
        }
        if (index == 3)
        {
            transform.localScale = MEGAScale;
            Invoke("Reset", duration);
        }
        if (index == 4)
        {
            color_stop++;
            Debug.Log(color_stop);
            Debug.Log("MEGA!");
            Invoke("Reset", duration);
        }
        if (index == 5)
        {
            transform.localScale = LONGScale;
            Invoke("Reset", duration);
        }
        if (index == 6)
        {
            transform.localScale = MinisculeScale;
            Invoke("Reset", duration);
        }
        if (index == 7)
        {
            transform.localScale = Invis;
            Invoke("Reset", duration);
        }
    }
    private void Reset()
    {
        transform.localScale = normalScale;
        sr.color = defaultcolor;
        Enemies.SetActive(true);
        if (color_stop >= 1)
        {
            color_stop--;
            sr.color = defaultcolor;
        }
    }

    private void changecolor()
    {
        int Color = Random.Range(1, 7);
        if (Color == 1)
        {
            Debug.Log(Color);
            sr.color = new Color(1, 0, 0, 1);
        }
        if (Color == 2)
        {
            Debug.Log(Color);
            sr.color = new Color(0, 1, 0, 1);
        }
        if (Color == 3)
        {
            Debug.Log(Color);
            sr.color = new Color(0, 0, 1, 1);
        }
        if (Color == 4)
        {
            Debug.Log(Color);
            sr.color = new Color(0, 1, 0, 1);
        }
        if (Color == 5)
        {
            Debug.Log(Color);
            sr.color = new Color(1, 1, 0, 1);
        }
        if (Color == 6)
        {
            Debug.Log(Color);
            sr.color = new Color(1, 1, 1, 1);
        }
        if (Color == 7)
        {
            Debug.Log(Color);
            sr.color = new Color(0, 1, 1, 1);
        }

    }
}
