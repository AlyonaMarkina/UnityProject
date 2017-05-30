using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
	
	public Vector3 MoveBy;
	public float moveSpeed;
	Vector3 pointA;
	Vector3 pointB;

	Vector3 target;
	Vector3 my_pos;

	bool going_to_a = false;
	public float pause ;
	float TimeToGo;
	void Start()
	{
		pointA = transform.position;
		pointB = pointA + MoveBy;
	}

	void Update()
	{
		if (TimeToGo > Time.time) {
			return;
		}
		if (going_to_a)
		{
			target = pointA;
		}
		else
		{
			target = pointB;
		}
		my_pos = transform.position;
		MoveToPoint(target);

		if (isArrived(transform.position, target))
		{
				
			going_to_a = !going_to_a;
				TimeToGo=Time.time+pause;

		}


	}

	void MoveToPoint(Vector3 destination)
	{transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * moveSpeed);
	}

	bool isArrived(Vector3 pos, Vector3 target)
	{
		pos.z = 0;
		target.z = 0;
		return Vector3.Distance(pos, target) < 0.02f;
	}
}