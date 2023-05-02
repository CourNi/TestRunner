using System.Collections.Generic;
using UnityEngine;

namespace Tools.Pool
{
    [DefaultExecutionOrder(-1)]
    public class ObjectPool : MonoBehaviour
    {
        [System.Serializable]
        public class Pool
        {
            public int Id;
            public GameObject Prefab;
            public int Size;
        }

        public List<Pool> _pools;
        public Dictionary<int, Queue<GameObject>> _poolDictionary;

        private void Awake()
        {
            _poolDictionary = new Dictionary<int, Queue<GameObject>>();

            foreach (Pool pool in _pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.Size; i++)
                {
                    GameObject obj = Instantiate(pool.Prefab, Vector3.zero, Quaternion.identity, transform);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
                _poolDictionary.Add(pool.Id, objectPool);
            }
        }

        public GameObject Spawn(int tag, Vector3 position, Vector3 target)
        {
            GameObject objectToSpawn = _poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);

            IPoolable pooledObj = objectToSpawn.GetComponent<IPoolable>();
            pooledObj?.OnObjectSpawn(position, target);

            _poolDictionary[tag].Enqueue(objectToSpawn);
            return objectToSpawn;
        }

        public GameObject RandomSpawn(Vector3 position, Vector3 target) =>
            Spawn(Random.Range(0, _poolDictionary.Count), position, target);
    }
}