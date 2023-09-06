using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuck : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "map")
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
