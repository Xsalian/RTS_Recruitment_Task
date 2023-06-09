using Recruitment.GameplayManagment;
using System.Collections.Generic;
using UnityEngine;

namespace Recruitment.InteractionManagment
{
    public class Chest : MonoBehaviour, IInteractable
    {
        [field: SerializeField]
        public string ConfirmationText { get; set; }
        [field: SerializeField]
        public string InformationText { get; set; }
        [field: SerializeField]
        private GameObject Contents { get; set; }
        [field: SerializeField]
        private Animator CurrentAnimator { get; set; }
        [field: SerializeField]
        private GameplayController CurrentGameplayController { get; set; }
        [field: SerializeField]
        private List<Renderer> RendererCollection { get; set; } = new();
        [field: SerializeField]
        private Highlighter CurrentHighlighter { get; set; }

        private bool IsChestClosed { get; set; } = true;

        private const string OPEN_CHEST_TRIGGER = "OpenChest";
        private const string IDLE_CHEST_TRIGGER = "ResetChest";

        public void Interaction ()
        {
            IsChestClosed = false;
            Contents.SetActive(true);
            CurrentAnimator.SetTrigger(OPEN_CHEST_TRIGGER);
        }

        public bool CanInteract ()
        {
            return IsChestClosed == true;
        }

        public void Highlight ()
        {
            CurrentHighlighter.ChangeHighlightColor(RendererCollection, true);
        }

        public void StopHighlight ()
        {
            CurrentHighlighter.ChangeHighlightColor(RendererCollection, false);
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
            CurrentAnimator.SetTrigger(IDLE_CHEST_TRIGGER);
            IsChestClosed = true;
        }
    }
}