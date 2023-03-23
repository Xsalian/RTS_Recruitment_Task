using Recruitment.MVC;
using TMPro;
using UnityEngine;

namespace Recruitment.UI
{
    public class InformationView : View
    {
        [field: SerializeField]
        public TextMeshProUGUI Label { get; set; }

        public void SetLabelText (string targetText)
        {
            Label.text = targetText;
        }
    }
}