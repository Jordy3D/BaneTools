using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BT
{
  public class SimpleAgent : MonoBehaviour
  {
    public Transform target;
    public NavMeshAgent agent;

    void Start() => agent = GetComponent<NavMeshAgent>();

    private void Update() => SetTarget(target);

    public void SetTarget(Transform _target) => agent.SetDestination(_target.position);
    public virtual void StopAgent() => agent.enabled = false;
    public virtual void StartAgent() => agent.enabled = true;
  } 
}
