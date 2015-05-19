using UnityEngine;
using System.Collections;

public class AnimControl : MonoBehaviour {

	public float animSpeed = 1.0f;
	private Animator anim;  // referance to the animator on the player

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
	
	}

	void FixedUpdate()
	{
		anim.speed = animSpeed;
	}
	// Update is called once per frame
	void Update () {
	
	}
	void LateUpdate()
	{
		ResetAttack ();
		
	}


	public void Combo1()
	{
		anim.SetBool ("Attack", true);
	}
	public void Combo2()
	{
		anim.SetBool ("Attack", true);
	}
	public void Combo3()
	{
		anim.SetBool ("Attack", true);
	}

	public void ResetAttack()
	{
		anim.SetBool ("Attack", false);
	}

	public void GetHit()
	{
		anim.SetBool ("Damage", true);
	}

	public void ResetHit()
	{
		anim.SetBool ("Damage", false);
	}

	public void Death()
	{
		anim.SetBool ("Death", true);
	}

}
