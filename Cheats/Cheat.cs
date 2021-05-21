using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BT
{
  [AddComponentMenu("BaneTools/Cheats/Cheat")]
  public class Cheat : MonoBehaviour
  {
    public KeyCode[] sequence;
    private int sequenceIndex;

    public UnityEvent onSuccess;
    private void Update()
    {
      if (Input.GetKeyDown(sequence[sequenceIndex]))
      {
        if (++sequenceIndex == sequence.Length)
        {
          sequenceIndex = 0;
          onSuccess.Invoke();
        }
      }
      else if (Input.anyKeyDown)
        sequenceIndex = 0;
    }
  } 
}
