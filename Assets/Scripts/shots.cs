using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shots : MonoBehaviour
{
    public GameObject arrow;
    public int power;
    private Animator anim;
   // public GameObject temp;
//public Rigidbody rigidbody;
    private bool resetTrigger = false;

    public float time;
    
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //To do: fix up this structure
        if (Input.GetKeyDown(KeyCode.R))
        {
         
            anim.SetTrigger("shoot");
        //  time = Time.time + 1f;
        //  resetTrigger = true;
          Vector3 playerPos = new Vector3(this.transform.position.x , this.transform.position.y + 1f, this.transform.position.z);
          Vector3 playerDirection = this.transform.forward;
          Quaternion playerRotation = this.transform.rotation;
          float spawnDistance = 4;
 
          Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
          GameObject temp = Instantiate(arrow, spawnPos, this.transform.rotation) as GameObject;
          temp.GetComponent<Rigidbody>().AddForce(this.transform.forward * power, ForceMode.Impulse);
          Debug.Log("Hey");
        }

   /*     if (Time.time > time && resetTrigger)
        {
            Debug.Log("Yo");
            anim.ResetTrigger("shoot");
            resetTrigger = false;
        }*/
    }
}
