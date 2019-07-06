using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetResidenceResourses : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GetGold", 0, 10);
    }

    void GetGold()
    {
        if (!Static.isBuild)
            Static.Gold += 100;
    }

    void OnGUI()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    }
}
