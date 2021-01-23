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
    float idolaction = 100.0f;
    float actionspan = 5.0f;
    float currenttime = 0f;
    Vector3 force;

    // Start is called before the first frame update
    void Start()
    {
        PlaneGenerate();
        animator = GetComponent<Animator>();
        idolmode = true;
        force = new Vector3(0f, 0f, 0f);
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
        if(idolmode == true)
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();
            currenttime += Time.deltaTime;
            if(currenttime > actionspan)
            {
                idolaction = Random.Range(1.0f, 100.0f);
                force = new Vector3(Random.Range(0f, 15.0f) - 7.5f, 0f, Random.Range(0f, 15.0f) - 7.5f);
                currenttime = 0f;
            }
            if(idolaction < 30.0f)
            {               
                rb.AddForce(force);
                animator.SetFloat("Speed", force.magnitude);
				transform.LookAt(transform.position + force);
            }
            else
            {
                force = new Vector3(0f, 0f, 0f);
                rb.AddForce(force);
                animator.SetFloat("Speed", 0f);
            }
        }
    }

    void PlaneGenerate()
    {
        planepos = this.transform.position;
        planepos.y -= 0.1f;
        Instantiate(plane, planepos, transform.rotation);
    }
}
