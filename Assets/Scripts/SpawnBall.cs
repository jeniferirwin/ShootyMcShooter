using UnityEngine;
using Shooty.Core;

namespace Shooty
{
    public class SpawnBall : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private float minForce;
        [SerializeField] private float maxForce;
        [SerializeField] private float minCooldown;
        [SerializeField] private float maxCooldown;
        
        private GameObject myActiveBall;
        private float _currentCooldown;
        
        private void Update()
        {
            if (_currentCooldown > 0)
            {
                _currentCooldown -= Time.deltaTime;
                return;
            }
            if (myActiveBall != null) return;
            
            _currentCooldown = GetNewCooldown();
            LaunchTarget();
        }
        
        private void LaunchTarget()
        {
            myActiveBall = GameObject.Instantiate(prefab, transform.position, Quaternion.identity);
            var rb = myActiveBall.GetComponent<Rigidbody>();
            var newForce = Random.Range(minForce, maxForce);
            rb.AddForce(Vector3.up * newForce, ForceMode.Impulse);
        }
        
        private float GetNewCooldown()
        {
            var min = minCooldown * GetDifficultyMultiplier();
            var max = maxCooldown * GetDifficultyMultiplier();
            return Random.Range(minCooldown, maxCooldown);
        }
        
        private float GetDifficultyMultiplier()
        {
            return 1f - PersistentData.Score / 15 / 100;
        }
    }
}
