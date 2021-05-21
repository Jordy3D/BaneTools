using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
  [AddComponentMenu("BaneTools/Modules/Lock Cursor to Window")]
  public class LockCursorToWindow : MonoBehaviour
  {
    public CursorLockMode lockMode;

    void Update()
    {
      if (Cursor.lockState != lockMode)
        Cursor.lockState = lockMode;
    }
  }

}