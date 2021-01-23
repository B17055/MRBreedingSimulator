using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrieverAI : MonoBehaviour
{
    public GameObject plane;
    Vector3 planepos;
    Vector3 animalpos;
    private Animator animator;
    bool idolmode;

    // Start is called before the first frame update
    void Start()
    {
        PlaneGenerate();
        animator = GetComponent<Animator>();
        idolmode = true;
    }

    // Update is called once per frame
    void Update()
    {
        animalpos = this.transform.position;
        if(animalpos.y < -10.0f)
        {
            animalpos.y += 9.5f;
            this.transform.position = animalpos;
            PlaneGenerate();
        }
    }

    void PlaneGenerate()
    {
        planepos = this.transform.position;
        planepos.y -= 0.1f;
        Instantiate(plane, planepos, transform.rotation);
    }
}
