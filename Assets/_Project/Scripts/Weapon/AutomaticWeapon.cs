using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticWeapon : Weapon
{
	protected float timerPrimaryAttack = 0.0f;
	protected float timerSecondaryAttack = 0.0f;

	private bool canPrimaryAttack = false;
	private bool canSecondaryAttack = false;

	private void Update()
	{
		UpdateTimer();
	}

	private void UpdateTimer()
	{
		if(canPrimaryAttack && timerPrimaryAttack > 0.0f)
		{
			timerPrimaryAttack -= Time.deltaTime;

			if(timerPrimaryAttack <= 0.0f)
			{
				PrimaryAttack();
			}
		}
		else
		{
			timerPrimaryAttack = 0.0f;
		}

		if (canSecondaryAttack && timerSecondaryAttack > 0.0f)
		{
			timerSecondaryAttack -= Time.deltaTime;

			if (timerSecondaryAttack <= 0.0f)
			{
				SecondaryAttack();
			}
		}
		else
		{
			timerSecondaryAttack = 0.0f;
		}
	}

	public override void StartPrimaryAttack()
	{
		Debug.Log("StartPrimaryAttack");
		PrimaryAttack();
		canPrimaryAttack = true;
	}

	public override void StopPrimaryAttack()
	{
		Debug.Log("StopPrimaryAttack");
		canPrimaryAttack = false;
	}

	public override void StartSecondaryAttack()
	{
		Debug.Log("StartSecondaryAttack");
		SecondaryAttack();
		canSecondaryAttack = true;
	}
	public override void StopSecondaryAttack()
	{
		Debug.Log("StopSecondaryAttack");
		canSecondaryAttack = false;
	}

	protected virtual void PrimaryAttack()
	{
		Debug.Log("Shoot PrimaryAttack");
		timerPrimaryAttack = primaryCooldown;
	}
	protected virtual void SecondaryAttack()
	{
		Debug.Log("Shoot SecondaryAttack");
		timerSecondaryAttack = secondaryCooldown;
	}
}
