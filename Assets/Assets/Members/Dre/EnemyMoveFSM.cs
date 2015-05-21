using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MoveStates
{
	Idle,
	Run,
	WalkBack,
	Attack1,
	Attack2,
	Attack3,
	Attack4,
	Attack5,
	SpellCast,
	Death,
	Damage,
	jump
}

public class EnemyMoveFSM : MonoBehaviour 
{
	public AnimationClip Idle;
	public AnimationClip Run;
	public AnimationClip WalkBack;
	public AnimationClip RunL;
	public AnimationClip RunR;
	public AnimationClip Attack1;
	public AnimationClip Attack2;
	public AnimationClip Attack3;
	public AnimationClip Attack4;
	public AnimationClip Attack5;
	public AnimationClip Death;
	public AnimationClip Damage;
	public AnimationClip jump_up;
	public AnimationClip jump_down;


	public MoveStates CurrentState;

	public int combo;

	//public MoveStates PreviousState;
	
	//public float MoveSpeed;
	
	//public float TurnSpeed;
	
	//string currentAnimation;
	
	public Animation anim;
	
	void Awake()
	{
		//DontDestroyOnLoad (this);

		anim = gameObject.GetComponent<Animation>();
		
		#region setting up animator
		anim.playAutomatically = true;

		
		anim.AddClip(Idle, "idle");
		anim.AddClip(Run, "run");
		anim.AddClip(WalkBack, "walk_back");
		anim.AddClip(RunL,"runL");
		anim.AddClip(RunR,"runR");
		anim.AddClip(Attack1, "atk01");
		anim.AddClip(Attack2, "atk02");
		anim.AddClip(Attack3, "atk03");
		anim.AddClip(Attack4, "atk04");
		anim.AddClip(Attack5, "atk05");
		anim.AddClip(Death, "die");
		anim.AddClip(Damage, "hurt");
		anim.AddClip(jump_up, "jump_up");
		anim.AddClip(jump_down, "jump_down");
		
		anim["run"].wrapMode = WrapMode.Once;
		anim["idle"].wrapMode = WrapMode.Once;
		anim["walk_back"].wrapMode = WrapMode.Once;
		anim["runL"].wrapMode = WrapMode.Once;
		anim["runR"].wrapMode = WrapMode.Once;
		anim["atk01"].wrapMode = WrapMode.Once;
		anim["atk02"].wrapMode = WrapMode.Once;
		anim["atk03"].wrapMode = WrapMode.Once;
		anim["atk04"].wrapMode = WrapMode.Once;
		anim["atk05"].wrapMode = WrapMode.Once;
		anim["hurt"].wrapMode = WrapMode.Once;
		anim["die"].wrapMode = WrapMode.Once;
		anim["jump_up"].wrapMode = WrapMode.Once;
		anim["jump_down"].wrapMode = WrapMode.Once;
		//currentAnimation = "idle";
		
		/*anim["run"].speed = .5f;
		anim["idle"].speed = .5f;
		anim["walk_back"].speed = .5f;
		anim["atk01"].speed = .5f;
		anim["atk02"].speed = .5f;
		anim["atk03"].speed = .5f;
		anim["atk04"].speed = .5f;
		anim["atk05"].speed = .5f;
		anim["hurt"].speed = .5f;
		anim["die"].speed = .5f;
		anim["jump_up"].speed = .5f;
		anim["jump_down"].speed = .5f;*/
		#endregion


	}
	
	void Start () 
	{
		CurrentState = MoveStates.Idle;
		//MoveSpeed = 1.0f;
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	public void Attack(){		
		combo++;
		switch (combo) {
		case 1:
			anim.CrossFade("atk01");
			break;
		case 2:
			anim.CrossFadeQueued("atk03");
			break;
		case 3:
			anim.CrossFadeQueued("atk04");
			break;
		default:
			break;
		}
		/*switch (CurrentState) {
		case MoveStates.Attack1:
			anim.PlayQueued("atk03");
			
			//CurrentState = MoveStates.Attack2;
			break;
		case MoveStates.Attack2:
			anim.CrossFadeQueued("atk02", 0.0f);
			CurrentState = MoveStates.Attack3;
			break;
		case MoveStates.Attack3:
			CurrentState = MoveStates.Attack4;
			break;
		case MoveStates.Attack4:
			CurrentState = MoveStates.Attack5;
			break;
		default:
			CurrentState = MoveStates.Attack1;
			break;
		}*/
	}
	public void run(){		
		combo = 0;
		anim.CrossFade("run", 0.0f);
	}
	public void idle(){		
		combo = 0;
		anim.CrossFade("idle",0.0f);
	}
	public void runL(){
		combo = 0;
		if(!anim.IsPlaying("run") && !anim.IsPlaying("walk_back"))
			anim.CrossFade("runL",0.0f);
	}
	public void runR(){
		combo = 0;
		if(!anim.IsPlaying("run") && !anim.IsPlaying("walk_back"))
			anim.CrossFade("runR",0.0f);
	}
	public void walkBack(){
		combo = 0;
		anim.CrossFade("walk_back",0.0f);
	}
	public void Jump(){
		if (gameObject.GetComponent<Rigidbody> ().velocity.y > 0) 
		{
			if(!anim.IsPlaying("jump_up"))
				anim.CrossFade ("jump_up", 0.0f);
		}
		else if (gameObject.GetComponent<Rigidbody>().velocity.y < 0)
		{
			if(anim.IsPlaying("jump_up")){
				anim.CrossFade("jump_down",0.0f);
				//anim.CrossFadeQueued("idle",0.0f);
			}
		}
	}
}