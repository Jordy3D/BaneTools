using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using BT;

public class ProvideAgentsATarget : MonoBehaviour
{
  public Transform target;
  public GameObject spawnObject;
  //public Vector3 spawnScale = new Vector3(0.5138747f, 0.5138747f, 0.5138747f);
  public Transform objectContainer;

  public bool spawnOverCap;
  public int objectCap;

  int hardCap = 20;

  // Start is called before the first frame update
  void Start()
  {
    if (!objectContainer)
    {
      objectContainer = this.transform;
    }
  }

  public void SpawnAgent()
  {
    print("Starting spawn attempt...");
    if (spawnOverCap || (objectContainer.childCount < objectCap))
    {
      print("Passed spawn check 1...");
      if (objectContainer.childCount < hardCap)
      {
        print("Passed spawn check 2...");
        GameObject agent = Instantiate(spawnObject, objectContainer.transform, false);
        agent.GetComponent<SimpleAgent>().target = target;
        //BaneTools.SetWorldScale(agent.transform, transform, 1);
      }
      else
      {
        print("Hard cap reached");
      }
    }
  }
}
