using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessAttack : MonoBehaviour
{
	#region Private variable defination
    private MoveEnemy enemy;
    private SphereCollider sphereCollider;
    private Animator animator;
	#endregion

	#region Public variable defination

	#endregion

    void Start()
    {
        enemy = GetComponent<MoveEnemy>();
        sphereCollider = GetComponentInChildren<SphereCollider>();
        animator = GetComponent<Animator>();
    }

	#region Enemy attack start
    void AttackStart()
    {
        sphereCollider.enabled = true;
		mainscript.dam = true;
    }
	#endregion

	#region Enemy attack end
    void AttackEnd()
    {
        sphereCollider.enabled = false;
    }
	#endregion

	#region End of enemy state
    void StateEnd()
    {
        enemy.SetState("freeze");
    }
	#endregion
}