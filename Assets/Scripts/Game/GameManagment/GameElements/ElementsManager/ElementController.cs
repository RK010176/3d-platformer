using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

    public class ElementController : MonoBehaviour, IElement
    {
        public LevelGameElement GameElementSpecs { get; set; }

        void Start()
        {
            ProcessSpecs();
        }
        public void ProcessSpecs()
        {
            var fff = new System.Random();
            int num = fff.Next(3,30);
        }

    }
}