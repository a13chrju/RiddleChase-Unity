using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollZoom : MonoBehaviour
{
    // Start is called before the first frame update
    public float scrollSpeed;
    public GameObject player;
    public float x, y, z, minY, MaxY;
    public Texture2D cursorTexture, attack, something, read;
    private Vector2 hotspot = Vector2.zero;
    private bool zoomedIn = false;

    void Start()
    {
        this.transform.localPosition = new Vector3(player.transform.localPosition.x + x, player.transform.localPosition.y + y, player.transform.localPosition.z + z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            zoomedIn = true;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            zoomedIn = false;
        }


        if (zoomedIn)
        {
            this.transform.localPosition = new Vector3(player.transform.localPosition.x + 5, player.transform.localPosition.y + 18, player.transform.localPosition.z + 9);
        }else
        {
            this.transform.localPosition = new Vector3(player.transform.localPosition.x + x, player.transform.localPosition.y + y, player.transform.localPosition.z + z);
        }

       // this.transform.LookAt(player.transform);

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag == "enemy" || hit.collider.gameObject.tag == "lootItem")
            {
                Cursor.SetCursor(attack, hotspot, CursorMode.Auto);
            }
            else if (hit.collider.gameObject.tag == "read")
            {
                Cursor.SetCursor(read, hotspot, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
            }
        }
    }
}
