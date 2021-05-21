using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
  [AddComponentMenu("BaneTools/Modules/Enable Disable Children")]
  public class EnableDisableChild : MonoBehaviour
  {
    public void EnableChild()
    {
      foreach (Transform child in transform)
        child.gameObject.SetActive(true);
    }
    public void DisableChild()
    {
      foreach (Transform child in transform)
        child.gameObject.SetActive(false);
    }
  } 
}
