using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BT
{
  [AddComponentMenu("BaneTools/Modules/Run Event Constantly")]
  public class RunEventConstantly : MonoBehaviour
  {
    public bool isEnabled = true;
    public float delay;

    public UnityEvent onEvent;

    void Start()
    {
      if (isEnabled)
        StartCoroutine(RunConstantly());
    }
    IEnumerator RunConstantly()
    {
      while (isEnabled)
      {
        yield return new WaitForSeconds(delay);
        print("Spawning!");
        onEvent.Invoke();
      }
    }
  }

}