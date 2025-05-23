using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{
    public class SpawnerManager : MonoBehaviour
    {
        #region Api Unity
        
        void Start()
        {
            RandomSpawn();
        }

        
        void Update()
        {
        
        }
        
        #endregion
        
        
        #region Utils

        private void RandomSpawn()
        {
            _start = Random.Range(0, _spawnerPrefab.Length);
            _finish = Random.Range(0, _spawnerPrefab.Length);
            
            if (_start == _finish)
            {
                _finish = Random.Range(0, _spawnerPrefab.Length);
            }
            
            Instantiate(_playerPrefab[RandomPlayer()], _spawnerPrefab[_start].position, Quaternion.LookRotation(_spawnerPrefab[_start].transform.forward));
            Instantiate(_finishZone, _spawnerPrefab[_finish].position, Quaternion.identity);
            
        }

        private int RandomPlayer()
        {
            _playerNb = Random.Range(0, _playerPrefab.Length);
            return _playerNb;
        }
        
        #endregion
        
        
        #region Private And Protected
        
        [SerializeField] private Transform[] _spawnerPrefab;
        [SerializeField] private GameObject[] _playerPrefab;
        [SerializeField] private GameObject _finishZone;
       
        private int _start;
        private int _finish;
        private int _playerNb;

        #endregion
    }
}
