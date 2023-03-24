using Recruitment.MVC;
using System;
using TMPro;
using UnityEngine;

namespace Recruitment.UI
{
    public class MainMenuView : View
    {
        [field: SerializeField]
        private PlayerStatisticController CurrentPlayerStatisticController { get; set; }
        [field: SerializeField]
        private TextMeshProUGUI TimeText { get; set; }

        public void UpdateScoreTexts ()
        {
            float bestTime = CurrentPlayerStatisticController.GetBestTimeScore();
            TimeText.text = GetTimeStringFromSecondsValue(bestTime);
        }

        private string GetTimeStringFromSecondsValue (float seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return $"{time.Minutes:D2}:{time.Seconds:D2}";
        }
    }
}