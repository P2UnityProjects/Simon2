using UnityEngine;

public class S2_CollectibleBox : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField, Header("Collectible Box - Settings :")] GameObject collectibleType = null;
    [SerializeField, Range(1, 50)] int collectibleCount = 5;
    [SerializeField, Range(1, 25)] float spawnRadius = 1.5f;


    public bool IsValid => collectibleType;

    public Vector3 Position => transform.position;

    #endregion

    #region Methods

    private void Start() => InitCollectibleBox();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green - new Color(0, 0, 0, .8f);
        Gizmos.DrawSphere(Position, spawnRadius);
    }

    private void OnTriggerEnter(Collider other) //TODO -> Player Attack compo
    {
        S2_Player _player = other.GetComponent<S2_Player>();
        if (!_player) return;
        SpawnCollectible(_player);
        Destroy(gameObject, .1f);
    }

    void InitCollectibleBox()
    {
        if (!IsValid) return;
        S2_CollectibleManager.Instance?.AddCollectible(collectibleCount);
    }

    void SpawnCollectible(S2_Player _player)
    {
        for (int i = 0; i < collectibleCount; i++)
        {
            Vector3 _spawnPoint = Random.insideUnitSphere;
            _spawnPoint *= spawnRadius;
            _spawnPoint += Position;
            EnergySphere _energySphere = Instantiate(collectibleType, _spawnPoint, Quaternion.identity).GetComponent<EnergySphere>();
            if (!_energySphere) return;
            _energySphere.Movement.SetTarget(_player.transform);
        }
    }
    #endregion
}