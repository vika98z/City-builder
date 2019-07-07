using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public void CreateResidence()
    {
        if (Static.Gold >= 100)
        {
            var randomPosition = new Vector3(Random.Range(1, 97), 22, Random.Range(-99, -2));
            var residence = GameObject.Find("Residence");
            var obj = Instantiate(residence, randomPosition, Quaternion.identity) as GameObject;
            obj.name = "Residence";
            Static.Gold -= 100;
        }
    }

    public void CreateWoodProcessing()
    {
        if (Static.Gold >= 150)
        {
            var randomPosition = new Vector3(Random.Range(1, 97), 6.61f, Random.Range(-99, -2));
            var residence = GameObject.Find("WoodProcessing");
            var obj = Instantiate(residence, randomPosition, Quaternion.identity) as GameObject;
            obj.name = "WoodProcessing";
            Static.Gold -= 150;
        }
    }

    public void CreateIronProcessing()
    {
        if (Static.Gold >= 150 && Static.Wood >= 100)
        {
            var randomPosition = new Vector3(Random.Range(1, 97), 5.5f, Random.Range(-99, -2));
            var residence = GameObject.Find("IronProcessing");
            var obj = Instantiate(residence, randomPosition, Quaternion.identity) as GameObject;
            obj.name = "IronProcessing";
            Static.Gold -= 150;
            Static.Wood -= 100;
        }
    }
}
