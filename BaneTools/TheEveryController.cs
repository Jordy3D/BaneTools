using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BT
{
  public class TheEveryController : MonoBehaviour
  {
    public List<KeyCode> keys;
    public List<UnityEvent> events;

    void Update()
    {
      foreach (KeyCode kcode in KeyCode.GetValues(typeof(KeyCode)))
      {
        if (Input.GetKeyDown(kcode))
          if (keys.Contains(kcode))
            events[keys.IndexOf(kcode)].Invoke();
      }
    }

    public void TestAction(string output) => print(output);
  }

}