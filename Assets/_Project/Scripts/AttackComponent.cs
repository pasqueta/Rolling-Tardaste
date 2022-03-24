using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    [SerializeField] Weapon weapon = null;

    public void StartPrimaryAttack()
	{
		if (weapon != null)
		{
			weapon.StartPrimaryAttack();
		}
	}
	public void StopPrimaryAttack()
	{
		if (weapon != null)
		{
			weapon.StopPrimaryAttack();
		}
	}

	public void StartSecondaryAttack()
	{
		if (weapon != null)
		{
			weapon.StartSecondaryAttack();
		}
	}
	public void StopSecondaryAttack()
	{
		if (weapon != null)
		{
			weapon.StopSecondaryAttack();
		}
	}
}
