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
            var scale = PersistentData.CurrentScale;
            transform.localScale = new Vector3(scale, scale, scale);
            source = GameObject.Find("SFXPlayer").GetComponent<AudioSource>();
        }

        public void GetShot()
        {
            PersistentData.IncrementScore();
            source.PlayOneShot(shot);
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            PersistentData.IncrementMissed();
            Destroy(gameObject);
        }
    }
}
