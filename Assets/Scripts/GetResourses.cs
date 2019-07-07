using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetResourses : MonoBehaviour
{
    private int curProgress;
    private bool isEnabledProgress;
    private bool timerBegin;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Residence")
        {
            InvokeRepeating("GetResources", 10, 10);
            InvokeRepeating("ChangeProgress", 1, 1);
        }
        isEnabledProgress = false;
        curProgress = 0;
        timerBegin = false;
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
                    if (!isEnabledProgress)
                        isEnabledProgress = true;
                    else
                        isEnabledProgress = false;
                }
            }
        }
        if (gameObject.name == "WoodProcessing")
        {
            if (Static.woodProcessingIsBegin && !timerBegin)
            {
                InvokeRepeating("GetResources", 10, 10);
                InvokeRepeating("ChangeProgress", 1, 1);
                timerBegin = true;
            }
        }
        else
        if (gameObject.name == "IronProcessing")
        {
            if (Static.ironProcessingIsBegin && !timerBegin)
            {
                InvokeRepeating("GetResources", 10, 10);
                InvokeRepeating("ChangeProgress", 1, 1);
                timerBegin = true;
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
            {
                Static.Wood += 50;
                CancelInvoke();
                Static.woodProcessingIsBegin = false;
                timerBegin = false;
                curProgress = 0;
            }
            else
                if (gameObject.name == "IronProcessing")
            {
                Static.Iron += 50;
                CancelInvoke();
                Static.ironProcessingIsBegin = false;
                timerBegin = false;
                curProgress = 0;
            }
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
                if (gameObject.name == "Residence")
                {
                    DrawLineProgress();
                }
                else
                if (gameObject.name == "WoodProcessing")
                {
                    if (Static.woodProcessingIsBegin)
                        DrawLineProgress();
                    else
                        if (DrawButton())
                        Static.woodProcessingIsBegin = true;
                }
                else
                if (gameObject.name == "IronProcessing")
                {
                    if (Static.ironProcessingIsBegin)
                        DrawLineProgress();
                    else
                        if (DrawButton())
                        Static.ironProcessingIsBegin = true;
                }

                if (gameObject.name == "Residence")
                {
                    Vector3 pos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                    var textSize = GUI.skin.label.CalcSize(new GUIContent("Резиденция"));
                    GUI.Label(new Rect(pos.x, Screen.height - pos.y, textSize.x, textSize.y), "Резиденция");
                }
                else
                if (gameObject.name == "WoodProcessing")
                {
                    Vector3 pos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                    var textSize = GUI.skin.label.CalcSize(new GUIContent("Лесопилка"));
                    GUI.Label(new Rect(pos.x, Screen.height - pos.y, textSize.x, textSize.y), "Лесопилка");
                }
                else
                if (gameObject.name == "IronProcessing")
                {
                    Vector3 pos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                    var textSize = GUI.skin.label.CalcSize(new GUIContent("Здание для проиводства стали"));
                    GUI.Label(new Rect(pos.x, Screen.height - pos.y, textSize.x, textSize.y), "Здание для проиводства стали");
                }
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

    void DrawLineProgress()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        GUI.Box(new Rect(pos.x - 10, Screen.height - pos.y - 12, 100, 8), "");
        GUI.DrawTexture(new Rect(pos.x - 10, Screen.height - pos.y - 12, curProgress, 8), Resources.Load<Texture2D>("070116_211"));
    }

    bool DrawButton()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        var textSize = GUI.skin.label.CalcSize(new GUIContent("Начать производство"));
        return GUI.Button(new Rect(pos.x - 10, Screen.height - pos.y - 17, textSize.x + 3, textSize.y + 3), "Начать производство");
    }
}