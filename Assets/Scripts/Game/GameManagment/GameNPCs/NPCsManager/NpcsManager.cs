using UnityEngine;
using Common;

namespace Game
{
    public class NpcsManager : MonoBehaviour, INpcsManager
    {        
        public Level level { get; set; }
                
        public void AddNpcs()
        {
            for (int i = 0; i < level.Npcs.Count ; i++)
            { 
                 GameObject _go = Instantiate(level.Npcs[i].prefab, level.Npcs[i].SpawnPoint,Quaternion.identity);
                _go.GetComponent<INpc>().NpcBehaviors = level.Npcs[i];
            }
        }

        public void RemoveNPCs()
        {
            for (int i = 0; i < level.Npcs.Count; i++)
            {
                Destroy(level.Npcs[i].prefab);
            }
        
        }
        
    }
}