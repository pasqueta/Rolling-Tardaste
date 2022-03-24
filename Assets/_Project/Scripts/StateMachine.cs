using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : StateMachineBehaviour
{
	[SerializeField] private float coucou = 5.0f;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Debug.Log("OnStateEnter");
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Debug.Log("OnStateExit");
	}

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Debug.Log("OnStateUpdate");
	}
}
