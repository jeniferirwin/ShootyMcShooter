using UnityEngine;
using Shooty.UI;
using Shooty.Core;

namespace Shooty.UI
{
    public class EnterHighScore : MonoBehaviour
    {
        private void OnEnable()
        {
            PopulateHighScores.RecordScore();
        }
    }
}
