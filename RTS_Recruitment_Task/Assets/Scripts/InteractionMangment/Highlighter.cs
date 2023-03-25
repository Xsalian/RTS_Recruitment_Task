using System.Collections.Generic;
using UnityEngine;

namespace Recruitment.InteractionManagment
{
    public class Highlighter : MonoBehaviour
    {
        [field: SerializeField]
        private float HighlightPower { get; set; }

        public void ChangeHighlightColor (List<Renderer> rendererCollection, bool isObjectHighlited)
        {
            int mutiplier = isObjectHighlited ? 1 : -1;
            Color targetColor = new Color(HighlightPower, HighlightPower, HighlightPower) * mutiplier;

            for (int rendererIndex = 0; rendererIndex < rendererCollection.Count; rendererIndex++)
            {
                for (int materialIndex = 0; materialIndex < rendererCollection[rendererIndex].materials.Length; materialIndex++)
                {
                    rendererCollection[rendererIndex].materials[materialIndex].color += targetColor;
                }
            }
        }
    }
}