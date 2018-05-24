using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemySight : MonoBehaviour
{

	public float fieldOfViewAngle = 110f;
	public bool playerInSight;
	public Vector3 personalLastSighting;

	private NavMeshAgent nav;
	private SphereCollider col;
	private Animator anim;
	private GameObject player;
	private Animator playerAnim;

	private void Awake()
	{
		nav = GetComponent<NavMeshAgent>();
		col = GetComponent<SphereCollider>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
}
