using UnityEngine;

namespace Recruitment.UI 
{
    public class PlayerStatisticController : MonoBehaviour
    {
        private const string BEST_TIME_KEY = "BestTime";

        public float GetBestTimeScore ()
        {
            return PlayerPrefs.GetFloat(BEST_TIME_KEY);
        }

        public void SaveBestTimeScore (float value)
        {
            PlayerPrefs.SetFloat(BEST_TIME_KEY, value);
        }
    }
}