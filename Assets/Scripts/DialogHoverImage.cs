using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogHoverImage : MonoBehaviour
{
    public string Dialog;
    public CanvasGroup DialogCanvas;
    public GameObject ItemAtMouse, defaultPaperImage;
    public Texture texture;
    public float mouX, mouY;
    private float transparency = 0.4f;
    private bool dialogIsOpen = false;
    private float time;

    // Start is called before the first frame update


    void OnMouseOver()
  {
        ItemAtMouse.GetComponent<RawImage>().texture = texture;
        defaultPaperImage.SetActive(false);
        ItemAtMouse.SetActive(true);
        ItemAtMouse.transform.position = new Vector3(Input.mousePosition.x - mouX, Input.mousePosition.y - mouY, Input.mousePosition.z);
      //If your mouse hovers over the GameObject with the script attached, output this message
      Debug.Log("Mouse is over GameObject.");
      DialogCanvas.alpha = transparency;
  }

    void OnMouseExit()
    {
        defaultPaperImage.SetActive(true);
        ItemAtMouse.SetActive(false);
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
        DialogCanvas.alpha = 0;
    }

}
