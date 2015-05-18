﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovementTest: MonoBehaviour {

	//private bool xpressed = false;
	//private bool ypressed = false;
	[SerializeField]private bool inAir = false;
	[SerializeField]private bool doubleJump = false;

	public float jumpSpeed;
	public float movementSpeed;

	public float height;

	public Rigidbody rb;
	public GameObject Target;

	public GameObject cam;
	public List<Transform> campos = new List<Transform>();

	private bool inCombat = false;
	private int inCombat2 = 0;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
//**********************************
//CLOSE RANGE
		//**********************************
		if(Input.GetAxis("Horizontal") > 0 && !inAir && !doubleJump && inCombat)
		{
			transform.localPosition += movementSpeed*transform.forward*Time.deltaTime;
		}
		if(Input.GetAxis("Horizontal") < 0 && !inAir && !doubleJump && inCombat)
		{
			transform.localPosition -= movementSpeed*transform.forward*Time.deltaTime;
		}
		if(Input.GetAxis("Vertical") > 0&& !inAir && !doubleJump && inCombat)
		{			
			transform.localPosition -= movementSpeed*transform.right*Time.deltaTime;
		}
		if(Input.GetAxis("Vertical") < 0 && !inAir && !doubleJump && inCombat)
		{
			transform.localPosition += movementSpeed*transform.right*Time.deltaTime;
		}
		if(Input.GetButtonDown("Jump") && inCombat)
		{
			if(!inAir)
			{ 
				inAir = true;
				rb.AddForce(jumpSpeed*Vector3.up);
				rb.AddForce(jumpSpeed*-Vector3.forward*2);
			}		
		}
//**********************************
//LONG RANGE
//**********************************
		if(Input.GetAxis("Horizontal") > 0 && !inAir && !doubleJump && !inCombat)
		{
			transform.localPosition += movementSpeed*transform.right*Time.deltaTime;
		}
		if(Input.GetAxis("Horizontal") < 0 && !inAir && !doubleJump && !inCombat)
		{
			transform.localPosition -= movementSpeed*transform.right*Time.deltaTime;
		}
		if(Input.GetAxis("Vertical") > 0 && !inAir && !doubleJump && !inCombat)
		{			
			transform.localPosition += movementSpeed*transform.forward*Time.deltaTime;
		}
		if(Input.GetAxis("Vertical") < 0 && !inAir && !doubleJump  && !inCombat)
		{
			transform.localPosition -= movementSpeed*transform.forward*Time.deltaTime;
		}
		if(Input.GetButtonDown("Jump") && !inCombat)
		{
			if(!inAir)
			{ 
				inAir = true;
				rb.AddForce(jumpSpeed*Vector3.up);
			}		
			else if(!doubleJump)
			{
				doubleJump = true;
				rb.AddForce(jumpSpeed*Vector3.up*2/3);
			}			 	
			if(Input.GetAxis("Horizontal") > 0) rb.AddForce(jumpSpeed*transform.right* .5f);
			if(Input.GetAxis("Horizontal") < 0) rb.AddForce(jumpSpeed*transform.right*-.5f);
			if(Input.GetAxis("Vertical") > 0) rb.AddForce(jumpSpeed*transform.forward* .5f);
			if(Input.GetAxis("Vertical") < 0) rb.AddForce(jumpSpeed*transform.forward*-.5f);
		}
		transform.LookAt (new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z));
	}
	void OnTriggerEnter(Collider col){
		switch(col.gameObject.tag)
		{
		case "Floor":
			inAir = false;
			doubleJump = false;
			break;
		case "Player":
			cam.transform.position = campos[1].position;
			if(!inCombat)
			{
				inCombat = true;
			}
			else
			{
				inCombat2++;
			}
			break;
		}
	}

	void OnTriggerExit(Collider col){
		switch (col.gameObject.tag) {
		case "Player":			
			if(inCombat2 > 0){
				inCombat2--;
			}
			else
			{
				inCombat = false;
				cam.transform.position = campos[0].position;
			}
			break;
		}
	}
}