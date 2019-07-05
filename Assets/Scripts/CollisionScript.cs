using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public Material Green;
    public Material Red;
    public GameObject Base;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay(Collider col)
    {
        GameObject enteredObject = col.gameObject;
        Debug.Log(enteredObject.name);
        //GameObject Base = GameObject.Find
        Base.GetComponent<Renderer>().material = Red;
        Static.isCollision = true;
    }

    void OnTriggerExit(Collider col)
    {
        GameObject enteredObject = col.gameObject;
        Base.GetComponent<Renderer>().material = Green;
        Static.isCollision = false;
    }
}
