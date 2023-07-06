using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;


namespace Game
{

	public class UpdateCoins : MonoBehaviour
	{
		public Text Text;
		[SerializeField] private IntVal _currentCoins;

		private void Awake()
		{
			DisplayValue();
		}        

		public void DisplayValue()
		{
			Text.text = (_currentCoins.Value).ToString();			
		}

	}
}