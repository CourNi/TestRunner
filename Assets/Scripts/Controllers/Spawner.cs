using System.Collections;
using Tools.Pool;
using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(ObjectPool))]
    public class Spawner : Controller
    {
        [SerializeField] private float _spawnTime = 5.0f;
        private ObjectPool _pool;
        [Header("Waypoints")]
        [SerializeField] private Vector3 _spawnPoint = new Vector3(12f, -5f, 0);
        [SerializeField] private Vector3 _endPoint = new Vector3(-12f, -5f, 0);
        private Wait _routine;

        public override void Init()
        {
            _pool = GetComponent<ObjectPool>();
            _pool.RandomSpawn(_spawnPoint, _endPoint);
            StartCoroutine(Spawn()); 
            base.Init();
        }

        public override void StartSequence() => _routine.Resume();
        public override void StopSequence() => _routine.Pause();

        private IEnumerator Spawn()
        {
            while (true)
            {
                _routine = new Wait(_spawnTime, this);
                yield return _routine;
                _pool.RandomSpawn(_spawnPoint, _endPoint);
            }
        }


    }
}
