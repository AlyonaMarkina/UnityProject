using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruite : Collectable {

	protected override void OnRabitHit (Rabbit rabit)
	{
		LevelController.current.collecedFruite (1);
		this.CollectedHide ();
	}
}
