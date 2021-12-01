using UnityEngine;

public class S2_Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance = null;

    public static T Instance => instance;

    protected virtual void Awake()
    {
        if (instance)
        {
            Destroy(this);
            return;
        }
        instance = this as T;
    }
}