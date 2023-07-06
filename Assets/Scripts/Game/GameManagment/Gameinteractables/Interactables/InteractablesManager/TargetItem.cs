using UnityEngine;
using App;
using Common;

namespace Game
{
    public class TargetItem : MonoBehaviour
    {                
        private bool _interaction = false;

        private BoolVal _keyVal;
        
        private void Start()
        {
            _keyVal = GetComponent<DataHandler>().KeyVal;
        }

        private void OnTriggerEnter(Collider other)
        {            
            if (other.tag == "Player") 
                _interaction = true;                            
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")            
                _interaction = false;            
        }

        private void Update()
        {
            if (_interaction)
            {
                if (_keyVal.Value) 
                {
                    _interaction = false;
                    ApplicationEvents.LevelEnded(true);                                       
                }
                
            }
        }

    }
}