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
        [SerializeField] private TMP_Text misses;
        

        private void OnEnable()
        {
            UpdateScore(this, EventArgs.Empty);
            PersistentData.StatsChanged += UpdateScore;
        }
        
        private void OnDisable()
        {
            PersistentData.StatsChanged -= UpdateScore;
        }

        private void UpdateScore(object sender, EventArgs e)
        {
            var scaleCalc = 1.5f * PersistentData.ScaleReduction();
            hits.text = $"Hits: {PersistentData.Score}";
            scale.text = $"Scale: {scaleCalc.ToString("#.##")}";
            misses.text = $"Escaped: {PersistentData.Missed}";
        }
    }
}
