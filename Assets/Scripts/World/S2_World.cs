using UnityEngine;

[RequireComponent(typeof(S2_CameraManager), typeof(S2_InputManager), typeof(S2_TimerManager))]
public class S2_World : S2_Singleton<S2_World>
{
    [SerializeField] S2_CameraManager cameraManager = null;
    [SerializeField] S2_InputManager inputManager = null;
    [SerializeField] S2_TimerManager timerManager = null;
    [SerializeField] S2_Player player = null;

    public bool IsValid => cameraManager && inputManager && timerManager && player;
    public S2_CameraManager CameraManager => cameraManager;
    public S2_InputManager InputManager => inputManager;
    public S2_TimerManager TimerManager => timerManager;
    public S2_Player Player => player;

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    void Init()
    {
        cameraManager = GetComponent<S2_CameraManager>();
        inputManager = GetComponent<S2_InputManager>();
        timerManager = GetComponent<S2_TimerManager>();
    }
}