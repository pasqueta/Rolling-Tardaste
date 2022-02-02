using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] float jumpForce = 10.0f;
	[SerializeField] float inAirMovementMultiplicator = 0.5f;
	[SerializeField] float mouseSensitivity = 1.0f;
    [SerializeField] Rigidbody rigidbody = null;
	[SerializeField] Transform objectForLookRotation = null;
	[SerializeField] Transform groundCheckerPoint = null;
	[SerializeField] LayerMask groundLayer;

    PlayerInputAction playerInputAction;
	Vector2 moveDir = Vector2.zero;
	Vector2 lookDir = Vector2.zero;
	float xRotation = 0f;
	bool isGrounded = false;

	private void Reset()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	private void Awake()
	{
        playerInputAction = new PlayerInputAction();
    }

	private void OnEnable()
	{
        playerInputAction.Enable();
    }

	private void OnDisable()
	{
		playerInputAction.Disable();
	}

	// Start is called before the first frame update
	void Start()
    {
		playerInputAction.Game.Move.performed += Move_performed;
		playerInputAction.Game.Move.canceled += Move_canceled;

		playerInputAction.Game.Jump.performed += Jump_performed;

		playerInputAction.Game.Look.performed += Look_performed;
		playerInputAction.Game.Look.canceled += Look_canceled;

		playerInputAction.Game.Shoot.performed += Shoot_performed;
		playerInputAction.Game.Shoot.canceled += Shoot_canceled;
	}

	#region INPUT_EVENTS
	private void Shoot_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		Debug.Log("End Shoot");
	}

	private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		Debug.Log("Start Shoot");
	}

	private void Look_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		lookDir = Vector3.zero;
	}

	private void Look_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		lookDir = obj.ReadValue<Vector2>();
	}

	private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		if (isGrounded)
		{
			rigidbody.AddForce(Vector3.up * jumpForce);
		}
	}

	private void Move_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		moveDir = Vector3.zero;
	}

	private void Move_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
	{
		moveDir = obj.ReadValue<Vector2>();
	}
	#endregion

	// Update is called once per frame
	void FixedUpdate()
    {
		CheckGround();

		Movement();

		LookRotation();
	}

	void Movement()
	{
		float inAirMultiplicator = 1.0f;
		if (!isGrounded)
		{
			inAirMultiplicator = inAirMovementMultiplicator;
		}
		else
		{
			inAirMultiplicator = 1.0f;
		}

		Vector3 moveDirection = transform.forward * moveDir.y;
		moveDirection += transform.right * moveDir.x;
		moveDirection.Normalize();
		moveDirection.y = 0.0f;
		moveDirection = moveDirection * speed * inAirMultiplicator;

		rigidbody.velocity = moveDirection + Vector3.up * rigidbody.velocity.y;
	}

	void LookRotation()
	{
		lookDir *= mouseSensitivity * Time.deltaTime;

		xRotation -= lookDir.y;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		objectForLookRotation.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

		transform.Rotate(Vector3.up * lookDir.x);
	}

	void CheckGround()
	{
		if(Physics.CheckSphere(groundCheckerPoint.position, 0.1f, groundLayer.value))
		{
			isGrounded = true;
		}
		else
		{
			isGrounded = false;
		}
	}
}
