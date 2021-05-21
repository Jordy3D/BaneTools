using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
  public class TiltDetector : MonoBehaviour
  {
    public StartReference startReference = StartReference.Up;
    public TargetReference targetReference = TargetReference.Down;

    public float tiltThreshold;
    public bool isTilted;

    public float tiltAmount;

    Vector3 transformVector, worldVector;

    void Update()
    {
      CheckTilt();
    }

    void CheckTilt()
    {
      switch (startReference)
      {
        case StartReference.Up:
          transformVector = transform.up;
          break;
        case StartReference.Down:
          transformVector = -transform.up;
          break;
        case StartReference.Left:
          transformVector = -transform.right;
          break;
        case StartReference.Right:
          transformVector = transform.right;
          break;
        case StartReference.Forward:
          transformVector = transform.forward;
          break;
        case StartReference.Back:
          transformVector = -transform.forward;
          break;
      }

      switch (targetReference)
      {
        case TargetReference.Up:
          worldVector = Vector3.up;
          break;
        case TargetReference.Down:
          worldVector = Vector3.down;
          break;
        case TargetReference.Left:
          worldVector = Vector3.left;
          break;
        case TargetReference.Right:
          worldVector = Vector3.right;
          break;
        case TargetReference.Forward:
          worldVector = Vector3.forward;
          break;
        case TargetReference.Back:
          worldVector = Vector3.back;
          break;
      }

      tiltAmount = Vector3.Dot(transformVector, worldVector);

      isTilted = tiltAmount > tiltThreshold;
    }
  }

  public enum StartReference
  {
    Up,
    Down,
    Left,
    Right,
    Forward,
    Back
  }

  public enum TargetReference
  {
    Up,
    Down,
    Left,
    Right,
    Forward,
    Back
  } 
}
