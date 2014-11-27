﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamagePopupSpawner : MonoBehaviour {

	public GameObject popupPrefab;

	public Transform positionSpawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void spawnDamagePopup(Transform transform, int damage)
	{
		Debug.Log("POSITION ("+ transform.position.x+","+transform.position.y+")");

		GameObject damageGameObject = (GameObject) Instantiate(popupPrefab, positionSpawn.position, transform.rotation);

		damageGameObject.GetComponentInChildren<Text>().text = damage.ToString();
	}
}
