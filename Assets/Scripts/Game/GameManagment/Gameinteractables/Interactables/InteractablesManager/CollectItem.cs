using UnityEngine;


namespace Game
{
    public class CollectItem : MonoBehaviour
    {

        private DataHandler _dataHandler;
        private ObjectPool _pool;

        private void Start()
        {
            _dataHandler = GetComponent<DataHandler>();
            _pool = GameObject.Find("CollectPool").GetComponent<ObjectPool>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                if (transform.GetChild(0).name.Contains("Coin"))
                {
                    _dataHandler.CoinAmount.Value++;
                    _dataHandler.CoinCollectEvent.Raise();
                }
                if (transform.GetChild(0).name.Contains("Key"))
                {
                    _dataHandler.KeyVal.Value = true;
                    _dataHandler.KeyEvent.Raise();
                }

                GameObject effect = _pool.GetPooledObject();
                effect.transform.position = transform.position;
                Destroy(transform.gameObject);
            }
        }


    }
}