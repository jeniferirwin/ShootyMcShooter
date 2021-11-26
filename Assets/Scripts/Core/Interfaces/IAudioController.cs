namespace Shooty.Core
{
    public interface IAudioController
    {
        public float GetSFXVolume();
        public float GetMusicVolume();
        public void SetMusicVolume(float value);
        public void SetSFXVolume(float value);
    }
}