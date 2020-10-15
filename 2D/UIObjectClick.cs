using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIObjectClick : MonoBehaviour
{
  public UnityEvent onMouseDown, onMouseUp;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnPointerDown(PointerEventData eventData)
  {
      print("Clicked on " + transform.name);
      onMouseDown.Invoke();
  }
  void OnPointerUp(PointerEventData eventData)
  {
      onMouseUp.Invoke();
  }
}
