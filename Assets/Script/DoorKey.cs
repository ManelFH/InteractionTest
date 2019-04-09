using System;
using System.Collections;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    //att
    public bool inTrigger;
    public int idKey;
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
            if (Input.GetKeyDown(KeyCode.E))//when press E key, the gameobject will be destrolled
            {                               //change the value to doorKey
                DoorScript.doorKey = true;
                PlayerKeys.idKeyList.Add(idKey);
                Destroy(this.gameObject, 0.5f);
            }
        }
    }

    //GUI
    void OnGUI()
    {        
        if (inTrigger)//if it's inside
        {
            if (!DoorScript.doorKey)//if haven't the key, show message
            {
                GUI.Box(new Rect(0, 60, 200, 25), "Press E to take a key");
            }
            //TODO
            if (DoorScript.doorKey)//you get a key, show message
            {
                GUI.Box(new Rect(0, 60, 200, 25), "¡You have obtained a key!");
            }
        }
    }
}