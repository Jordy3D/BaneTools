using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BT;
using Space = BT.Space;

[AddComponentMenu("BaneTools/Modules/Rotate Constantly")]
public class RotateConstantly : MonoBehaviour
{
  public Space space;
  public Axis axis;
  public float rotateSpeed;

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(new Vector3(
      axis == Axis.X || axis == Axis.XY || axis == Axis.XZ || axis == Axis.XYZ ? 1 : 0,
      axis == Axis.Y || axis == Axis.XY || axis == Axis.YZ || axis == Axis.XYZ ? 1 : 0,
      axis == Axis.Z || axis == Axis.XZ || axis == Axis.YZ || axis == Axis.XYZ ? 1 : 0)
      * rotateSpeed * Time.deltaTime,
      space == Space.Local ? UnityEngine.Space.Self : UnityEngine.Space.World);
  }
}
