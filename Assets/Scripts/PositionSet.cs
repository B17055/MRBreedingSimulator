using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSet : MonoBehaviour
{
    Vector3 objectpos;
    Vector3 correctpos;
    public GameObject plane;
    Vector3 planepos;

    // Start is called before the first frame update
    void Start()
    {
        correctpos = new Vector3(0f, 0.2f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        objectpos = this.transform.position;
        if(objectpos.y < -10.0f)
        {
            Instantiate(plane, planepos, transform.rotation);
            this.transform.position = correctpos;
        }
    }

    public void SetPos()
    {
        correctpos = this.transform.position;
        planepos = correctpos;
        correctpos.y += 1.0f;
        planepos.y += 0.5f;
    }
}
