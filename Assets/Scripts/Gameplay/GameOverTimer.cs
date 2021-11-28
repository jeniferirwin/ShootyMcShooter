using System;
using System.Collections;
using Shooty.Core;
using UnityEngine;
using Shooty.UI;

namespace Shooty.Gameplay
{
    public class GameOverTimer : MonoBehaviour
    {
        [SerializeField] private float delay;
        [SerializeField] private GameObject gameOverText;
        [SerializeField] private GameObject[] pages;
        [SerializeField] private GameObject pagesContainer;
        [SerializeField] private GameObject highScores;
        [SerializeField] private GameObject gameplay;
        [SerializeField] private GameObject endInstructions;
        
        private void Start()
        {
            RoundData.GameOver += GameOver;
        }
        
        public void DisableGameOverText()
        {
            gameOverText.SetActive(false);
            endInstructions.SetActive(true);
        }
        
        public void EnableGameOverText()
        {
            gameOverText.SetActive(true);
            endInstructions.SetActive(false);
        }
        
        private void GameOver(object sender, EventArgs e)
        {
            gameOverText.SetActive(true);
            endInstructions.SetActive(false);
            StartCoroutine(GameOverDelay());
        }
        
        public void ForceGameOver()
        {
            RoundData.ForceGameOver();
        }
        
        private IEnumerator GameOverDelay()
        {
            EnableGameOverText();
            yield return new WaitForSeconds(delay);
            DisableGameOverText();
            MenuCommander.FlipHighScore();
            gameplay.SetActive(false);
        }
    }
}
