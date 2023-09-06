using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineMa : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Anim;
    public string type = "overworld";
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WalkRoom1 ()
    {
        Anim.Play("RoomCamera");
    }

    public void NormalCamera()
    {
        Anim.Play("OverworldCamera");
    }

    public void WaterCamera()
    {
        Anim.Play("Water");
    }
}
