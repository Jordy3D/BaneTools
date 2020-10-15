using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectClick : MonoBehaviour
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

  void OnMouseDown()
  {
    if (Input.GetMouseButtonDown(0))
    {
      print("Clicked on " + transform.name);
      onMouseDown.Invoke();
    }
  }
  private void OnMouseUp()
  {
    if (Input.GetMouseButtonUp(0))
      onMouseUp.Invoke();
  }
}
