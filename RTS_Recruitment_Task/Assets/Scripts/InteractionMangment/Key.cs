using Recruitment.GameplayManagment;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build.Content;
using UnityEngine;

namespace Recruitment.InteractionManagment
{
    public class Key : MonoBehaviour, IInteractable
    {
        [field: SerializeField]
        public string ConfirmationText { get; set; }
        [field: SerializeField]
        public string InformationText { get; set; }
        [field: SerializeField]
        private GameplayController CurrentGameplayController { get; set; }
        [field: SerializeField]
        private List<Renderer> RendererCollection { get; set; } = new();
        [field: SerializeField]
        private Highlighter CurrentHighlighter { get; set; }

        public void Interaction ()
        {
            CurrentGameplayController.IsKeyCollected = true;
            gameObject.SetActive(false);
        }

        public bool CanInteract ()
        {
            return true;
        }

        public void Highlight()
        {
            CurrentHighlighter.ChangeHighlightColor(RendererCollection, true);
        }

        public void StopHighlight()
        {
            CurrentHighlighter.ChangeHighlightColor(RendererCollection, false);
        }
    }
}