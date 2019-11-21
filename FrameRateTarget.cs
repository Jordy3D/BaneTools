using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("BaneTools/Frame Rate Target")]
public class FrameRateTarget : MonoBehaviour
{
  public int targetFrameRate = 30;
  private int previousTarget = 0;

  private void Awake()
  {
    QualitySettings.vSyncCount = 0;

    Application.targetFrameRate = targetFrameRate;
    previousTarget = targetFrameRate;
  }

  // Update is called once per frame
  void Update()
  {
    if (previousTarget != targetFrameRate)
    {
      if (targetFrameRate <= 0)
      {
        targetFrameRate = 5;
      }
      previousTarget = targetFrameRate;
      Application.targetFrameRate = targetFrameRate;
    }
  }
}
