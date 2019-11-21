using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabConstantly : MonoBehaviour
{
  public float delay = 5;
  public GameObject spawnObject;
  public Transform objectContainer;

  public bool spawnOverCap;
  public int objectCap;

  int hardCap = 200;

  // Start is called before the first frame update
  void Start()
  {
    if (!objectContainer)
    {
      objectContainer = this.transform;
    }

    StartCoroutine(SpawnConstantly());
  }

  // Update is called once per frame
  void Update()
  {

  }

  IEnumerator SpawnConstantly()
  {
    while (42 == 42)
    {
      print("Starting spawn attempt...");
      if (spawnOverCap || (objectContainer.childCount < objectCap))
      {
        print("Passed spawn check 1...");
        if (objectContainer.childCount < hardCap)
        {
          print("Passed spawn check 2...");
          Instantiate(spawnObject, objectContainer.transform);
        }
        else
        {
          print("Hard cap reached");
        }
      }
      yield return new WaitForSeconds(delay);
    }
  }
}
