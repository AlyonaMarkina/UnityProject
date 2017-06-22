using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownOrc : MonoBehaviour {
	private Rigidbody2D myBody;
	private SpriteRenderer spriteRenderer;
	private Animator animator;
	public float WalkSpeed;
	public float offset;
	private Vector3 pointA;
	private Vector3 pointB;

	void Start()
	{
		myBody = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		pointA = transform.position;
		pointB = new Vector3(pointA.x + offset, pointA.y, pointA.z);
	}

	public enum Mode {
		GoToA,
		GoToB,
		Attack,
		Die
	}

	Mode mode = Mode.GoToB;

	void FixedUpdate()
	{
		if (mode == Mode.Attack)
			return;
		
		float value = this.getDirection ();

		if (value < 0)
		{
			spriteRenderer.flipX = false;
		}
		else if (value > 0)
		{
			spriteRenderer.flipX = true;
		}
		if (RabbitInsideZone ()) {
			mode = Mode.Attack;
		} else if (mode == Mode.Attack) {
			mode = Mode.GoToB;
		}

		Vector2 vel = myBody.velocity;

			SetAnimatorWalk ();
			vel.x = value * WalkSpeed;
		myBody.velocity = vel;

		if (IsArrived())
		{
			mode = mode == Mode.GoToA ? Mode.GoToB : Mode.GoToA;
		}

		ReturnToPatrolZone ();
	}

	private void ReturnToPatrolZone()
	{
		if (transform.position.x < pointA.x)
		{
			mode = Mode.GoToB;
		}
		else if (transform.position.x > pointB.x)
		{
			mode = Mode.GoToA;
		}
	}

	public void Attack()
	{
		StartCoroutine (Attacking ());

	}

	private IEnumerator Attacking()
	{
		mode = Mode.Attack;
		animator.SetBool ("attack", true);
		yield return new WaitForSeconds (0.5f);
		Rabbit.current.rabbitDie ();
		mode = Mode.GoToB;

	}

	private void KeepInBounds()
	{
		if (transform.position.x < pointA.x)
		{
			mode = Mode.GoToB;
		}
		else if (transform.position.x > pointB.x)
		{
			mode = Mode.GoToA;
		}
	}
	bool IsArrived()
	{
		if (mode == Mode.GoToA)
		{
			return Mathf.Abs (transform.position.x - pointA.x) < 0.1f;
		}
		else if (mode == Mode.GoToB)
		{
			return Mathf.Abs (transform.position.x - pointB.x) < 0.1f;
		}
		else return false;
	}

	void SetAnimatorWalk()
	{
		animator.SetBool("walk", true);
		animator.SetBool("run", false);
		animator.SetBool("attack", false);
	}

	float getDirection() {

		if(mode == Mode.GoToA) {
			return -1; 
		} else if(mode == Mode.GoToB) {
			return 1; //Move right
		}
		return 0; //No movement
	}

	private bool RabbitInsideZone()
	{
		Vector3 rabbit_vector = Rabbit.current.transform.position;
		return rabbit_vector.x >= pointA.x && rabbit_vector.x <= pointB.x;
	}
}
