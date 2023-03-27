using Recruitment.MVC;
using System;
using TMPro;
using UnityEngine;

namespace Recruitment.UI
{
    public class MainMenuView : View
    {
        [field: SerializeField]
        private TextMeshProUGUI TimeText { get; set; }

        public void ChangeScoreText (float value)
        {
            TimeText.text = GetTimeStringFromSecondsValue(value);
        }

        private string GetTimeStringFromSecondsValue (float seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return $"{time.Minutes:D2}:{time.Seconds:D2}";
        }
    }
}