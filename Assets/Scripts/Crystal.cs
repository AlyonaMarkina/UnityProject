using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Collectable {

	public CrystalUIController.CrystalType type;
	protected override void OnRabitHit (Rabbit rabit)
	{
		LevelController.current.CollectCrystal (type);
		this.CollectedHide ();
	}
}
