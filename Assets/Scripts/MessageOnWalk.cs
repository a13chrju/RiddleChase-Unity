using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageOnWalk : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject indicator;
    // private float timeFade = 2f;
    // private bool show = false;
    void Start()
    {
        indicator.active = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            indicator.active = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            indicator.active = false;
        }
    }
}
