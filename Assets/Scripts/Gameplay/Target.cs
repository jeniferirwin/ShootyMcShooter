using UnityEngine;
using Shooty.Core;

namespace Shooty
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private AudioClip shot;

        private AudioSource source;

        private void Awake()
        {
            var scale = RoundData.CurrentScale;
            transform.localScale = new Vector3(scale, scale, scale);
            source = GameObject.Find("SFXPlayer").GetComponent<AudioSource>();
        }

        public void GetShot()
        {
            RoundData.IncrementScore();
            source.PlayOneShot(shot);
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            RoundData.IncrementEscaped();
            Destroy(gameObject);
        }
    }
}
