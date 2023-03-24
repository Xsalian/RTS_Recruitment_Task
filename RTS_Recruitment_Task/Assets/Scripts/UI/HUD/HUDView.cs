using Recruitment.GameplayManagment;
using Recruitment.MVC;
using System;
using TMPro;
using UnityEngine;

namespace Recruitment.UI 
{
    public class HUDView : View
    {
        [field: SerializeField]
        private GameplayController CurrentGameplayController { get; set; }
        [field: SerializeField]
        private TextMeshProUGUI TimerText { get; set; }

        protected virtual void Start()
        {
            AttachToEvent();
        }

        protected virtual void OnDestroy()
        {
            DetachFromEvent();
        }

        private void AttachToEvent()
        {
            CurrentGameplayController.TimerValueChanged += HandleOnTimerValueChanged;
        }

        private void DetachFromEvent()
        {
            CurrentGameplayController.TimerValueChanged -= HandleOnTimerValueChanged;
        }

        private void HandleOnTimerValueChanged (float value)
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