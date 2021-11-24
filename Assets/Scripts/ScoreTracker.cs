using UnityEngine;
using Shooty.Core;

namespace Shooty
{
    public class ScoreTracker : MonoBehaviour
    {
        private void Start()
        {
            PersistentData.ResetScore();
        }
    }
}
