using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUIController : MonoBehaviour {

	public List<GameObject> fullLifeIcons;
	private int carrentHealthIndex;
	public void loseHealth(){
		fullLifeIcons [carrentHealthIndex].SetActive (false);
		carrentHealthIndex--;
	}
	void Start(){
		carrentHealthIndex = fullLifeIcons.Count - 1;

	}

}
