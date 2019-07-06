using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeButtonClick : MonoBehaviour
{
    public Camera frontCamera;
    public Camera topCamera;
    public GameObject panel;

    public void BuildModeClick()
    {
        Static.isBuild = true;
        frontCamera.enabled = false;
        topCamera.enabled = true;
        panel.SetActive(true);
    }

    public void RegularModeClick()
    {
        if (!Static.isCollision)
        {
            Static.isBuild = false;
            frontCamera.enabled = true;
            topCamera.enabled = false;
            panel.SetActive(false);
        }
    }
}
