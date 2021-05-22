using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BT
{
  [AddComponentMenu("BaneTools/Modules/Run Event on Delay")]
  public class EventOnDelay : MonoBehaviour
  {
    float delay;
    public UnityEvent delayedEvent;

    public void DelayedEvent(float _delay)
    {
      delay = _delay;
      print("Delayed event starting...");
      StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
      yield return new WaitForSeconds(delay);
      delayedEvent.Invoke();
    }
  } 
}
