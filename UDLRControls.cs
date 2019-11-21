using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UDLRControls : MonoBehaviour
{
  public UDLRAxis axis;
  public UDLRDirection dir;
  public MovementMode mode = MovementMode.Rigidbody;

  public Transform player;
  public Rigidbody rigid;
  public float speed = 5f;


  public float transitionDelay = 3f;
  public bool canTransition = true;

  // Start is called before the first frame update
  void Start()
  {
    if (!player)
      player = transform;

    rigid = GetComponent<Rigidbody>();

    if (!rigid && mode == MovementMode.Rigidbody)
      print("Rigidbody not found.");
  }

  // Update is called once per frame
  void Update()
  {
    float inputX = Input.GetAxis("Horizontal");
    float inputY = Input.GetAxis("Vertical");

    if (inputY > 0)
      dir = UDLRDirection.Up;
      InputSelector(mode);
    if (inputY < 0)
      dir = UDLRDirection.Down;
      InputSelector(mode);

    if (inputX > 0)
      dir = UDLRDirection.Right;
      InputSelector(mode);
    if (inputX < 0)
      dir = UDLRDirection.Left;
      InputSelector(mode);

    if (inputY == 0 && inputX == 0)
      dir = UDLRDirection.None;
  }

  void InputSelector(MovementMode _mode)
  {
    switch (_mode)
    {
      case MovementMode.Translate:
        HandleInputsTranslate(dir);
        break;
      case MovementMode.Rigidbody:
        HandleInptusRigidbody(dir);
        break;
      case MovementMode.Rigidbody2D:
        break;
    }
  }

  void HandleInputsTranslate(UDLRDirection _dir)
  {
    switch (axis)
    {
      case UDLRAxis.XY:
        switch (_dir)
        {
          case UDLRDirection.Up:
            player.position += Vector3.up * speed * Time.deltaTime;
            break;
          case UDLRDirection.Down:
            player.position -= Vector3.up * speed * Time.deltaTime;
            break;
          case UDLRDirection.Left:
            player.position -= Vector3.right * speed * Time.deltaTime;
            break;
          case UDLRDirection.Right:
            player.position += Vector3.right * speed * Time.deltaTime;
            break;
        }
        break;
      case UDLRAxis.XZ:
        switch (_dir)
        {
          case UDLRDirection.Up:
            player.position += Vector3.forward * speed * Time.deltaTime;
            break;
          case UDLRDirection.Down:
            player.position -= Vector3.forward * speed * Time.deltaTime;
            break;
          case UDLRDirection.Left:
            player.position -= Vector3.right * speed * Time.deltaTime;
            break;
          case UDLRDirection.Right:
            player.position += Vector3.right * speed * Time.deltaTime;
            break;
        }
        break;
      case UDLRAxis.YZ:
        break;
    }
  }

  void HandleInptusRigidbody(UDLRDirection _dir)
  {
    switch (axis)
    {
      case UDLRAxis.XY:
        switch (_dir)
        {
          case UDLRDirection.Up:
            rigid.AddForce(Vector3.up * speed, ForceMode.Impulse);
            break;
          case UDLRDirection.Down:
            rigid.AddForce(-Vector3.up * speed, ForceMode.Impulse);
            break;
          case UDLRDirection.Left:
            rigid.AddForce(-Vector3.right * speed, ForceMode.Impulse);
            break;
          case UDLRDirection.Right:
            rigid.AddForce(Vector3.right * speed, ForceMode.Impulse);
            break;
        }
        break;
      case UDLRAxis.XZ:
        switch (_dir)
        {
          case UDLRDirection.Up:
            rigid.AddForce(Vector3.forward * speed, ForceMode.Impulse);
            break;
          case UDLRDirection.Down:
            rigid.AddForce(-Vector3.forward * speed, ForceMode.Impulse);
            break;
          case UDLRDirection.Left:
            rigid.AddForce(-Vector3.right * speed, ForceMode.Impulse);
            break;
          case UDLRDirection.Right:
            rigid.AddForce(Vector3.right * speed, ForceMode.Impulse);
            break;
        }
        break;
      case UDLRAxis.YZ:
        break;
    }
  }

  public void StartTransitionCooldown()
  {
    StartCoroutine(TransitionCooldown());
  }

  IEnumerator TransitionCooldown()
  {
    canTransition = false;
    yield return new WaitForSeconds(transitionDelay);
    canTransition = true;
  }
}

public enum UDLRAxis
{
  XY,
  XZ,
  YZ
}
public enum UDLRDirection
{
  Up,
  Down,
  Left,
  Right,
  None
}
public enum MovementMode
{
  Translate,
  Rigidbody,
  Rigidbody2D
}
