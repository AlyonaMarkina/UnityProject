﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coints : Collectable {

	protected override void OnRabitHit (Rabbit rabit)
	{
		LevelController.current.addCoins (1);
		this.CollectedHide ();
	}
}
