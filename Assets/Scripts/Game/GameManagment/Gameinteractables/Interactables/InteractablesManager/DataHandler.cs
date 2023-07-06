using Common;
using UnityEngine;

namespace Game
{
    public class DataHandler : MonoBehaviour
    {
        public BoolVal KeyVal;
        public IntVal CoinAmount;
	    public Game_Event KeyEvent;
        public Game_Event CoinCollectEvent;


        private void Start()
        {
	        if (KeyVal.Value)
		        KeyVal.Value = false;	        
        }
    }



}