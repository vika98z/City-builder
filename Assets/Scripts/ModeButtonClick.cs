using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeButtonClick : MonoBehaviour
{
    public Camera frontCamera;
    public Camera topCamera;

    public void BuildModeClick()
    {
        Static.isBuild = true;
        frontCamera.enabled = false;
        topCamera.enabled = true;
    }

    public void RegularModeClick()
    {
        Static.isBuild = false;
        frontCamera.enabled = true;
        topCamera.enabled = false;
    }
}
