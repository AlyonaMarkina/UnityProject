using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour {
	private bool rabbitBig=false;
	public float speed = 2.0f;
	Rigidbody2D myBody = null;
	bool isGrounded = false;
	bool JumpActive = false;

	float JumpTime = 0f;

	public float MaxJumpTime = 2f;
	public float JumpSpeed = 2f;
	// Use this for initialization
	private IEnumerator Respawn(){
		yield return new WaitForSeconds (2f);
		LevelController.current.onRabitDeath (GetComponent<Rabbit> ());
	}
	void Start () {
		myBody = this.GetComponent<Rigidbody2D> ();
		LevelController.current.setStartPosition (transform.position);
	}

	public void IncreaseSize(){
		if (rabbitBig) {
			return;
		} else {
			transform.localScale = new Vector3 (1.3f, 1.3f, 0);
			rabbitBig = true;
		}
	}
	public void DecreaseSize(){
		if(rabbitBig){
			transform.localScale= new Vector3(1, 1, 0);
			rabbitBig = false;
	}
		else{
			rabbitDie ();
			StartCoroutine (Respawn ());
		}
	}
	public void rabbitDie(){
		GetComponent<Animator> ().SetBool ("Die", true);
	}
	void FixedUpdate () {
		//[-1, 1]

		float value = Input.GetAxis ("Horizontal");
		if (Mathf.Abs (value) > 0) {
			Vector2 vel = myBody.velocity;
			vel.x = value * speed;
			myBody.velocity = vel;
		}
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		if(value < 0) {
			sr.flipX = true;
		} else if(value > 0) {
			sr.flipX = false;
		}
		Animator animator = GetComponent<Animator> ();
		if(Mathf.Abs(value) > 0) {
			animator.SetBool ("run", true);
		} else {
			animator.SetBool ("run", false);
		}
		Vector3 from = transform.position + Vector3.up * 0.3f;
		Vector3 to = transform.position + Vector3.down * 0.1f;
		int layer_id = 1 << LayerMask.NameToLayer ("Ground");
		//Перевіряємо чи проходить лінія через Collider з шаром Ground
		RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
		if (hit) {
			if (hit.transform != null
			   && hit.transform.GetComponent<MovingPlatform> () != null) {
				Debug.Log ("HERE");
				transform.SetParent (hit.transform);
			} else {
				transform.SetParent (null);
		    }
			isGrounded = true;
		} else {
			isGrounded = false;
		}
		if(Input.GetButtonDown("Jump") && isGrounded) {
			this.JumpActive = true;
		}
		if(this.JumpActive) {
			//Якщо кнопку ще тримають
			if(Input.GetButton("Jump")) {
				this.JumpTime += Time.deltaTime;
				if (this.JumpTime < this.MaxJumpTime) {
					Vector2 vel = myBody.velocity;
					vel.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime);
					myBody.velocity = vel;
				}
			} else {
				this.JumpActive = false;
				this.JumpTime = 0;
			}
		}
		if(this.isGrounded) {
			animator.SetBool ("jump", false);
		} else {
			animator.SetBool ("jump", true);
		}
		//Намалювати лінію (для розробника)
		Debug.DrawLine (from, to, Color.red);
	}

}
