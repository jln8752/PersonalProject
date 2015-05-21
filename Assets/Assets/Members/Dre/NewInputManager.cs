using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewInputManager : MonoBehaviour {

	public EnemyMoveFSM moveFSM;
	public float moveSpeed;
	private float walkSpeed;
	private float origMoveSpeed;
	public float turnSpeed;
	public bool isAttacking;		// This is for testing the attacking in battle. This will not be used
	// in the game.
	public bool forceIdle = false;

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
		//Messenger.AddListener ("ForceIdle",ForceIdle);
		//Messenger.MakePermanent ("ForceIdle");
	}

	void OnEnable(){
		//Messenger.AddListener ("ForceIdle",ForceIdle);
	}
	// Use this for initialization
	void Start () {

		moveFSM = GetComponent<EnemyMoveFSM> ();
		walkSpeed = moveSpeed / 2;
	
	}
	void OnDisable(){
		//Messenger.RemoveListener ("ForceIdle",ForceIdle);
	}
	// Update is called once per frame
	void Update () {


		if (forceIdle) {
			//if(moveFSM.CurrentState != enemyMoveStates.enemyIdle)
			//	moveFSM.CurrentState = enemyMoveStates.enemyIdle;
			return;
		}

		/*if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.A)) {
	
						if (Input.GetKey (KeyCode.W)) {
								transform.position -= moveSpeed * Time.deltaTime * transform.forward;
								//moveFSM.CurrentState = enemyMoveStates.enemyRun;

								if (Input.GetKey (KeyCode.A)) {
									Turn (-1);
								}
								if (Input.GetKey (KeyCode.D)) {
									Turn (1);
								}
								if (Input.GetKey (KeyCode.S)) {
									transform.position += moveSpeed * Time.deltaTime * transform.forward;
									//moveFSM.CurrentState = enemyMoveStates.enemyIdle;
								}


						}

						if (Input.GetKey (KeyCode.S)) {
								transform.position += walkSpeed * Time.deltaTime * transform.forward;
								//moveFSM.CurrentState = enemyMoveStates.enemyWalkBack;

								if (Input.GetKey (KeyCode.A)) {
									Turn (-1);
								}
								if (Input.GetKey (KeyCode.D)) {
									Turn (1);
								}
								if (Input.GetKey (KeyCode.W)) {
									transform.position -= walkSpeed * Time.deltaTime * transform.forward;
									//moveFSM.CurrentState = enemyMoveStates.enemyIdle;
								}

						}

						if (Input.GetKey (KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) {
								Turn (-1);
								//moveFSM.CurrentState = enemyMoveStates.enemyIdle;
						}

						if (Input.GetKey (KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) {
								Turn (1);
								//moveFSM.CurrentState = enemyMoveStates.enemyIdle;
						}

		}*/
		/*if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Vertical") != 0)
		{
			if (Input.GetAxis("Vertical") <0) {
				transform.position -= moveSpeed * Time.deltaTime * transform.forward;
				//moveFSM.CurrentState = enemyMoveStates.enemyRun;
				
				if (Input.GetAxis("Mouse X") < 0) {
					Turn (-1);
				}
				if (Input.GetAxis("Mouse X") > 0) {
					Turn (1);
				}
				if (Input.GetAxis("Vertical") > 0) {
					transform.position += moveSpeed * Time.deltaTime * transform.forward;
					//moveFSM.CurrentState = enemyMoveStates.enemyIdle;
				}
				
				
			}
			
			if (Input.GetAxis("Vertical") > 0) {
				transform.position += walkSpeed * Time.deltaTime * transform.forward;
				//moveFSM.CurrentState = enemyMoveStates.enemyWalkBack;
				
				if (Input.GetAxis("Mouse X") < 0) {
					Turn (-1);
				}
				if (Input.GetAxis("Mouse X") > 0) {
					Turn (1);
				}
				if (Input.GetAxis("Vertical") < 0) {
					transform.position -= walkSpeed * Time.deltaTime * transform.forward;
					//moveFSM.CurrentState = enemyMoveStates.enemyIdle;
				}
				
			}
			
			if (Input.GetAxis("Mouse X") < 0 && !(Input.GetAxis("Vertical") < 0) && !(Input.GetAxis("Vertical") > 0)) {
				Turn (-1);
				//moveFSM.CurrentState = enemyMoveStates.enemyIdle;
			}
			
			if (Input.GetAxis("Mouse X") > 0 && !(Input.GetAxis("Vertical") < 0) && !(Input.GetAxis("Vertical") > 0)) {
				Turn (1);
				//moveFSM.CurrentState = enemyMoveStates.enemyIdle;
			}


		}*/
		if (Input.GetAxis("Mouse X") < 0) {
			Turn (-1);
			//moveFSM.CurrentState = enemyMoveStates.enemyIdle;
		}		
		if (Input.GetAxis("Mouse X") > 0) {
			Turn (1);
			//moveFSM.CurrentState = enemyMoveStates.enemyIdle;
		}
		if (Input.GetAxis("Vertical") <  0) {
			transform.position += moveSpeed * Time.deltaTime * transform.forward;
			//moveFSM.CurrentState = enemyMoveStates.enemyWalkBack;
			//moveFSM.CurrentState = enemyMoveStates.enemyRun;
		}

		if (Input.GetAxis("Vertical") > 0) {
			transform.position -=  moveSpeed* Time.deltaTime * transform.forward;
			//moveFSM.CurrentState = enemyMoveStates.enemyRun;
		}



		if(Input.GetAxis("Vertical") == 0 ){
			//moveFSM.CurrentState = enemyMoveStates.enemyIdle;
		}


		if (Input.GetButtonDown ("Fire1")) {
			moveFSM.Attack();
		}
		/*if (Input.GetButtonDown ("Fire1") && !isAttacking) 
		{
			isAttacking = true;
			Spell Powerdrain = new PowerDrain(10f, 1, SpellEffect.none, GameObject.Find("Spell Transform").GetComponent<SpellTest>().Spells, gameObject);
			GameObject target = GameObject.Find("Player Transform").transform.FindChild("Player").gameObject;
			Powerdrain.Cast(target);
		}

		if (Input.GetButtonUp ("Fire1"))
		    isAttacking = false;
		*/
	}

	public void ForceIdle(){
		forceIdle = !forceIdle;
	}

	public void Turn(int direction)
	{
		transform.Rotate(Vector3.up, direction * turnSpeed * Time.deltaTime);
	}

}
