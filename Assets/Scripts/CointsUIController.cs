using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CointsUIController : MonoBehaviour {

	public UILabel lable;

	public void setCointsLable(int amount){
		lable.text = amount.ToString ("0000");

	}
}
