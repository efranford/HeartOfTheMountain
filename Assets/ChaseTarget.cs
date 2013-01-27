using UnityEngine;
using System.Collections;

public class ChaseTarget : MonoBehaviour {
	
	public Transform Target;
	NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.SetDestination(Target.position);
	}
}
