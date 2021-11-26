using UnityEngine;

namespace Shooty.Core
{
    public class RoundData
    {
        public delegate void OnStatsChanged();
        public delegate void OnGameOver();
        public static event OnStatsChanged StatsChanged;
        public static event OnGameOver GameOver;

        public static TargetType ChosenTargetType { get { return _chosenType; } }
        public static int Score { get { return _score; } }
        public static int Escaped { get { return _escaped; } }

        private static TargetType _chosenType;
        private static int _score;
        private static int _escaped;

        public static void SetChosenTargetType(TargetType type)
        {
            _chosenType = type;
        }

        public static float ScalePercentage
        {
            get
            {
                return 1f - (Score / 1.01f / 100f);
            }
        }

        public static float CurrentScale
        {
            get
            {
                return 1.5f * ScalePercentage;
            }
        }

        public static void ResetScore()
        {
            _score = 0;
            _escaped = 0;
            StatsChanged?.Invoke();
        }

        public static void IncrementScore()
        {
            _score += 1;
            StatsChanged?.Invoke();
        }

        public static void IncrementEscaped()
        {
            _escaped += 1;
            StatsChanged?.Invoke();
            if (_escaped >= 5)
            {
                GameOver?.Invoke();
            }
        }
        
        public static void ForceGameOver()
        {
            GameOver?.Invoke();
        }
    }
}
