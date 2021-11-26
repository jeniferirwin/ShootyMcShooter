using System.Collections;
using Shooty.Core;
using UnityEngine;

namespace Shooty
{
    public class GameOverTimer : MonoBehaviour
    {
        [SerializeField] private float delay;
        [SerializeField] private GameObject gameOverText;
        [SerializeField] private SceneLoader loader;
        
        private void Start()
        {
            RoundData.GameOver += GameOver;
        }
        
        private void OnDestroy()
        {
            RoundData.GameOver -= GameOver;
        }
        
        private void GameOver()
        {
            gameOverText.SetActive(true);
            StartCoroutine(GameOverDelay());
        }
        
        public void ForceGameOver()
        {
            RoundData.ForceGameOver();
        }
        
        private IEnumerator GameOverDelay()
        {
            yield return new WaitForSeconds(delay);
            loader.LoadScene();
        }
    }
}
