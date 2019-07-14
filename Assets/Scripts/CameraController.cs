using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 startPos;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            startPos = cam.ScreenToWorldPoint(Input.mousePosition);
        else if (Input.GetMouseButton(0)) //зажата кнопка мыши
        {
            Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition) - startPos;
            transform.position = new Vector3(transform.position.x - pos.x, transform.position.y,
                transform.position.z - pos.z);
        }
    }
}
