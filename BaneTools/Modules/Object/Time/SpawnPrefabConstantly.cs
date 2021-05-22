using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
  [AddComponentMenu("BaneTools/Modules/Time/Spawn Prefab Constantly")]
  public class SpawnPrefabConstantly : MonoBehaviour
  {
    public float delay = 5;
    public GameObject spawnObject;
    public Transform objectContainer;

    public bool spawnOverCap;
    public int objectCap;

    int hardCap = 200;

    void Start()
    {
      if (!objectContainer)
        objectContainer = this.transform;

      StartCoroutine(SpawnConstantly());
    }

    IEnumerator SpawnConstantly()
    {
      while (42 == 42)
      {
        if (spawnOverCap || (objectContainer.childCount < objectCap))
        {
          if (objectContainer.childCount < hardCap)
            Instantiate(spawnObject, objectContainer.transform);
          else
            print("Hard cap reached");
        }
        yield return new WaitForSeconds(delay);
      }
    }
  } 
}
