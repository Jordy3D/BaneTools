using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BT;

[AddComponentMenu("BaneTools/Modules/Mimic Transform")]
public class FollowTransform : MonoBehaviour
{
  public Transform target;
  public Vector3 transformOffset, rotationOffset;
  public bool followXPos, followYPos, followZPos, followXRot, followYRot, followZRot;

  public bool smoothFollow = false;
  [Range(0,50)]
  public float speed = .5f, distance = 0;

  // Update is called once per frame
  void Update()
  {
    if (!transform.position.CloseTo(target.position, distance))
    {
      transform.position = !smoothFollow ?
                         new Vector3(followXPos ? target.position.x : transform.position.x,
                                     followYPos ? target.position.y : transform.position.y,
                                     followZPos ? target.position.z : transform.position.z)
                                     + transformOffset :
                         Vector3.Lerp(transform.position,
                         new Vector3(followXPos ? target.position.x : transform.position.x,
                                     followYPos ? target.position.y : transform.position.y,
                                     followZPos ? target.position.z : transform.position.z)
                                     + transformOffset,
                         Time.deltaTime * speed);
    }

    transform.rotation = !smoothFollow ?
                         Quaternion.Euler(followXRot ? target.eulerAngles.x : transform.eulerAngles.x,
                                          followYRot ? target.eulerAngles.y : transform.eulerAngles.y,
                                          followZRot ? target.eulerAngles.z : transform.eulerAngles.z)
                                          * Quaternion.Euler(rotationOffset) :
                         Quaternion.Slerp(transform.rotation,
                         Quaternion.Euler(followXRot ? target.eulerAngles.x : transform.eulerAngles.x,
                                          followYRot ? target.eulerAngles.y : transform.eulerAngles.y,
                                          followZRot ? target.eulerAngles.z : transform.eulerAngles.z)
                                          * Quaternion.Euler(rotationOffset),
                         Time.deltaTime * speed); ;
  }
}
