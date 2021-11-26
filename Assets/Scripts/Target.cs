using UnityEngine;
using Shooty.Core;

namespace Shooty
{
    public class Target : MonoBehaviour
    {
        private void Awake()
        {
            var scale = PersistentData.CurrentScale;
            transform.localScale = new Vector3(scale, scale, scale);
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
