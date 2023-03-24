using Recruitment.MVC;
using System;
using TMPro;
using UnityEngine;

namespace Recruitment.UI
{
    public class SummaryView : View
    {
        [field: SerializeField]
        private TextMeshProUGUI BestTimeText { get; set; }
        [field: SerializeField]
        private TextMeshProUGUI LastTimeText { get; set; }

        public void UpdateScoreTexts (float bestTime, float lastTime)
        {
            BestTimeText.text = GetTimeStringFromSecondsValue(bestTime);
            LastTimeText.text = GetTimeStringFromSecondsValue(lastTime);
        }

        private string GetTimeStringFromSecondsValue (float seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return $"{time.Minutes:D2}:{time.Seconds:D2}";
        }
    }
}