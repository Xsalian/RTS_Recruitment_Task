using Recruitment.GameplayManagment;
using Recruitment.MVC;
using UnityEngine;

namespace Recruitment.UI
{
    public class SummaryController : Controller<SummaryView, SummaryModel>
    {
        [field: SerializeField]
        private GameplayController CurrentGameplayController { get; set; }
        [field: SerializeField]
        private GameObject SummaryPanel { get; set; }

        public void TryAgain ()
        {
            SummaryPanel.SetActive(false);
            CurrentGameplayController.StartGame();
        }

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
            CurrentGameplayController.GameEnded += HandleOnGameEnded;
        }

        private void DetachFromEvent ()
        {
            CurrentGameplayController.GameEnded -= HandleOnGameEnded;
        }

        private void HandleOnGameEnded ()
        {
            SummaryPanel.SetActive(true);
            CurrentModel.CheckIfLastTimeWasBestTime(CurrentGameplayController.CurrentTime);
        }
    }
}