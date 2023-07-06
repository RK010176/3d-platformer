using Common;
using UnityEngine;
using App;

namespace Game
{ 
    public class Game_Manager : MonoBehaviour
    {        
        private Levels _levels;
        private PlayerManager _playerManager;
        private InteractablesManager _interactablesManager;
        private IElements _elementsManager;
        private INpcsManager _npcsManager;        
        [SerializeField] private IntVal _currentLevelNumber;        
        [SerializeField] private ObjectPool _hitPool;
        [SerializeField] private ObjectPool _collectPool;


        private void Awake() 
        {            
            ApplicationEvents.DisableCamAndLight();            

            // Load Level participants 
            _levels = Resources.Load<Levels>("GameLevels/GameLevels");
            
            _playerManager = GetComponent<PlayerManager>();
            _playerManager.Level = _levels.levels[_currentLevelNumber.Value];
            
            _interactablesManager = GetComponent<InteractablesManager>(); 
            _interactablesManager.Interactables = _levels.levels[_currentLevelNumber.Value].Interactables;
            
            _elementsManager = GetComponent<IElements>();
            _elementsManager.Elements = _levels.levels[_currentLevelNumber.Value].Elements;
            
            _npcsManager = GetComponent<INpcsManager>();
            _npcsManager.level = _levels.levels[_currentLevelNumber.Value];    
            
            _hitPool.prefab = _levels.levels[_currentLevelNumber.Value].HitPrefab;
            _collectPool.prefab = _levels.levels[_currentLevelNumber.Value].CollectionPrefab;

        }
        private void Start() 
        {            
            ScenesManager.Instance.SetSceneToActiveScene("Game"); 

            _playerManager.AddPlayer();
            _interactablesManager.AddInteractables();
            _elementsManager.AddElements();            
            _npcsManager.AddNpcs();           
        }

        private void OnDisable()
        {
            ApplicationEvents.EnableCamAndLight();
        }


    }
}