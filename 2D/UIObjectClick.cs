using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace BT
{
  public class UIObjectClick : MonoBehaviour
  {
    public UnityEvent onMouseDown, onMouseUp;

    void OnPointerDown(PointerEventData eventData) => onMouseDown.Invoke();
    void OnPointerUp(PointerEventData eventData) => onMouseUp.Invoke();
  } 
}
