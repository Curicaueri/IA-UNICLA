using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgenteMovimiento : MonoBehaviour
{
	NavMeshAgent agent;
	
	public Transform[] waypoints;
	public int indexWaypoints = 0;
	
	public Transform currentDestination;
	
	
	public LayerMask playerMask;
	public float radiusDetection = 2f;
	public Transform sensorPosition;
	public bool playerDetected = false;
	
	public GameObject player;
	public Vector3 tempPositionPlayer;
	bool once = false;
	
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent <NavMeshAgent>();
		
		currentDestination = waypoints[indexWaypoints];
		
		agent.SetDestination(currentDestination.position);
    }

    // Update is called once per frame
    void Update()
    {
		if (playerDetected == false) //Jugador no detectado
		{
			float distance = Vector3.Distance(transform.position, currentDestination.position);
		//Debug.Log(distance);
		
		if(transform.position.x == currentDestination.position.x)
		{
			Debug.Log("Ya llegué.");
			indexWaypoints = (indexWaypoints + 1) % waypoints.Length;
			
			currentDestination = waypoints[indexWaypoints];
			
		}
		agent.SetDestination(currentDestination.position);
		}
		else //Jugador detectado
		{
			currentDestination.position = tempPositionPlayer;
			
			agent.SetDestination(currentDestination.position);
		}
    }
	
	private void FixedUpdate()
	{
		TargetDetected();
	}
	
	public virtual void TargetDetected()
	{
		Collider[] colliders = Physics.OverlapSphere(sensorPosition.position, radiusDetection, playerMask);
		if (colliders.Length == 0)
		{
			playerDetected = false;
			agent.stoppingDistance = 0f;
			once = false;
		}
		else
		{
			playerDetected = true;
			agent.stoppingDistance = 3f;
			void SetTempPosition();
		}
	}
	
	
	void SetTempPosition()
	{
		if (once == false)
		{
			tempPositionPlayer = player.transform.position;
			once = true;
		}
	}
	
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(sensorPosition.position, radiusDetection);
	}
}
