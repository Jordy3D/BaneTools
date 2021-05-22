using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BT;
using Space = BT.Space;

[AddComponentMenu("BaneTools/Modules/Move Constantly")]
public class MoveConstantly : MonoBehaviour
{
  public Space space;
  public Direction dir;
  public float speed;

  // Update is called once per frame
  void Update()
  {
    int i = (int)dir;

    switch (i)
    {
      //FB - LR - UP
      case 0:
        transform.position += (space == Space.Local ? transform.forward : Vector3.forward) * speed * Time.deltaTime;
        break;
      case 1:
        transform.position += (space == Space.Local ? -transform.forward : -Vector3.forward) * speed * Time.deltaTime;
        break;
      case 2:
        transform.position += (space == Space.Local ? -transform.right : -Vector3.right) * speed * Time.deltaTime;
        break;
      case 3:
        transform.position += (space == Space.Local ? transform.right : Vector3.right) * speed * Time.deltaTime;
        break;
      case 4:
        transform.position += (space == Space.Local ? transform.up : Vector3.up) * speed * Time.deltaTime;
        break;
      case 5:
        transform.position += (space == Space.Local ? -transform.up : -Vector3.up) * speed * Time.deltaTime;
        break;
    }

    //switch (space)
    //{
    //  case Space.Local:
    //    switch (i)
    //    {
    //      case 0:
    //        transform.position += transform.forward * speed * Time.deltaTime;
    //        break;
    //      case 1:
    //        transform.position += -transform.forward * speed * Time.deltaTime;
    //        break;
    //      case 2:
    //        transform.position += -transform.right * speed * Time.deltaTime;
    //        break;
    //      case 3:
    //        transform.position += transform.right * speed * Time.deltaTime;
    //        break;
    //      case 4:
    //        transform.position += transform.up * speed * Time.deltaTime;
    //        break;
    //      case 5:
    //        transform.position += -transform.up * speed * Time.deltaTime;
    //        break;
    //    }
    //    break;
    //  case Space.World:
    //    switch (i)
    //    {
    //      case 0:
    //        transform.position += Vector3.forward * speed * Time.deltaTime;
    //        break;
    //      case 1:
    //        transform.position += -Vector3.forward * speed * Time.deltaTime;
    //        break;
    //      case 2:
    //        transform.position += -Vector3.right * speed * Time.deltaTime;
    //        break;
    //      case 3:
    //        transform.position += Vector3.right * speed * Time.deltaTime;
    //        break;
    //      case 4:
    //        transform.position += Vector3.up * speed * Time.deltaTime;
    //        break;
    //      case 5:
    //        transform.position += -Vector3.up * speed * Time.deltaTime;
    //        break;
    //    }
    //    break;
    //}
  }
}