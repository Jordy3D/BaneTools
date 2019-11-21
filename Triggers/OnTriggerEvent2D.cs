using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using NaughtyAttributes;

public class OnTriggerEvent2D : MonoBehaviour
{
  [Tag]
  [BoxGroup("Trigger Events")]
  public string hitTag;
  [BoxGroup("Trigger Events")]
  public UnityEvent onEnter, onStay, onExit;

  public Collider2D otherCollider;

  public virtual void Reset()
  {
    Collider2D col = GetComponent<Collider2D>();
    if (col)
    {
      col.isTrigger = true;
    }
    else
    {
      Debug.LogWarning(string.Format("The GameObject {0} does not have a collider. This will not work with trigger events.", name));
    }
  }

  public virtual void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == hitTag || hitTag == "")
    {
      otherCollider = other;
      onEnter.Invoke();
    }
  }

  public virtual void OnTriggerStay2D(Collider2D other)
  {
    if (other.tag == hitTag || hitTag == "")
    {
      otherCollider = other;
      onStay.Invoke();
    }
  }

  public virtual void OnTriggerExit2D(Collider2D other)
  {
    if (other.tag == hitTag || hitTag == "")
    {
      otherCollider = other;
      onExit.Invoke();
    }
  }
}
