using UnityEngine;
using System;

[RequireComponent(typeof(CharacterController))]
public class S2_CharacterMovement : MonoBehaviour
{
	[SerializeField] bool canMove = true;
	[SerializeField] float moveSpeed = 10f, rotateSpeed = 50f, coyoteTime = 2f, jumpHeight = 2f, timer = 0, gravityValue = -9.81f,
						   xAxis = 0, yAxis = 0;
	
	int jumpCount = 0;
	CharacterController controller = null;
	Vector3 playerVelocity = Vector3.zero;

	public bool IsValid => controller;
	public CharacterController Controller => controller;
	public Vector3 Position => transform.position;
	public Quaternion Rotation => transform.rotation;

	protected virtual void Start()
	{
		controller = gameObject.GetComponent<CharacterController>();
		S2_InputManager.Instance.BindAction(S2_ButtonEvent.JUMP, Jump);
		S2_InputManager.Instance.BindAxis(S2_AxisEvent.MOVE_VERTICAL, SetXAxis);
		S2_InputManager.Instance.BindAxis(S2_AxisEvent.MOVE_HORIZONTAL, SetYAxis);
	}
    private void Update()
    {
		MakeMoveWithCC();
		IncrementTimer();
		ResetTimer();
		RotatePlayer();
	}
    private void OnDestroy()
    {
		S2_InputManager.Instance.UnBindAction(S2_ButtonEvent.JUMP, Jump);
	}

	void RotatePlayer()
    {
		if (xAxis == 0 && yAxis == 0) return;
		Vector3 _direction = /*Position +*/ new Vector3(yAxis, 0, xAxis);
		Quaternion _lookAt = Quaternion.LookRotation(_direction);
		Quaternion _lookAtRotation = Quaternion.RotateTowards(Rotation, _lookAt, Time.deltaTime * rotateSpeed);
		transform.rotation = _lookAtRotation;
	}
	void SetXAxis(float _axis)
    {
		xAxis = _axis;
	}
	void SetYAxis(float _axis)
    {
		yAxis = _axis;
	}
	void MakeMoveWithCC()  //CC is for CharacterController
    {
		if (controller.isGrounded && playerVelocity.y < 0)
		{
			playerVelocity.y = 0f;
		}

		Vector3 _move = new Vector3(yAxis, 0, xAxis);
		float _deltaTime = Time.deltaTime;

		controller.Move(_move * _deltaTime * moveSpeed);
		playerVelocity.y += gravityValue * _deltaTime;
		controller.Move(playerVelocity * _deltaTime);
	}
	void Jump(bool _bool)
    {
		if (timer > coyoteTime) return;
		if (_bool && jumpCount < 2)
        {
			jumpCount++;
			playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
			//Debug.Log(controller.velocity);
		}
    }
	void IncrementTimer()
    {
		if (!controller.isGrounded)
			timer += Time.deltaTime;
    }
	void ResetTimer()
    {
		if (controller.isGrounded)
		{
			jumpCount = 0;
			timer = 0;
		}
	}
	public void SetCanMove(bool _value) => canMove = _value;
}