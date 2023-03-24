using Recruitment.GameplayManagment;
using Recruitment.MVC;
using UnityEngine;

namespace Recruitment.UI
{
    public class MainMenuController : Controller<MainMenuView, MainMenuModel>
    {
        [field: SerializeField]
        private GameplayController CurrentGameplayController { get; set; }

        public void StartGame ()
        {
            gameObject.SetActive(false);
            CurrentGameplayController.StartGame();
        }
        
        protected virtual void Awake ()
        {
            UpdateBestTimeText();
        }

        private void UpdateBestTimeText ()
        {
            CurrentView.UpdateScoreTexts();
        }
    }
}