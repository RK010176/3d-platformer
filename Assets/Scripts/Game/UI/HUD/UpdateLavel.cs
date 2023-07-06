using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;


namespace Game
{

    public class UpdateLavel : MonoBehaviour
    {
        public Text Text;
        [SerializeField] private IntVal _currentLevel;

        private void Awake()
        {
            Text.text = (_currentLevel.Value +1).ToString();
        }        
		
    }
}