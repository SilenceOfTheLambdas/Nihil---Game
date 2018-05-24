using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ScriptManager : MonoBehaviour {

	// The manager that controlls the First Person Controller Script
	[SerializeField] public GameObject Manager;
	// The manager that controlls the Inventory Script
	[SerializeField] public GameObject InventoryManager;
	
	// Use this for initialization
	void Start () {
		Manager.SetActive(true);
		InventoryManager.SetActive(true);
	}

	public void OnInventoryOpen()
	{
	}
	
}
