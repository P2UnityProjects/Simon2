using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(S2_Spline))]
public class S2_SplineEditor : Editor
{
	const int stepsPerCurve = 10;
	const float directionScale = 1, handleSize = 0.04f, pickSize = 0.06f;

	int selectedIndex = -1;

	S2_Spline spline;
	Transform handleTransform;
	Quaternion handleRotation;

	void OnSceneGUI()
	{
		spline = target as S2_Spline;
		handleTransform = spline.transform;
		handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;

		Vector3 p0 = ShowPoint(0);
		for (int i = 1; i < spline.PointsCount; i += 3)
		{
			Vector3 p1 = ShowPoint(i);
			Vector3 p2 = ShowPoint(i+1);
			Vector3 p3 = ShowPoint(i+2);

			Handles.color = Color.gray;
			Handles.DrawLine(p0, p1);
			Handles.DrawLine(p2, p3);

			//ShowDirections();
			Handles.DrawBezier(p0, p3, p1, p2, Color.white, null, 2f);
			p0 = p3;
		}

		Handles.color = Color.white;
		Vector3 lineStart = spline.GetPoint(0f);
		for (int i = 1; i <= stepsPerCurve; i++)
		{
			Vector3 lineEnd = spline.GetPoint(i / (float)stepsPerCurve);
			Handles.DrawLine(lineStart, lineEnd);
			lineStart = lineEnd;
		}
	}
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		spline = target as S2_Spline;
		if (selectedIndex >= 0 && selectedIndex < spline.PointsCount)
		{
			DrawSelectedPointInspector();
		}
		if (GUILayout.Button("Add Curve"))
		{
			Undo.RecordObject(spline, "Add Curve");
			spline.AddCurve();
		}
	}

	void DrawSelectedPointInspector()
	{
		GUILayout.Label("Selected Point");
		EditorGUI.BeginChangeCheck();
		Vector3 point = EditorGUILayout.Vector3Field("Position", spline.GetControlPoint(selectedIndex));
		if (EditorGUI.EndChangeCheck())
		{
			spline.SetControlPoint(selectedIndex, point);
		}
	}

	Vector3 ShowPoint(int index)
	{
		if (index < 0 || index >= spline.PointsCount) return Vector3.zero;

		Vector3 point = handleTransform.TransformPoint(spline.GetControlPoint(index));

		float size = HandleUtility.GetHandleSize(point);
		Handles.color = Color.white;
		if (Handles.Button(point, handleRotation, size * handleSize, size * pickSize, Handles.DotHandleCap))
		{
			selectedIndex = index;
			Repaint();
		}
		if (selectedIndex == index)
		{
			EditorGUI.BeginChangeCheck();
			point = Handles.DoPositionHandle(point, handleRotation);
			if (EditorGUI.EndChangeCheck())
			{
				spline.SetControlPoint(index, handleTransform.InverseTransformPoint(point));
			}
		}
		return point;
	}

	void ShowDirections()
	{
		Handles.color = Color.green;
		Vector3 point = spline.GetPoint(0f);
		Handles.DrawLine(point, point + spline.GetDirection(0f) * directionScale);
		int steps = stepsPerCurve * spline.CurveCount;
		for (int i = 1; i <= steps; i++)
		{
			point = spline.GetPoint(i / (float)steps);
			Handles.DrawLine(point, point + spline.GetDirection(i / (float)steps) * directionScale);
		}
	}
}

