using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableChild : MonoBehaviour
{
  public void EnableChild()
  {
    foreach (Transform child in transform)
    {
      child.gameObject.SetActive(true);
    }
  }
  public void DisableChild()
  {
    foreach (Transform child in transform)
    {
      child.gameObject.SetActive(false);
    }
  }
}
