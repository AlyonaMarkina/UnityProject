using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruiteUIController : MonoBehaviour {
	public UILabel label;
	public int maxFruite;
	public void setFruitesCount(int number){
		label.text = number + "/" + maxFruite;
	}

}
