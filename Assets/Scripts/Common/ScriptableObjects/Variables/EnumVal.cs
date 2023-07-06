using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Common
{

	[CreateAssetMenu(fileName = "New EnumVal", menuName = "core/EnumVal")]
	public class EnumVal : ScriptableObject
	{
		public enum Enum
		{
			one,two,three,four,five,six
		}

		public Enum Value;

		public void SetValue(Enum value)
		{
			Value = value;
		}

	}



}