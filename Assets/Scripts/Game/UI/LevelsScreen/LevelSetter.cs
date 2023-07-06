using Common;
using UnityEngine;


namespace Game
{
    public class LevelSetter : MonoBehaviour
    {
        public IntVal CurrentLevel;
        private int _levelId;
        public int LevelId
        {
            get { return _levelId; }
            set { _levelId = value; }
        }


        void Start(){}

        public void SetLevel()
        {
            CurrentLevel.Value = _levelId;
            transform.parent.GetComponent<LevelsManager>().RePopulateLevels();
        }
        

    }
}