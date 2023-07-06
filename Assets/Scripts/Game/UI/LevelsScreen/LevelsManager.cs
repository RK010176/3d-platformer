using App;
using Common;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Game
{

    public class LevelsManager : MonoBehaviour
    {

        public GameObject LevelItemPrefab;
        public Levels Levels;
        public IntVal CurrentLevel;
        public Color CurrentLevelColor;
        public Color FinishedLevelColor;
        public Color NotFinishedLevelColor;


        void Start()
        {
            PopulateLevels();
        }

        private void PopulateLevels()
        {
            for (int i = 0; i < Levels.levels.Count; i++)
            {
                GameObject obj = Instantiate(LevelItemPrefab);
                obj.transform.parent = transform;
                obj.transform.localScale = new Vector3(1, 1, 1);

                obj.transform.GetChild(0).GetComponent<Text>().text = (i + 1).ToString();

                if (CurrentLevel.Value == i)
                {
                    obj.GetComponent<Image>().color = CurrentLevelColor;
                    obj.transform.GetChild(0).GetComponent<Text>().color = CurrentLevelColor;
                }
                if (CurrentLevel.Value > i)
                {
                    obj.GetComponent<Image>().color = FinishedLevelColor;
                    obj.transform.GetChild(0).GetComponent<Text>().color = FinishedLevelColor;
                    obj.GetComponent<LevelSetter>().LevelId = i;
                    obj.GetComponent<Button>().onClick.AddListener(() => obj.GetComponent<LevelSetter>().SetLevel());
                }
                if (CurrentLevel.Value < i)
                {
                    obj.GetComponent<Image>().color = NotFinishedLevelColor;
                    obj.transform.GetChild(0).GetComponent<Text>().color = NotFinishedLevelColor;
                }

            }
        }

        public void RePopulateLevels()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            PopulateLevels();
        }
    }
}