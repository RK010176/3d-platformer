using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public class ObjectPool : MonoBehaviour
    {
        public GameObject prefab;
        [SerializeField] private int _poolSize = 10;

        private List<GameObject> _pooledObjects = new List<GameObject>();

        private void Start()
        {
            InitializeObjectPool();
        }

        private void InitializeObjectPool()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.transform.parent = transform;
                obj.SetActive(false);
                _pooledObjects.Add(obj);
            }
        }

        public GameObject GetPooledObject()
        {
            foreach (GameObject obj in _pooledObjects)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    StartCoroutine(Appearance(obj.transform));
                    return obj;
                }
            }

            // If no inactive object found, create a new one and add it to the pool
            GameObject newObj = Instantiate(prefab);
            newObj.transform.parent = transform;
            _pooledObjects.Add(newObj);
            StartCoroutine(AppearanceAndDestruction(newObj.transform));
            return newObj;
        }

        private IEnumerator Appearance(Transform tr)
        {            
            yield return new WaitForSeconds(0.5f);
            ReturnToPool(tr.gameObject);
        }

        public void ReturnToPool(GameObject obj)
        {
            obj.SetActive(false);
        }

        private IEnumerator AppearanceAndDestruction(Transform tr)
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(tr.gameObject);
        }

    }
}