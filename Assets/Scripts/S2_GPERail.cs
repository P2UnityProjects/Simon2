using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2_GPERail : MonoBehaviour
{
    [SerializeField] S2_Spline spline = null;
    [SerializeField] int frequency = 10;
	[SerializeField] float meshSize = .05f;

	public Transform railMesh = null;

	private void Awake()
	{
		//if (frequency <= 0 || railMeshes == null || railMeshes.Length == 0) return;

		//float stepSize = 1f / (frequency * railMeshes.Length);
		//for (float p = 0, f = 0; f < frequency; f++)
		//{
		//	for (int i = 0; i < railMeshes.Length; i++, p++)
		//	{
		//		Transform item = Instantiate(railMeshes[i]) as Transform;
		//		Vector3 position = spline.GetPoint(p * stepSize);
		//		item.transform.localPosition = position;
		//		if (lookForward)
		//		{
		//			item.transform.LookAt(position + spline.GetDirection(p * stepSize));
		//		}
		//		item.transform.parent = transform;
		//	}
		//}

		for (int i = 0; i < spline.PointsCount; i++)
		{
			for (float p = 0; p < frequency; p += meshSize)
			{
				Transform newMesh = Instantiate(railMesh);
				Vector3 position = spline.GetPoint(p);
				newMesh.transform.localPosition = position;
				newMesh.transform.LookAt(position + spline.GetDirection(p));

				newMesh.transform.parent = transform;
			}
		}
	}
}
