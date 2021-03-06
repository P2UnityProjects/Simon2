using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2_CharacterMovement : MonoBehaviour
{
	[SerializeField] protected bool canMove = true;
	[SerializeField] protected float moveSpeed = 10f;
	[SerializeField] protected float rotateSpeed = 50f;
	[SerializeField]  float coyoteTime = 2f;
	[SerializeField] protected float jumpHeight = 2f;

	[SerializeField] protected float railDetectionRadius = 8;
	[SerializeField] protected LayerMask railBoardMask = 0;

	private int jumpCount = 0;
	[SerializeField] protected float timer = 0;
	private CharacterController controller;
	private Vector3 playerVelocity = Vector3.zero;
	private float gravityValue = -9.81f;

	public Vector3 Position => transform.position;
	public Quaternion Rotation => transform.rotation;

	public void SetCanMove(bool _value) => canMove = _value;
	protected virtual void Start()
	{
		controller = gameObject.GetComponent<CharacterController>();
		//S2_InputManager.Instance.BindAxis(S2_AxisEvent.MOVE_VERTICAL, MoveVertical);
		//S2_InputManager.Instance.BindAxis(S2_AxisEvent.MOVE_HORIZONTAL, MoveHorizontal);
		S2_InputManager.Instance.BindAction(S2_ButtonEvent.JUMP,Jump);
		S2_InputManager.Instance.BindAction(S2_ButtonEvent.SHIELD,Shield);
		S2_InputManager.Instance.BindAction(S2_ButtonEvent.RAIL,Rail);
	}
    private void Update()
    {
		MakeMoveWithCC();
		IncrementTimer();
		if (controller.isGrounded)
		{
			jumpCount = 0;
			timer = 0;
		}

	}

	void Rail(bool _bool)
    {
		if (!_bool) return;

		bool _hasHit = Physics.SphereCast(transform.position, railDetectionRadius, transform.forward, out RaycastHit _hit, railDetectionRadius, railBoardMask);

		if(_hasHit)
        {
			transform.SetParent(_hit.transform);
        }
	}

	void Shield(bool _bool)
    {
		if(_bool)
		Debug.Log("Destiny 2 est une abomination");
    }
	void MakeMoveWithCC()  //CC is for CharacterController
    {
		if (controller.isGrounded && playerVelocity.y < 0)
		{
			playerVelocity.y = 0f;
		}
		Vector3 move = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
		controller.Move(move * Time.deltaTime * moveSpeed);
		playerVelocity.y += gravityValue * Time.deltaTime;
		controller.Move(playerVelocity * Time.deltaTime);

	}

	//   void MoveVertical(float _axis)
	//   {
	//	if (!canMove) return;
	//	transform.position -= transform.right * Time.deltaTime * _axis * moveSpeed;


	//}

	//void MoveHorizontal(float _axis)
	//   {
	//	if (!canMove) return;
	//	transform.position -= transform.up * Time.deltaTime * _axis * moveSpeed;

	//}

	void Jump(bool _bool)
    {
		if (timer > coyoteTime) return;
		if (_bool && jumpCount<2 )
        {
			jumpCount++;
			playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);

		}
    }
	
	void IncrementTimer()
    {
		if (!controller.isGrounded)
			timer += Time.deltaTime;
    }
	
}
