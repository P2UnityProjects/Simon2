using UnityEngine;
using UnityEditor;

public abstract class S2_CustomTemplateEditor<T> : Editor where T : MonoBehaviour
{
    protected T etarget = null;
    protected virtual void OnEnable()
    {
        etarget = (T)target;
    }
}