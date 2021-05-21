using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BT
{
  public class ProvideAgentsATarget : MonoBehaviour
  {
    public Transform target;
    public GameObject spawnObject;
    public Transform objectContainer;

    public bool spawnOverCap;
    public int objectCap;

    int hardCap = 20;

    void Start()
    {
      if (!objectContainer)
        objectContainer = this.transform;
    }

    public void SpawnAgent()
    {
      print("Starting spawn attempt...");
      if (spawnOverCap || (objectContainer.childCount < objectCap))
      {
        if (objectContainer.childCount < hardCap)
        {
          GameObject agent = Instantiate(spawnObject, objectContainer.transform, false);
          agent.GetComponent<SimpleAgent>().target = target;
        }
        else
          print("Hard cap reached");
      }
    }
  }

}