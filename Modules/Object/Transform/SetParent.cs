using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
  [AddComponentMenu("BaneTools/Modules/Set Parent")]
  public class SetParent : MonoBehaviour
  {
    public bool setParent;
    public Transform parent;

    // Update is called once per frame
    void Update()
    {
      if (setParent)
      {
        if (parent && transform.parent != parent)
          transform.SetParent(parent);
        else
          transform.SetParent(null);

        setParent = false;
      }
    }

    public void Parent(Transform _transform) => transform.SetParent(_transform);

    public void UnParent() => transform.SetParent(null);
  } 
}
