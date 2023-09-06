using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    // Start is called before the first frame update
    private bool canInteract = false;
    public GameObject gate;
    public Animator anim;
    void Start()
    {
        //anim.SetBool("open", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("MONEY");
            if (gate.activeSelf)
            {
                anim.SetBool("open", true);
                gate.SetActive(false);
            }
            else
            {
                anim.SetBool("open", false);
                gate.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canInteract = false;
        }
    }
}
