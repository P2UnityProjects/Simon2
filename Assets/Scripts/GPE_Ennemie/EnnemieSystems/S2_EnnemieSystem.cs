using UnityEngine;

[RequireComponent(typeof(S2_GPEEnnemie))]
public abstract class S2_EnnemieSystem : MonoBehaviour
{
	#region Fields & Properties
	protected S2_GPEEnnemie owner = null;
	#endregion

	#region Methods
	protected void Start() => Init();

	protected virtual void Init() => owner = GetComponent<S2_GPEEnnemie>();
	#endregion

}
