using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
	#region Private variable defination
    private CharacterController characterController;
	#endregion

	#region Public variable defination
    public static Vector3 velocity;
	[SerializeField] private float walkSpeed;
	public static Animator animator;
	#endregion

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            if (velocity.magnitude > 0.1f)
            {
                animator.SetFloat("Speed", velocity.magnitude);
                transform.LookAt(transform.position + velocity);
            }else{
                animator.SetFloat("Speed", 0f);
            }
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(velocity * walkSpeed * Time.deltaTime);
    }
}