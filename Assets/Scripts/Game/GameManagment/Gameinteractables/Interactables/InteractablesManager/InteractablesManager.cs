using Common;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class InteractablesManager : MonoBehaviour
    {
        public List<LevelInteractable> Interactables { get; set; }        

        public void AddInteractables()
        {
            foreach (var InteractableItem in Interactables)
            {
                AddInteactable(InteractableItem);
            }  
        }

        private void AddInteactable(LevelInteractable InteractableItem)
        {                        
            GameObject InteractableGameObject = Instantiate(InteractableItem.InteractableShape,
                                                                        InteractableItem.Position,
                                                                        Quaternion.Euler(InteractableItem.Rotation));
            
            switch (InteractableItem.Action)
            {
                case Actions.TargetItem:
                    InteractableGameObject.AddComponent<TargetItem>();
                    break;
                case Actions.CollectItem:
                    InteractableGameObject.AddComponent<CollectItem>();
                    break;
            }

            // add Game Element to Inteactable
            Instantiate(InteractableItem.Element.prefab, InteractableGameObject.transform);
        }
        
        public void RemoveInteractables()
        { 
            
        }
    }

}