using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Common
{

	[CreateAssetMenu(fileName = "New BoolVal", menuName = "core/BoolVal")]
	public class BoolVal : ScriptableObject
	{
#if UNITY_EDITOR
		[Multiline]
		public string DeveloperDescription = "";
#endif
		public bool Value;

		public void SetValue(bool value)
		{
			Value = value;
		}

		public void SetValue(BoolVal value)
		{
			Value = value.Value;
		}
		
	}
}