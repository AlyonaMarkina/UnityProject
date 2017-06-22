using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevelTrigger : MonoBehaviour {

	public string LevelName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.GetComponent<Rabbit> () != null) {
			SceneManager.LoadScene(LevelName);
		}
	}
}
