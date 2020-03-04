using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
	Vector3 velocity;
	Rigidbody myRididbody;
	void Start () {
		myRididbody = GetComponent<Rigidbody>();
	}

	public void Move(Vector3 _velocity){
		velocity=_velocity;
	}

	private void FixedUpdate(){
		myRididbody.MovePosition(myRididbody.position+ velocity* Time.fixedDeltaTime);
	}

	public void LookAt(Vector3 lookPoint){
		Vector3 heightCorrectPoint = new Vector3(lookPoint.x,transform.position.y,lookPoint.z);
		transform.LookAt(heightCorrectPoint);
	}
}
