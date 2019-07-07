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
    public void CreateTree()
    {
        if (Static.Gold >= 50 && Static.Wood >= 200)
        {
            var randomPosition = new Vector3(Random.Range(1, 97), 14.6f, Random.Range(-99, -2));
            var residence = GameObject.Find("Tree");
            var obj = Instantiate(residence, randomPosition, Quaternion.identity) as GameObject;
            obj.name = "Tree";
            Static.Gold -= 50;
            Static.Wood -= 200;
        }
    }

    public void CreateBench()
    {
        if (Static.Gold >= 150 && Static.Iron >= 50)
        {
            var randomPosition = new Vector3(Random.Range(1, 97), 2.7f, Random.Range(-99, -2));
            var residence = GameObject.Find("Bench");
            var obj = Instantiate(residence, randomPosition, Quaternion.identity) as GameObject;
            obj.name = "Bench";
            Static.Gold -= 150;
            Static.Iron -= 50;
        }
    }
}
