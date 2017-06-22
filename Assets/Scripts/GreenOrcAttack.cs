using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrcAttack : MonoBehaviour {

	public GreenOrc OrcScript;
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.GetComponent<Rabbit> () != null) 
		{
			OrcScript.Attack ();
		}
		Debug.Log ("I AM INSIDE ATTACK COLLIDER");
	}
}
