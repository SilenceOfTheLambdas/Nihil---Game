using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
/*	private Transform player; //Reference to the player's position 
	private float playerHealth;
	private float enemyHealth;

	private NavMeshAgent nav;

	void Start()
	{
		// Set up the refrences
		player = GameObject.FindGameObjectWithTag("Player").transform;
		playerHealth = player.GetComponent<PlayerInventory>().currentHealth;
		enemyHealth = GetComponent<EnemyInventory>().currentHealth;

		nav = GetComponent<NavMeshAgent>();
		NavMeshHit hit;
	}

	void Update()
	{
		NavMeshHit hit;
		// If the enemy and the player have health left....
		if (enemyHealth > 0 && playerHealth > 0 && !nav.Raycast(player.position, out hit))
		{
			//.......set the destination of the nav mesh agent to the player
			nav.SetDestination(player.position);
		}
		else
		{
			nav.enabled = false;
		}

	} */

/*	public NavMeshAgent agent;
	public FirstPersonController controller;

	public enum State
	{
		PATROL,
		CHASE,
		INESTIGATE
	}

	public State state;
	private bool alive;
	
	// Variables for Patrolling
	public GameObject[] waypoints;
	private int waypointInd;
	public float patrolSpeed = 0.5f;
	
	// Variables for chasing
	public float chaseSpeed = 1f;
	public GameObject target;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		controller = GetComponent<FirstPersonController>();

		agent.updatePosition = true;
		agent.updateRotation = false;

		waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		waypointInd = Random.Range(0, waypoints.Length);

		state = EnemyMovement.State.PATROL;

		alive = true;

		StartCoroutine("FSM");
	}

	IEnumerator FSM()
	{
		while (alive)
		{
			switch (state)
			{
				case State.PATROL:
					Patrol();
					break;
				case State.CHASE:
					Chase();
					break;
			}

			yield return null;
		}
	}

	void Patrol()
	{
		agent.speed = patrolSpeed;
		if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) >= 2)
		{
			agent.SetDestination(waypoints[waypointInd].transform.position);
			controller.movementspeed.(agent.desiredVelocity, false, false);
		}
	} */

}