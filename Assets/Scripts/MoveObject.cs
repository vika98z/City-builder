using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private bool _mouseState;
    private bool moveCamera;
    private Vector3 startPos;

    public Camera cam;

    public GameObject Object;
    public Vector3 screenSpace;
    public Vector3 offset;

    // Use this for initialization
    void Start()
    {

    }


// Update is called once per frame
    void Update()
    {
        //Если мы в режиме стройки
        if (Static.isBuild)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = cam.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit hitInfo;
                if (Object == GetClickedObject(out hitInfo))
                {
                    Object.GetComponent<Rigidbody>().useGravity = false;
                    Object.GetComponent<Rigidbody>().freezeRotation = true;
                    _mouseState = true;
                    screenSpace = cam.WorldToScreenPoint(Object.transform.position);
                    offset = Object.transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
                }
                else
                    moveCamera = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _mouseState = false;
                moveCamera = false;
            }

            //if (moveCamera)
            //{
            //    Debug.Log("moveCamera");
            //    if (Input.GetMouseButton(0)) //зажата кнопка мыши
            //    {
                    
            //        Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition) - startPos;
            //        Debug.Log(startPos);
            //        cam.transform.position = new Vector3(cam.transform.position.x - pos.x, cam.transform.position.y,
            //            cam.transform.position.z - pos.z);
            //    }
            //}

            if (_mouseState)
            {
                var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
                var curPosition = cam.ScreenToWorldPoint(curScreenSpace) + offset;
                Object.transform.position = curPosition;
                //cam.transform.position = curPosition;
            }
        }
    }

    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }
}
