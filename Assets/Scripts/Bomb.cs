using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Collectable {
	protected override void OnRabitHit (Rabbit rabit)
	{
		//Level.current.addCoins (1);
		rabit.DecreaseSize();
		this.CollectedHide ();
	}
		
	}

