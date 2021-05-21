using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
  [AddComponentMenu("BaneTools/Editor Modules/Get Mic List")]
  public class GetMicList : MonoBehaviour
  {
    public KeyCode micListRefreshKey = KeyCode.M;
    public string[] mics;

    private void Start() => mics = Microphone.devices;

    void Update()
    {
      if (Input.GetKeyDown(micListRefreshKey))
        mics = Microphone.devices;
    }
  }
}