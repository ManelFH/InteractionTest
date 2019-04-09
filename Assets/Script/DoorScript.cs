using System;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    //att
    public static bool doorKey;
    public bool inTrigger,unlocked;
    public int idDoor;
    private static bool open = false, close = true;
    //Trigger event
    void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }
    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }
    //
    void Update()
    {
        if (inTrigger)//if it's inside
        {
            if (close)//if the door it's close
            {                
                if (PlayerKeys.idKeyList.Contains(idDoor) || unlocked)
                {
                    if (Input.GetKeyDown(KeyCode.E))//when press E key, the gameObject(door)
                    {                               //change status to closed
                        open = true;
                        close = false;
                    }
                }
                /*if (doorKey || unlocked)//if have the key
                {
                    if (Input.GetKeyDown(KeyCode.E))//when press E key, the gameObject(door)
                    {                               //change status to closed
                        open = true;
                        close = false;
                    }
                }*/
            }
            else//the door it's open
            {
                if (Input.GetKeyDown(KeyCode.E))//when press E key, the gameObject(door)
                {                               //change status to opened
                    close = true;
                    open = false;
                }
            }
            if (open)//when the status Open it's true, the gameObject(door) rotate to open it
            {
                var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 200);
                transform.rotation = newRot;
            }
            else//when the status Open it's false, the gameObject(door) rotate to close it
            {
                var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 0.0f), Time.deltaTime * 200);
                transform.rotation = newRot;
            }
        }
    }
    //GUI
    void OnGUI()
    {
        if (inTrigger)//if it's inside
        {
            if (open)//when the status Open it's true, show message
            {
                GUI.Box(new Rect(0, 0, 200, 25), "Press E key to close the door");
            }
            else//when the status Open it's false
            {
                if (PlayerKeys.idKeyList.Contains(idDoor) || unlocked)//if have the key
                {
                    GUI.Box(new Rect(0, 0, 200, 25), "Press E key to open the door");
                }
                else
                {
                    GUI.Box(new Rect(0, 0, 200, 25), "¡Need a key!");
                }
            }
        }
    }
}