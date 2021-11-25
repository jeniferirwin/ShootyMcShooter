using UnityEngine;
using Shooty.Core;

namespace Shooty
{
    public class Target : MonoBehaviour
    {
        private void Awake()
        {
            var scale = transform.localScale;
            transform.localScale = transform.localScale * PersistentData.ScaleReduction();
            Debug.Log($"{PersistentData.ScaleReduction()}");
        }

        public void GetShot()
        {
            PersistentData.IncrementScore();
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            PersistentData.IncrementMissed();
            Destroy(gameObject);
        }
    }
}
