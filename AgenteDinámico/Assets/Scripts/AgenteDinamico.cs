using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AgentState {Idle, Rotation, Attack}

public class AgenteDinamico : MonoBehaviour
{
	public AgentState currentState;
	
	NavMeshAgent agent;
	
	public Transform[] waypoints;
	public int indexWaypoints = 0;
	
	public Transform currentDestination;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
