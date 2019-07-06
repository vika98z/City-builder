using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourseUpdate : MonoBehaviour
{
    public Text goldText;
    public Text woodText;
    public Text ironText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        goldText.GetComponent<Text>().text = "[" + Static.Gold + "]";
        woodText.GetComponent<Text>().text = "[" + Static.Wood + "]";
        ironText.GetComponent<Text>().text = "[" + Static.Iron + "]";
    }
}
