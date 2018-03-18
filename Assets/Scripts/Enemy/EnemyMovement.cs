using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
	private Transform player; //Reference to the player's position 
	private float playerHealth;
	private float enemyHealth;

	private NavMeshAgent nav;

	void Awake()
	{
		// Set up the refrences
		player = GameObject.FindGameObjectWithTag("Player").transform;
		playerHealth = player.GetComponent<PlayerInventory>().currentHealth;
		enemyHealth = GetComponent<EnemyInventory>().currentHealth;

		nav = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		// If the enemy and the player have health left....
		if (enemyHealth > 0 && playerHealth > 0)
		{
			//.......set the destination of the nav mesh agent to the player
			nav.SetDestination(player.position);
		}
		//Otherwise
		else
		{
			//.....disable the nav mesh agent
			nav.enabled = false;
		}
	}
	
}