using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Shooty.Core;
using UnityEngine;

namespace Shooty.UI
{
    public class PopulateHighScores : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private GameObject noScoresNotice;

        private static SaveData data;

        private void Start()
        {
            if (data.scoreSlots.Count == 0)
            {
                noScoresNotice.SetActive(true);
                return;
            }
            foreach (var slot in data.scoreSlots)
            {
                var newSlot = GameObject.Instantiate(prefab, transform.position, Quaternion.identity, transform);
                HighScoreSlotControl control = newSlot.GetComponent<HighScoreSlotControl>();
                control.SetNameText(slot.name);
                control.SetScoreText(slot.score.ToString("F"));
            }
            SaveScoreData();
        }
        
        public static void ClearScoreData()
        {
            data = new SaveData();
        }

        public static void InitializeScoreData()
        {
            data = new SaveData();
            if (File.Exists(PersistentData.SavePath))
            {
                string json = File.ReadAllText(PersistentData.SavePath);
                data = JsonUtility.FromJson<SaveData>(json);
            }
        }

        public static void SaveScoreData()
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(PersistentData.SavePath, json);
        }

        public static void RecordScore()
        {
            data.AddScore(PersistentData.PlayerName, PersistentData.CurrentScale);
        }

        private void EnterDummyData()
        {
            data.AddScore("Cooler Player", 0.23f);
            data.AddScore("Cool Player", 0.38f);
            data.AddScore("Impossible Player", -0.2f);
            data.AddScore("Perfect Player", 0.0f);
            data.AddScore("Bad Player", 1.49f);
        }
    }

    [Serializable]
    public class SaveData
    {
        public List<ScoreSlot> scoreSlots;

        public SaveData()
        {
            scoreSlots = new List<ScoreSlot>();
        }

        public void AddScore(string name, float score)
        {
            ScoreSlot newSlot = new ScoreSlot(name, score);

            if (scoreSlots.Count == 0)
            {
                scoreSlots.Add(newSlot);
                return;
            }

            for (int i = 0; i < scoreSlots.Count && i < 10; i++)
            {
                if (newSlot.score < scoreSlots[i].score)
                {
                    scoreSlots.Insert(i, newSlot);
                    TrimSlots();
                    return;
                }
            }

            scoreSlots.Add(newSlot);
            TrimSlots();
        }

        public void TrimSlots()
        {
            if (scoreSlots.Count > 5)
            {
                scoreSlots = scoreSlots.GetRange(0, 5);
            }
        }
    }

    [Serializable]
    public class ScoreSlot
    {
        public string name;
        public float score;

        public ScoreSlot(string newName, float newScore)
        {
            name = newName;
            score = newScore;
        }
    }
}
