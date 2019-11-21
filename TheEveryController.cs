using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using NaughtyAttributes;

public class TheEveryController : MonoBehaviour
{
  [ReorderableList] public List<KeyCode> keys;
  [ReorderableList] public List<UnityEvent> events;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    foreach (KeyCode kcode in KeyCode.GetValues(typeof(KeyCode)))
    {
      if (Input.GetKeyDown(kcode))
      {
        if (keys.Contains(kcode))
        {
          events[keys.IndexOf(kcode)].Invoke();
        }
      }
    }
  }

  public void Action1()
  {
    print("A");
  }

  public void Action2()
  {
    print("1");
  }

  public void Action3()
  {
    print("?");
  }
}
