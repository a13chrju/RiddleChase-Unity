using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDialog : MonoBehaviour
{
    // Start is called before the first frame update
    public string Dialog;
    public CanvasGroup DialogCanvas;
    public GameObject ItemAtMouse;
    public Texture texture;
    public float mouX, mouY;
    public AudioSource audio;
    private float transparency = 1f;
    private bool hasText = true;
    private bool dialogIsOpen = false;
    private float time;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = 0.7f;
        if (ItemAtMouse.GetComponent<RawImage>())
        {
            hasText = false;
            transparency = 0.4f;
            ItemAtMouse.GetComponent<RawImage>().texture = texture;
        }
    }

    void Update()
    {

        if ((Input.GetMouseButtonDown(0)) && dialogIsOpen && Time.time > time)
        {
            ItemAtMouse.active = false;
            dialogIsOpen = false;
            //The mouse is no longer hovering over the GameObject so output this message each frame
            Debug.Log("Mouse is no longer on GameObject.");
            DialogCanvas.alpha = 0;
        }

    }

    /*
    void OnMouseOver()
    {
    }*/

    private void OnMouseDown()
    {
        audio.Play();
        time = Time.time + 1f;
        ItemAtMouse.active = true;
        dialogIsOpen = true;
        //ItemAtMouse.transform.position = new Vector3(Input.mousePosition.x - mouX, Input.mousePosition.y - mouY, Input.mousePosition.z);
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        DialogCanvas.alpha = transparency;
        if (hasText) DialogCanvas.GetComponentInChildren<Text>().text = Dialog;
    }
/*
    void OnMouseExit()
    {
    }*/
}
