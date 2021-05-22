using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
  public class Box : MonoBehaviour
  {
    public bool snapToMouse = false;

    Vector2 startPos;
    bool isGrabbed = false;

    Vector3 mousePos;

    void Update()
    {
      mousePos = Input.mousePosition;
      mousePos = Camera.main.ScreenToWorldPoint(mousePos);

      if (isGrabbed)
      {
        transform.localPosition = new Vector3(snapToMouse ? mousePos.x : mousePos.x - startPos.x,
                                              snapToMouse ? mousePos.y : mousePos.y - startPos.y,
                                              transform.localPosition.z);
      }
    }

    void OnMouseDown()
    {
      if (Input.GetMouseButtonDown(0))
      {
        startPos.x = mousePos.x - transform.localPosition.x;
        startPos.y = mousePos.y - transform.localPosition.y;

        isGrabbed = true;
      }
    }
    private void OnMouseUp()
    {
      if (Input.GetMouseButtonUp(0))
        isGrabbed = false;
    }
  }
}