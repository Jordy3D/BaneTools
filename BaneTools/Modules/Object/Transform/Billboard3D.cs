using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard3D : MonoBehaviour
{
  public float offset = 180;
  void Update()
  {
    if (Camera.main)
    {
      Vector3 v = Camera.main.transform.position - transform.position;
      v.x = v.z = 0.0f;
      transform.LookAt(Camera.main.transform.position - v);
      transform.localRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + offset, transform.eulerAngles.z);
    }
  }
}
