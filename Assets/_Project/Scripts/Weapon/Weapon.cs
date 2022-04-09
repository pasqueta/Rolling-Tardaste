using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] string name;
	[SerializeField] protected float primaryDamage;
	[SerializeField] protected float primaryCooldown;

	[SerializeField] protected float secondaryDamage;
	[SerializeField] protected float secondaryCooldown;

	[SerializeField] protected Transform[] muzzles;

	public virtual void StartPrimaryAttack()
	{
		Debug.Log("StartPrimaryAttack");
	}

	public virtual void StopPrimaryAttack()
	{
		Debug.Log("StopPrimaryAttack");
	}

	public virtual void StartSecondaryAttack()
	{
		Debug.Log("StartSecondaryAttack");
	}
	public virtual void StopSecondaryAttack()
	{
		Debug.Log("StopSecondaryAttack");
	}
}
