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
	[SerializeField] protected float timer = 0;
	[SerializeField] protected float gravityValue = -9.81f;
	private int jumpCount = 0;
	private CharacterController controller;
	private Vector3 playerVelocity = Vector3.zero;

	public CharacterController Controller => controller;
	public Vector3 Position => transform.position;
	public Quaternion Rotation => transform.rotation;

	public void SetCanMove(bool _value) => canMove = _value;
	protected virtual void Start()
	{
		controller = gameObject.GetComponent<CharacterController>();
		S2_InputManager.Instance.BindAction(S2_ButtonEvent.JUMP,Jump);
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
	void MakeMoveWithCC()  //CC is for CharacterController
    {
		if (controller.isGrounded && playerVelocity.y < 0)
		{
			playerVelocity.y = 0f;
		}
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		controller.Move(move * Time.deltaTime * moveSpeed);
		playerVelocity.y += gravityValue * Time.deltaTime;
		controller.Move(playerVelocity * Time.deltaTime);
		

	}

	void Jump(bool _bool)
    {
		if (timer > coyoteTime) return;
		if (_bool && jumpCount<2 )
        {
			jumpCount++;
			playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
			Debug.Log(controller.velocity);
		}
    }
	
	void IncrementTimer()
    {
		if (!controller.isGrounded)
			timer += Time.deltaTime;
    }


    private void OnDestroy()
    {
		S2_InputManager.Instance.UnBindAction(S2_ButtonEvent.JUMP, Jump);
	}
}
