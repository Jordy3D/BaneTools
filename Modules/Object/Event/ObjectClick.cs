using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BT
{
  public class ObjectClick : MonoBehaviour
  {
    public UnityEvent onMouseDown, onMouseUp;
    void OnMouseDown()
    {
      if (Input.GetMouseButtonDown(0))
        onMouseDown.Invoke();
    }
    private void OnMouseUp()
    {
      if (Input.GetMouseButtonUp(0))
        onMouseUp.Invoke();
    }
  } 
}
