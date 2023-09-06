using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthGiver : MonoBehaviour
{
    // Start is called before the first frame update
    public CanvasGroup texten;
    void Start()
    {
      //  texten = this.GetComponentInChildren<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
         //   texten.alpha = 1;
            other.gameObject.GetComponent<PlayerHealth>().decrease = false;
            other.gameObject.GetComponent<Player>().healthParticles(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
       //     texten.alpha = 0;
            other.gameObject.GetComponent<PlayerHealth>().decrease = true;
            other.gameObject.GetComponent<Player>().healthParticles(false);
        }
    }
}
