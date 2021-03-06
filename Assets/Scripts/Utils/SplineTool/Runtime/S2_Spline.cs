using UnityEngine;
using System;

public class S2_Spline : MonoBehaviour {

    #region Fields & Properties
    [SerializeField] Vector3[] points;
	bool isLooped = false;

	public bool Loop 
	{
		get 
		{
			return isLooped;
		}
		set 
		{
			isLooped = value;
			if (value == true) 
			{
				SetControlPoint(0, points[0]);
			}
		}
	}
	public int CurveCount => (points.Length - 1) / 3;
	public int ControlPointCount => points.Length;
    #endregion Fields & Properties


    #region Methods
    public Vector3 GetControlPoint (int index) => points[index];

	public void SetControlPoint (int index, Vector3 point) 
	{
		if (index % 3 == 0) 
		{
			Vector3 delta = point - points[index];
			if (isLooped) 
			{
				if (index == 0) 
				{
					points[1] += delta;
					points[points.Length - 2] += delta;
					points[points.Length - 1] = point;
				}
				else if (index == points.Length - 1) 
				{
					points[0] = point;
					points[1] += delta;
					points[index - 1] += delta;
				}
				else 
				{
					points[index - 1] += delta;
					points[index + 1] += delta;
				}
			}
			else 
			{
				if (index > 0) 
				{
					points[index - 1] += delta;
				}
				if (index + 1 < points.Length) 
				{
					points[index + 1] += delta;
				}
			}
		}
		points[index] = point;
	}

	public void AddCurve () 
	{
		Vector3 point = points[points.Length - 1];
		Array.Resize(ref points, points.Length + 3);
		point.x += 1f;
		points[points.Length - 3] = point;
		point.x += 1f;
		points[points.Length - 2] = point;
		point.x += 1f;
		points[points.Length - 1] = point;

		if (isLooped) 
			points[points.Length - 1] = points[0];
	}

	public Vector3 GetPoint (float t) 
	{
		int i = 0;

		if (t >= 1f) 
		{
			t = 1f;
			i = points.Length - 4;
		}
		else 
		{
			t = Mathf.Clamp01(t) * CurveCount;
			i = (int)t;
			t -= i;
			i *= 3;
		}
		return transform.TransformPoint(S2_Bezier.GetPoint(points[i], points[i + 1], points[i + 2], points[i + 3], t));
	}
	public Vector3 GetVelocity (float t) 
	{
		int i = 0;
		if (t >= 1f) 
		{
			t = 1f;
			i = points.Length - 4;
		}
		else 
		{
			t = Mathf.Clamp01(t) * CurveCount;
			i = (int)t;
			t -= i;
			i *= 3;
		}
		return transform.TransformPoint(S2_Bezier.GetFirstDerivative(points[i], points[i + 1], points[i + 2], points[i + 3], t)) - transform.position;
	}
	public Vector3 GetDirection (float t) => GetVelocity(t).normalized;

	public void Reset () {
		points = new Vector3[] 
		{
			new Vector3(1f, 0f, 0f),
			new Vector3(2f, 0f, 0f),
			new Vector3(3f, 0f, 0f),
			new Vector3(4f, 0f, 0f)
		};
	}
	#endregion Methods
}