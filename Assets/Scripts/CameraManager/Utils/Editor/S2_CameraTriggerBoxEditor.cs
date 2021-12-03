using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(S2_CameraTriggerBox))]
public class S2_CameraTriggerBoxEditor : S2_CustomTemplateEditor<S2_CameraTriggerBox>
{
    public event Action OnUpdateInspector = null;

    const string SET_SMOOTH_MOVE_NAME = "setSmoothMove",
                 SET_SMOOTH_ROTATE_NAME = "setSmoothRotate",
                 SET_CURRENT_ANGLE_NAME = "setCurrentAngle",
                 SET_GOAL_ANGLE_NAME = "setGoalAngle",
                 SET_HEIGHT_NAME = "setHeight",
                 SET_RAYON_NAME = "setRayon",
                 SET_MOVESPEED_NAME = "setMoveSpeed",
                 SET_ROTATESPEED_NAME = "setRotateSpeed",

                 SETTINGS_NAME = "settings",
                 SMOOTH_MOVE_NAME = "smoothMove",
                 SMOOTH_ROTATION_NAME = "smoothRotation",
                 MOVE_SPEED_NAME = "moveSpeed",
                 ROTATE_SPEED_NAME = "rotateSpeed",

                 CAMERA_ORBIT_OFFSET_NAME = "cameraOrbitOffset",
                 CURRENT_ANGLE_NAME = "currentAngle",
                 GOAL_ANGLE_NAME = "goalAngle",
                 RAYON_NAME = "rayon",
                 HEIGHT_NAME = "height";

    protected override void OnEnable()
    {
        base.OnEnable();
        OnUpdateInspector += () =>
        {
            DrawBoxPropertiesSelector();
            serializedObject.ApplyModifiedProperties();
        };
    }
    public override void OnInspectorGUI()
    {
        OnUpdateInspector?.Invoke();
    }

    void DrawBoxPropertiesSelector()
    {
        GUILayout.Box("Select Params: ");
        GUILayout.BeginVertical();
        {
            SerializedProperty _settings = serializedObject.FindProperty(SETTINGS_NAME);
            SerializedProperty _cameraOrbitOffset = _settings.FindPropertyRelative(CAMERA_ORBIT_OFFSET_NAME);

            SerializedProperty _setSmoothMove = serializedObject.FindProperty(SET_SMOOTH_MOVE_NAME);
            SerializedProperty _setSmoothRotate = serializedObject.FindProperty(SET_SMOOTH_ROTATE_NAME);
            SerializedProperty _setMoveSpeed = serializedObject.FindProperty(SET_MOVESPEED_NAME);
            SerializedProperty _setRotateSpeed = serializedObject.FindProperty(SET_ROTATESPEED_NAME);
            SerializedProperty _setCurrentAngle = serializedObject.FindProperty(SET_CURRENT_ANGLE_NAME);
            SerializedProperty _setGoalAngle = serializedObject.FindProperty(SET_GOAL_ANGLE_NAME);
            SerializedProperty _setRayon = serializedObject.FindProperty(SET_RAYON_NAME);
            SerializedProperty _setHeight = serializedObject.FindProperty(SET_HEIGHT_NAME);

            SerializedProperty _smoothMove = _settings.FindPropertyRelative(SMOOTH_MOVE_NAME);
            SerializedProperty _smoothRotation = _settings.FindPropertyRelative(SMOOTH_ROTATION_NAME);
            SerializedProperty _moveSpeed = _settings.FindPropertyRelative(MOVE_SPEED_NAME);
            SerializedProperty _rotateSpeed = _settings.FindPropertyRelative(ROTATE_SPEED_NAME);

            SerializedProperty _currentAngle = _cameraOrbitOffset.FindPropertyRelative(CURRENT_ANGLE_NAME);
            SerializedProperty _goalAngle = _cameraOrbitOffset.FindPropertyRelative(GOAL_ANGLE_NAME);
            SerializedProperty _rayon = _cameraOrbitOffset.FindPropertyRelative(RAYON_NAME);
            SerializedProperty _height = _cameraOrbitOffset.FindPropertyRelative(HEIGHT_NAME);


            DrawBoolValue(_setSmoothMove, _smoothMove, " Set Smooth Move", "Smooth Move:");
            DrawBoolValue(_setSmoothRotate, _smoothRotation, " Set Smooth Rotation", "Smooth Rotation:");
            DrawFloatValue(_setMoveSpeed, _moveSpeed, " Set Move Speed", "Move Speed:");
            DrawFloatValue(_setRotateSpeed, _rotateSpeed, " Set Rotate Speed", "Rotate Speed:");
            DrawFloatValue(_setCurrentAngle, _currentAngle, " Set Current Angle", "Current Angle:");
            DrawFloatValue(_setGoalAngle, _goalAngle, " Set Goal Angle", "Goal Angle:");
            DrawFloatValue(_setRayon, _rayon, " Set Rayon", "Rayon:");
            DrawFloatValue(_setHeight, _height, " Set Height", "Height:");
        }
        GUILayout.EndVertical();
    }

    void DrawFloatValue(SerializedProperty _setProperty, SerializedProperty _property, string _setPropertyName, string _propertyName)
    {
        GUILayout.BeginHorizontal();
        {
            _setProperty.boolValue = GUILayout.Toggle(_setProperty.boolValue, _setPropertyName, GUILayout.Width(150));
            if (_setProperty.boolValue)
            {
                string _textValue = GUILayout.TextField($"{_property.floatValue}", GUILayout.Width(100));
                if (float.TryParse(_textValue, out float _result))
                    _property.floatValue = _result;
                _property.floatValue = GUILayout.HorizontalSlider(_property.floatValue, -360, 360);
            }
        }
        GUILayout.EndHorizontal();
    }
    void DrawBoolValue(SerializedProperty _setProperty, SerializedProperty _property, string _setPropertyName, string _propertyName)
    {
        GUILayout.BeginHorizontal();
        {
            _setProperty.boolValue = GUILayout.Toggle(_setProperty.boolValue, _setPropertyName, GUILayout.Width(150));
            if (_setProperty.boolValue)
                _property.boolValue = GUILayout.Toggle(_property.boolValue, "");
        }        
        GUILayout.EndHorizontal();
    }
}