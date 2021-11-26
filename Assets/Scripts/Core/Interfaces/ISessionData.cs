namespace Shooty.Core
{
    public interface ISessionData
    {
        public event PlayerNameChanged OnPlayerNameChanged;
        public string GetPlayerName();
        public string SetPlayerName();
        public bool GetHasSeenInstructions();
        public void SetHasSeenInstructions(bool value);
    }
}