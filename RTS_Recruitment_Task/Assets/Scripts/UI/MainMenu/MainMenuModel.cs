using Recruitment.MVC;
using UnityEngine;

namespace Recruitment.UI
{
    public class MainMenuModel : Model<MainMenuView>
    {
        [field: SerializeField]
        private PlayerStatisticController CurrentPlayerStatisticController { get; set; }

        protected virtual void Awake ()
        {
            UpdateBestTimeText();
        }

        private void UpdateBestTimeText ()
        {
            float bestTime = CurrentPlayerStatisticController.GetBestTimeScore();
            CurrentView.ChangeScoreText(bestTime);
        }
    }
}