using System;
using UnityEngine;

public class S2_CharacterCounter : MonoBehaviour
{
    public event Action OnAttack = null;

    [SerializeField] S2_Player player = null;
    [SerializeField] float shieldRadius = 5;
    [SerializeField] LayerMask toCounterLayer = 0;

    public bool IsValid => player;
    public Vector3 Position => transform.position;

    private void Start()
    {
        Init();
    }
    private void OnDestroy()
    {
        S2_InputManager.Instance.UnBindAction(S2_ButtonEvent.SHIELD, DetectDangerGPE);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Position, shieldRadius);
    }

    void Init()
    {
        S2_InputManager.Instance.BindAction(S2_ButtonEvent.SHIELD, DetectDangerGPE);
        player = GetComponent<S2_Player>();
    }
    void DetectDangerGPE(bool _bool)
    {
        if (!_bool) return;
        OnAttack?.Invoke();
        Collider[] touchtab = Physics.OverlapSphere(Position, shieldRadius, toCounterLayer);
        for (int i = 0; i < touchtab.Length; i++)
        {
            Collider _collider = touchtab[i];
            if (!_collider) continue;
            DetectRocket(_collider);
            DetectCollectibleBox(_collider);
        }
    }
    void DetectRocket(Collider _other)
    {
        Debug.Log("Detected Rocket");
        S2_GPERocket _proj = _other.GetComponent<S2_GPERocket>();
        if (!_proj) return;
        _proj.SetTarget(_proj.GetLauncher().transform);
        _proj.SetIsCountered(true);
    }
    void DetectCollectibleBox(Collider _other)
    {
        S2_CollectibleBox _collectibleBox = _other.GetComponent<S2_CollectibleBox>();
        if (!_collectibleBox || !IsValid) return;
        _collectibleBox.DestroyBox(player);
    }
}