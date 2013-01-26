using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HOMPlayer : MonoBehaviour {
	
	public int AcornsCollected = 0;
	public Transform SquirrelModel;
	
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
	CharacterController controller;
	
	public AudioClip WalkSound;
	public AudioClip RunSound;
	public AudioClip PickedUpAcornSound;
	
	void Start()
	{
		controller = GetComponent<CharacterController>();
	}
	
    void Update() 
	{
        if (controller.isGrounded)
		{
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			
			if(moveDirection == Vector3.zero)
			{
				animation.CrossFade("Idle");
			}
			else if(Input.GetKey(KeyCode.LeftShift))
			{
				animation.CrossFade("Run");
				moveDirection *= 2.5f;
			}
			else
			{
				animation.CrossFade("Walk");
			}
			
			if(Input.GetKey(KeyCode.LeftControl))
			{
				animation.CrossFade("Crouch");
			}
            if (Input.GetButton("Jump"))
			{
                moveDirection.y = jumpSpeed;
				animation.Blend("Jump");
			}
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
	

    void OnTriggerEnter(Collider collision) 
	{
		WorthPoints points = collision.gameObject.GetComponent<WorthPoints>();
		if(points != null)
		{
			animation.CrossFade("Grab");
			AcornsCollected += points.PointsWorth;
			AudioSource.PlayClipAtPoint(PickedUpAcornSound,transform.position,1.0f);
			Destroy(collision.gameObject);
		}
	}
}
