using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetResourses : MonoBehaviour
{
    private int curProgress;
    public bool isEnabledProgress;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GetResources", 10, 10);
        InvokeRepeating("ChangeProgress", 1, 1);
        isEnabledProgress = false;
        curProgress = 0;
    }

    void Update()
    {
        if (!Static.isBuild)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo;
                if (gameObject == GetClickedObject(out hitInfo))
                {
                    Debug.Log("VV");
                    if (!isEnabledProgress)
                        isEnabledProgress = true;
                    else
                        isEnabledProgress = false;
                }
            }
        }
    }

    void GetResources()
    {
        if (!Static.isBuild)
        {
            if (gameObject.name == "Residence")
                Static.Gold += 100;
            else
                if (gameObject.name == "WoodProcessing")
                Static.Wood += 50;
            else
                if (gameObject.name == "IronProcessing")
                Static.Iron += 50;
        }
    }

    void ChangeProgress()
    {
        if (curProgress != 90)
            curProgress += 10;
        else
            curProgress = 0;
    }

    void OnGUI()
    {
        if (!Static.isBuild)
        {
            if (isEnabledProgress)
            {
                Vector3 pos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                GUI.Box(new Rect(pos.x - 10, Screen.height - pos.y - 12, 100, 8), "");
                GUI.DrawTexture(new Rect(pos.x - 10, Screen.height - pos.y - 12, curProgress, 8), Resources.Load<Texture2D>("070116_211"));
            }
        }
    }
    GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }
}

