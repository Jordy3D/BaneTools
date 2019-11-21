using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleAgent : MonoBehaviour
{
  public Transform target;
  public NavMeshAgent agent;
  // Start is called before the first frame update
  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
  }

  // Update is called once per frame
  public virtual void Update()
  {

  }

  public void SetTarget(Transform _target)
  {
    agent.SetDestination(_target.position);
  }

  //public virtual void StopAgent()
  //{
  //  agent.enabled = false;
  //}

  //public virtual void StartAgent()
  //{
  //  agent.enabled = true;
  //}
}
