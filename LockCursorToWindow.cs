using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("BaneTools/Lock Cursor to Window")]
public class LockCursorToWindow : MonoBehaviour
{
  public CursorLockMode lockMode;
  //public KeyCode unlockKey;

  // Update is called once per frame
  void Update()
  {
    if (Cursor.lockState != lockMode)
    {
      Cursor.lockState = lockMode;
    }
  }
}
