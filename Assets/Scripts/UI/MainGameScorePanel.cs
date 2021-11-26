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
        
        private void OnDestroy()
        {
            PersistentData.StatsChanged -= UpdateScore;
        }

        private void UpdateScore(object sender, EventArgs e)
        {
            hits.text = $"Hits: {PersistentData.Score}";
            scale.text = $"Scale: {PersistentData.CurrentScale.ToString("#.##")}";
            misses.text = $"Escaped: {PersistentData.Missed}";
        }
    }
}
