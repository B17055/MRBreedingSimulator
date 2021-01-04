using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTest : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("sleep");
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay (ray.origin, ray.direction , Color.red, 10.0f, false);
        if(Physics.Raycast(ray, out hit, 1.0f))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
        else
        {
            rigidbody.AddForce(transform.forward * 0.01f);
        }
       
    }

    IEnumerator sleep()
    {
        yield return new WaitForSeconds(7.0f);
    }
}
