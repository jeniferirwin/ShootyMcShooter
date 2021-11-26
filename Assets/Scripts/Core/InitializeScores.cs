using UnityEngine;
using Shooty.Core;
using Shooty.UI;

namespace Shooty
{
    public class InitializeScores : MonoBehaviour
    {
        private void Awake()
        {
            PopulateHighScores.InitializeScoreData();
        }
    }
}
