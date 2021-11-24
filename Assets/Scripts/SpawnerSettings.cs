using UnityEngine;

namespace Shooty
{
    public class SpawnerSettings : MonoBehaviour
    {
        private static SpawnerSettings _instance;
        public static SpawnerSettings Instance { get { return _instance; } }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
        }

        [SerializeField] private GameObject prefab;
        [SerializeField] private float minCooldown;
        [SerializeField] private float maxCooldown;
        [SerializeField] private float minForce;
        [SerializeField] private float maxForce;
        
        public static float MinCooldown { get { return Instance.minCooldown; } }
        public static float MaxCooldown { get { return Instance.maxCooldown; } }
        public static float MinForce { get { return Instance.minForce; } }
        public static float MaxForce { get { return Instance.maxForce; } }
        public static GameObject Prefab { get { return Instance.prefab; } }
    }
}
