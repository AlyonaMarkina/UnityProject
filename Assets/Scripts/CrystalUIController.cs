using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalUIController : MonoBehaviour {

	public GameObject RedCrystal;
	public GameObject BlueCrystal;
	public GameObject GreenCrystal;

	public enum CrystalType{
		RED,BLUE,GREEN 
	}
	public void CollectedCrystal(CrystalType type){
		switch (type) {
		case CrystalType.RED:
			RedCrystal.SetActive (true);
			break;
		case CrystalType.GREEN:
			GreenCrystal.SetActive (true);
			break;
		case CrystalType.BLUE:
			BlueCrystal.SetActive (true);
			break;
		}
	}
}
