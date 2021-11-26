using System;
using UnityEngine;
using TMPro;
using Shooty.Core;

namespace Shooty.UI
{
    public class MainGameScorePanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text hits;
        [SerializeField] private TMP_Text scale;
        [SerializeField] private TMP_Text escapes;
        

        private void OnEnable()
        {
            UpdateScore();
            RoundData.StatsChanged += UpdateScore;
        }
        
        private void OnDestroy()
        {
            RoundData.StatsChanged -= UpdateScore;
        }

        private void UpdateScore()
        {
            hits.text = $"Hits: {RoundData.Score}";
            scale.text = $"Scale: {RoundData.CurrentScale.ToString("#.##")}";
            escapes.text = $"Escaped: {RoundData.Escaped}";
        }
    }
}
