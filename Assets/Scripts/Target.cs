using UnityEngine;
using Shooty.Core;

namespace Shooty
{
    public class Target : MonoBehaviour
    {
        public void GetShot()
        {
            PersistentData.IncrementScore();
            Destroy(gameObject);
        }
    }
}
