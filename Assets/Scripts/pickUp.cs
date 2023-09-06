using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public int type = 1;
    GameObject PS;

    void Start()
    {
        PS = GameObject.FindGameObjectWithTag("PlayerStatus");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (type)
            {
                case 1:
                    PS.GetComponent<PlayerStatus>().addCoinsUpdateUI();
                    Destroy(this.gameObject);
                    return;
                case 2:
                    PS.GetComponent<PlayerStatus>().addKeysUpdateUI();
                    Destroy(this.gameObject);
                    return;
            }
        }
    }
}
