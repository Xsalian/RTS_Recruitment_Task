using Recruitment.MVC;
using UnityEngine;

namespace Recruitment.UI
{
    public class SummaryModel : Model<SummaryView>
    {
        [field: SerializeField]
        private PlayerStatisticController CurrentPlayerStatisticController { get; set; }

        public void CheckIfLastTimeWasBestTime (float lastTime)
        {
            float bestTime = CurrentPlayerStatisticController.GetBestTimeScore();

            if (lastTime < bestTime || bestTime == 0.0f)
            {
                CurrentPlayerStatisticController.SaveBestTimeScore(lastTime);
                bestTime = lastTime;
            }

            CurrentView.UpdateScoreTexts(bestTime, lastTime);
        }
    }
}