using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : Weapon
{
    [SerializeField] LayerMask layerMask;

	public override void StartPrimaryAttack()
	{
		base.StartPrimaryAttack();

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
			foreach (Transform muzzle in muzzles)
			{
                Debug.DrawRay(muzzle.position, (hit.point - muzzle.position) * Vector3.Distance(transform.position, hit.point), Color.yellow, 1.0f);
            }
            Debug.Log("Did Hit");
        }
        else
        {
            foreach (Transform muzzle in muzzles)
            {
                Debug.DrawRay(muzzle.position, muzzle.TransformDirection(Vector3.forward) * 1000.0f, Color.red, 1.0f);
            }
            Debug.Log("Did not Hit");
        }
    }
}
