using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public CineMa CinemaState;
    public int type;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "Player")
        {
            if (CinemaState.type == "overworld")
            {
                // execute your desired code here
                CinemaState.type = "walkroom";
                CinemaState.WalkRoom1();
            } else
            {
                CinemaState.type = "overworld";
                CinemaState.NormalCamera();
            }
        }*/

        if (type == 3) CinemaState.WaterCamera();
    }
/*
    private void OnTriggerExit(Collider other)
    {
  
        if (other.gameObject.tag == "Player")
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;
            Vector3 normal = other.transform.right;
            float dot = Vector3.Dot(direction, normal);
            Debug.Log("EXIT" + dot);
            if (dot <= 0)
            {
                // execute your desired code here
                CinemaState.NormalCamera();
            }
        }
    } */
}
