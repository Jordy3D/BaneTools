using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
  [AddComponentMenu("BaneTools/Modules/Print String")]
  public class PrintString : MonoBehaviour
  {
    public string myString;

    public void Print() => print(myString);

    public void Print(string _string) => print(_string);
  }

}