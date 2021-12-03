using UnityEngine;

public class S2_GPERail : MonoBehaviour {

	[SerializeField] S2_Spline spline = null;
	[SerializeField] Transform[] meshes;
	[SerializeField] S2_RailBoard railBoardType = null;
	S2_RailBoard railBoardCopy = null;
	[SerializeField] int frequency = 10;

	public bool IsValid => railBoardType;

	private void Awake () 
	{
		InstantiateMeshes();
	}
    private void Start()
    {
		Init();
    }

    void InstantiateMeshes()
	{
		if (frequency <= 0 || meshes == null || meshes.Length == 0) return;

		float _stepSize = frequency * meshes.Length;
		if (spline.Loop || _stepSize == 1)
		{
			_stepSize = 1f / _stepSize;
		}
		else
		{
			_stepSize = 1f / (_stepSize - 1);
		}

		for (int p = 0, f = 0; f < frequency; f++)
		{
			for (int i = 0; i < meshes.Length; i++, p++)
			{
				Transform _mesh = Instantiate(meshes[i]);
				Vector3 position = spline.GetPoint(p * _stepSize);
				_mesh.transform.localPosition = position;
				_mesh.transform.LookAt(position + spline.GetDirection(p * _stepSize));
				_mesh.transform.parent = transform;
			}
		}
	}
	public void Init()
    {
		if (!IsValid) return;

		railBoardCopy = Instantiate(railBoardType);

		Vector3 position = spline.GetPoint(0);
		railBoardCopy.transform.localPosition = position;
		railBoardCopy.transform.LookAt(position + spline.GetDirection(0));

		railBoardCopy.SetSpline(spline);
	}
	public void SetSplineToBoard() => railBoardCopy.SetSpline(spline);
}
