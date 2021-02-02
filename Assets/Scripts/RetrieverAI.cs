using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrieverAI : MonoBehaviour
{
    public GameObject Plane; //土台
    Vector3 planepos; //土台の座標
    Vector3 resetpos; //犬のリセット用の座標
    Vector3 animalpos; //犬の座標
    private Animator animator; //犬のアニメーター
    bool idolmode; //犬のアイドルモードフラグ
    bool callmode = false; //犬のコールモードフラグ
    float idolaction = 100.0f; //アイドルモード用行動判定
    float actionspan = 5.0f; //アイドルモード用行動間隔
    float currenttime = 0f;
    Vector3 force;
    float forceswitchx;
    float forceswitchz;
    public GameObject Camera; //プレイヤーカメラ
    private CharacterController DogController; //キャラクターコントローラー
    private Vector3 destination; //コールモード用目的地座標

    // Start is called before the first frame update
    void Start()
    {
        PlaneGenerate();
        animator = GetComponent<Animator>();
        DogController = GetComponent<CharacterController>();
        idolmode = true;
        force = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        animalpos = this.transform.position;
        if(animalpos.y < -10.0f)
        {
            rb.velocity = Vector3.zero;
            idolmode = false;
            callmode = false;
            animalpos.y += 9.5f;
            this.transform.position = animalpos;
            PlaneGenerate();
        }
        else
        {
            idolmode = true;
        }

        if(animalpos.y > 10.0f)
        {
            rb.velocity = Vector3.zero;
            idolmode = false;
            callmode = false;
            animalpos.y -= 10.5f;
            this.transform.position = animalpos;
            PlaneGenerate();
        }
        else
        {
            idolmode = true;
        }

        if(idolmode == true)
        {            
            currenttime += Time.deltaTime;
            if(currenttime > actionspan)
            {
                idolaction = Random.Range(1.0f, 100.0f);
                if(Random.Range(0f, 1.0f) > 0.5f)
                {
                    forceswitchx = 1.0f;
                }
                else
                {
                    forceswitchx = -1.0f;
                }
                if(Random.Range(0f, 1.0f) > 0.5f)
                {
                    forceswitchz = 1.0f;
                }
                else
                {
                    forceswitchz = -1.0f;
                }
                force = new Vector3(Random.Range(5.0f, 7.0f) * forceswitchx, 0f, Random.Range(5.0f, 7.0f) * forceswitchz);
                currenttime = 0f;
            }
            if(idolaction < 40.0f)
            {               
                rb.AddForce(force);
                animator.SetBool("Walk", true);
				transform.LookAt(transform.position + force);
            }
            else
            {
                force = new Vector3(0f, 0f, 0f);
                rb.AddForce(force);
                animator.SetBool("Walk", false);
            }
        }
        else if(callmode == true)
        {
            Vector3 destination = new Vector3(Camera.transform.position.x, transform.position.y, Camera.transform.position.z);
            if(Vector3.Distance (transform.position, new Vector3(destination.x, transform.position.y, destination.z)) > 1.0f)
            {
                Vector3 velocity = Vector3.zero;
                animator.SetBool("Walk", true);
                Vector3 direction = (destination - transform.position).normalized;
                transform.LookAt (new Vector3 (destination.x, transform.position.y, destination.z));
                velocity = direction;
                velocity.y += Physics.gravity.y * Time.deltaTime;
			    DogController.Move (velocity * Time.deltaTime);
            }
            else
            {
                animator.SetBool("Walk", false);
                idolmode = true;
                callmode = false;
            }
        }
    }

    void PlaneGenerate()
    {
        planepos = this.transform.position;
        planepos.y -= 0.2f;
        Instantiate(Plane, planepos, transform.rotation);
    }

    public void ChangeCallmode()
    {
        idolmode = false;
        callmode = true;
    }

    public void PositionReset()
    {
        resetpos = Camera.transform.position;
        resetpos.z += 1.5f;
        this.transform.position = resetpos;
        PlaneGenerate();
    }
}
