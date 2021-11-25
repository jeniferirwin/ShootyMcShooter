using UnityEngine;
using Shooty.Core;

namespace Shooty
{
    public class Target : MonoBehaviour
    {
        private bool wasShot;

        public void GetShot()
        {
            if (wasShot) return;
            wasShot = true;
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
