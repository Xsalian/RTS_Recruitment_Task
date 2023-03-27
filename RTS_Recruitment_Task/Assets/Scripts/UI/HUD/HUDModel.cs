using Recruitment.GameplayManagment;
using Recruitment.MVC;
using UnityEngine;

namespace Recruitment.UI
{
    public class HUDModel : Model<HUDView>
    {
        [field: SerializeField]
        private GameplayController CurrentGameplayController { get; set; }

        protected virtual void Start ()
        {
            AttachToEvent();
        }

        protected virtual void OnDestroy ()
        {
            DetachFromEvent();
        }

        private void AttachToEvent ()
        {
            CurrentGameplayController.TimerValueChanged += HandleOnTimerValueChanged;
        }

        private void DetachFromEvent ()
        {
            CurrentGameplayController.TimerValueChanged -= HandleOnTimerValueChanged;
        }

        private void HandleOnTimerValueChanged (float value)
		{
            CurrentView.ChangeTimerText(value);
		}
    }
}