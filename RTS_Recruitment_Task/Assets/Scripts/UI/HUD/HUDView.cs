using Recruitment.MVC;
using System;
using TMPro;
using UnityEngine;

namespace Recruitment.UI 
{
    public class HUDView : View
    {
        [field: SerializeField]
        private TextMeshProUGUI TimerText { get; set; }

        public void ChangeTimerText (float value)
        {
            TimerText.text = GetTimeStringFromSecondsValue(value);
        }

        private string GetTimeStringFromSecondsValue (float seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return $"{time.Minutes:D2}:{time.Seconds:D2}";
        }
    }
}