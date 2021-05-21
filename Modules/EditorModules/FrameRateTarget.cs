using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
  [AddComponentMenu("BaneTools/Editor Modules/Frame Rate Target")]
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

    void Update()
    {
      if (previousTarget != targetFrameRate) // If the framerate isn't set...
      {
        if (targetFrameRate <= 0) // If the framerate is too low 
          targetFrameRate = 5; // ... bring it back up a bit

        previousTarget = targetFrameRate; // ...store the previous framerate
        Application.targetFrameRate = targetFrameRate; // ...set the application framerate 
      }
    }
  } 
}
