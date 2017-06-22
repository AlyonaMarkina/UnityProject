using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour {
	public static LevelController current;
	private int cointsCollected;
	public LifeUIController lifeController;
	private int carrentHealth;
	public FruiteUIController fruiteController;
	public CrystalUIController crystalController;
	private int fruiteCollected;
	public CointsUIController cointsController;
 	Vector3 startingPosition;
	void Awake() {
		carrentHealth = 3;
		current = this;

	}

	public void CollectCrystal(CrystalUIController.CrystalType type)
	{
		crystalController.CollectedCrystal (type);	
	}
	public void collecedFruite(int number){
		fruiteCollected += number;
		fruiteController.setFruitesCount (fruiteCollected);
	}
	public void setStartPosition(Vector3 pos) {
		this.startingPosition = pos;
	}

	public void onRabitDeath(Rabbit rabit) {
		//При смерті кролика повертаємо на початкову позицію
		if(carrentHealth==1){
			SceneManager.LoadScene ("ChooseLevelScene");

		}
		rabit.transform.position = this.startingPosition;
		lifeController.loseHealth ();
		carrentHealth--;
	}
	public void addCoins(int amount){
		cointsCollected += amount;
		cointsController.setCointsLable (cointsCollected);
	}

}