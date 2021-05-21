using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("BaneTools/Triggers/Trigger Event Handler")]
public class OnTriggerEvent : MonoBehaviour
{
  [Header("Trigger Options")]
  public bool destroyOnEnter = false;
  public bool destroyOnExit = false, notTag = false, isEnabled = true, triggerOnce = false, hasScript = false, repeatDelay = false;

  public string scriptName;
  public float repeatDelayTime;

  [Header("Trigger Events")]
  public string hitTag;
  public UnityEvent onEnter, onStay, onExit;

  public Collider otherCollider;
  [HideInInspector] public bool hasBeenTriggered;

  bool canBeTriggered = true;
  bool enterDelayed, stayDelayed, exitDelayed;

  MonoBehaviour[] scripts;
  Collider[] cols;

  public virtual void Reset()
  {
    Collider col = GetComponent<Collider>();
    if (col)
      col.isTrigger = true;
    else
      Debug.LogWarning(string.Format("The GameObject {0} does not have a collider. This will not work with trigger events.", name));
  }

  public virtual void Start() => cols = GetComponents<Collider>();

  public virtual void OnTriggerEnter(Collider other)
  {
    if (!enabled || !canBeTriggered || !enterDelayed) return;

    if (hasScript)
    {
      scripts = other.GetComponents<MonoBehaviour>();

      foreach (MonoBehaviour mono in scripts)
        if (mono.GetType().Name == scriptName)
          OnEnter(other);
    }
    else if (other.tag == hitTag || hitTag == "")
      OnEnter(other);
  }

  void OnEnter(Collider other)
  {
    otherCollider = other;
    onEnter.Invoke();

    if (triggerOnce)
      canBeTriggered = false;

    if (repeatDelay)
    {
      enterDelayed = true;
      StartCoroutine(DelayRepeatEnter(repeatDelayTime));
    }

    if (destroyOnEnter)
      Destroy(gameObject);
  }

  public virtual void OnTriggerStay(Collider other)
  {
    if (!enabled || !canBeTriggered || !enterDelayed) return;

    if (hasScript)
      {
        scripts = other.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour mono in scripts)
          if (mono.GetType().Name == scriptName)
            OnStay(other);
      }
      else if (other.tag == hitTag || (!hasScript && hitTag == ""))
        OnStay(other);
  }

  void OnStay(Collider other)
  {
    otherCollider = other;
    onStay.Invoke();

    if (repeatDelay)
    {
      stayDelayed = true;
      StartCoroutine(DelayRepeatStay(repeatDelayTime));
    }

    if (triggerOnce)
      canBeTriggered = false;
  }

  public virtual void OnTriggerExit(Collider other)
  {
    if (!enabled || !canBeTriggered || !enterDelayed) return;

    if (hasScript)
      {
        scripts = other.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour mono in scripts)
          if (mono.GetType().Name == scriptName)
            OnExit(other);
      }
      else if (other.tag == hitTag || hitTag == "")
        OnExit(other);
  }

  void OnExit(Collider other)
  {
    otherCollider = other;
    onExit.Invoke();

    if (triggerOnce)
      canBeTriggered = false;

    if (repeatDelay)
    {
      exitDelayed = true;
      StartCoroutine(DelayRepeatExit(repeatDelayTime));
    }

    if (destroyOnExit)
      Destroy(gameObject);
  }

  public virtual void DisableTriggers()
  {
    foreach (var col in cols)
      col.enabled = false;
  }

  public virtual void EnableTriggers()
  {
    foreach (var col in cols)
      col.enabled = true;
  }

  public IEnumerator DelayRepeatEnter(float _delay)
  {
    yield return new WaitForSeconds(_delay);
    enterDelayed = false;
  }

  public IEnumerator DelayRepeatStay(float _delay)
  {
    yield return new WaitForSeconds(_delay);
    stayDelayed = false;
  }

  public IEnumerator DelayRepeatExit(float _delay)
  {
    yield return new WaitForSeconds(_delay);
    exitDelayed = false;
  }
}