using UnityEngine;

[AddComponentMenu("BaneTools/Modules/Look at Transform")]
public class LookAtTransform : MonoBehaviour
{
  public Transform target;
  public bool followXPos, followYPos, followZPos;
  public Vector3 rotationOffset;
  public bool smoothFollow;
  public float lookSpeed;

  // Update is called once per frame
  void Update()
  {
    if (target)
    {
      if (smoothFollow)
      {
        Quaternion targetRot = Quaternion.LookRotation(
                                           new Vector3(followXPos ? target.position.x : transform.position.x,
                                                       followYPos ? target.position.y : transform.position.y,
                                                       followZPos ? target.position.z : transform.position.z)
                                                       - transform.position);
        transform.localRotation = Quaternion.Slerp(transform.rotation, targetRot * Quaternion.Euler(rotationOffset), Time.deltaTime * lookSpeed);

        //transform.localRotation = newRot * Quaternion.Euler(rotationOffset);
      }
      else
      {
        //transform.localRotation = 
        //  Quaternion.LookRotation(new Vector3(followXPos ? target.position.x : transform.position.x,
        //                                      followYPos ? target.position.y : transform.position.y,
        //                                      followZPos ? target.position.z : transform.position.z)) 
        //                                      * Quaternion.Euler(rotationOffset);


        transform.LookAt(new Vector3(followXPos ? target.position.x : transform.position.x,
                                     followYPos ? target.position.y : transform.position.y,
                                     followZPos ? target.position.z : transform.position.z));
      }
    }
  }
}
