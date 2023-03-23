using UnityEngine;

namespace Recruitment.MVC
{
	public class Model<TView> : MonoBehaviour where TView : View
	{
		[field: SerializeField]
		protected TView CurrentView { get; private set; }
	}
}