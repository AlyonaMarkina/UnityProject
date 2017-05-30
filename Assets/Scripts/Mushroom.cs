using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom: Collectable {

	protected override void OnRabitHit (Rabbit rabit)
	{
		//Level.current.addCoins (1);
		rabit.IncreaseSize();
		this.CollectedHide ();
	}
}
