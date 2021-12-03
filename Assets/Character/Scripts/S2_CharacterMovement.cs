using UnityEngine;
using System;

[RequireComponent(typeof(CharacterController))]
public class S2_CharacterMovement : MonoBehaviour
{
	[SerializeField] bool canMove = true;
	[SerializeField] float moveSpeed = 10f, rotateSpeed = 50f, coyoteTime = 2f, jumpHeight = 2f, timer = 0, gravityValue = -9.81f,
						   xAxis = 0, yAxis = 0;
	[SerializeField] Camera gameCamera = null;
	
	int jumpCount = 0;
	CharacterController controller = null;
	Vector3 playerVelocity = Vector3.zero;

	public bool IsValid => controller && gameCamera;
	public CharacterController Controller => controller;
	public Vector3 Position => transform.position;
	public Vector3 CameraFWD => gameCamera.transform.forward;
	public Vector3 CameraRight => gameCamera.transform.right;
	public Quaternion Rotation => transform.rotation;

	protected virtual void Start()
	{
		Init();
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

	void Init()
    {
		controller = gameObject.GetComponent<CharacterController>();
		S2_InputManager.Instance.BindAction(S2_ButtonEvent.JUMP, Jump);
		S2_InputManager.Instance.BindAxis(S2_AxisEvent.MOVE_VERTICAL, SetXAxis);
		S2_InputManager.Instance.BindAxis(S2_AxisEvent.MOVE_HORIZONTAL, SetYAxis);
		S2_World.Instance.TimerManager.AddTimer(0.01f, InitCamera);
	}
	void InitCamera()
    {
		if (!gameCamera)
			gameCamera = S2_World.Instance.CameraManager.GetFirstCamera().GetComponent<Camera>();
	}
	void RotatePlayer()
    {
		if (!IsValid) return;
		if (xAxis == 0 && yAxis == 0) return;
		Vector3 _direction = (xAxis * CameraFWD) + (yAxis * CameraRight);
		_direction.y = 0;
		if (_direction == Vector3.zero) return;
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
		if (!IsValid) return;
		if (controller.isGrounded && playerVelocity.y < 0)
		{
			playerVelocity.y = 0f;
		}

		float _deltaTime = Time.deltaTime;
		Vector3 _position = (xAxis * CameraFWD) + (yAxis * CameraRight);
		_position.y = 0;
		controller.Move(_position * _deltaTime * moveSpeed);
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