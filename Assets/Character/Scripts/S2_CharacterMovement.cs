using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2_CharacterMovement : MonoBehaviour
{
	[SerializeField] protected bool canMove = true;
	[SerializeField] protected float moveSpeed = 10f;
	[SerializeField] protected float rotateSpeed = 50f;
	[SerializeField] protected float jumpHeight = 2f;

	public Vector3 Position => transform.position;
	public Quaternion Rotation => transform.rotation;

	protected virtual void Start()
	{
		S2_InputManager.Instance.BindAxis(S2_AxisEvent.MOVE_VERTICAL, MoveVertical);
		S2_InputManager.Instance.BindAxis(S2_AxisEvent.MOVE_HORIZONTAL, MoveHorizontal);
		S2_InputManager.Instance.BindAction(S2_ButtonEvent.JUMP,Jump);
	}

	public void SetCanMove(bool _value) => canMove = _value;

	void MoveVertical(float _axis)
    {
		if (!canMove) return;
		transform.position -= transform.right * Time.deltaTime * _axis * moveSpeed;
		

	}

	void MoveHorizontal(float _axis)
    {
		if (!canMove) return;
		transform.position += transform.forward * Time.deltaTime * _axis * moveSpeed;
	
	}

	void Jump(bool _bool)
    {
		if(_bool)
		transform.position += new Vector3(0, jumpHeight, 0);
    }
}
