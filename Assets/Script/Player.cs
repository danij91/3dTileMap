using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(PlayerController))]
[RequireComponent (typeof(GunController))]
public class Player : LivingEntity
{
    public float moveSpeed = 5;

	Camera viewCamera;
	PlayerController controller;
	GunController gunController;
    protected override void Start()
    {
		base.Start();
		controller = GetComponent<PlayerController>();
		gunController = GetComponent<GunController>();
		viewCamera = Camera.main;
    }

    void Update()
    {
		//이동을 입력받는곳
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
		controller.Move(moveVelocity);

		//바라보는 방향을 입력받는곳
		Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
		Plane groundPlane = new Plane(Vector3.up,Vector3.zero);
		float rayDistance;

		if(groundPlane.Raycast(ray,out rayDistance)){
			Vector3 point = ray.GetPoint(rayDistance);
			Debug.DrawLine(ray.origin,point,Color.red);
			controller.LookAt(point);
		}

		//무기 조작 입력받는곳
		if(Input.GetMouseButton(0)){
			gunController.Shoot();
		}
    }
}
