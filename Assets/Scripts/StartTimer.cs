using UnityEngine;
using TMPro;

namespace Shooty
{
    public class StartTimer : MonoBehaviour
    {
        [SerializeField] private TMP_Text countdownText;
        [SerializeField] private GameObject spawners;

        private int _countdown = 5;
        private float _tick = 1;

        private void Start()
        {
            countdownText.text = _countdown.ToString();
        }
        private void Update()
        {
            if (_tick > 0)
            {
                _tick -= Time.deltaTime;
                return;
            }
            if (_countdown > 1)
            {
                _tick = 1;
                _countdown -= 1;
                countdownText.text = _countdown.ToString();
                return;
            }
            spawners.SetActive(true);
            Destroy(gameObject);
        }
    }
}
