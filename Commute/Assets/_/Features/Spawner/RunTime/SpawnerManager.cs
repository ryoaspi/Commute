using Ghost;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawn
{
    public class SpawnerManager : MonoBehaviour
    {
        #region Api Unity
        
        void Start()
        {
            RandomSpawn();
        }

        private void Update()
        {
            _ghostTime += Time.deltaTime;
        }

        #endregion
        
        
        #region Main Methods

        public void RestartRound()
        {
            
            RandomSpawn();

            
        }

        public void RandomSpawn()
        {
            _start = Random.Range(0, _spawnerPrefab.Length);
            _finish = Random.Range(0, _spawnerPrefab.Length);

            while (_finish == _start)
            {
                _finish = Random.Range(0, _spawnerPrefab.Length);
            }
          

            var player = Instantiate(_playerPrefab[RandomPlayer()]);
            player.transform.position =  _spawnerPrefab[_start].position;
            player.transform.rotation =  Quaternion.LookRotation(_spawnerPrefab[_start].transform.forward);
            
            var finish = Instantiate(_finishZone);
            finish.transform.position = _spawnerPrefab[_finish].position;

            Invoke("SpawnGhosts", _ghostDelay);

        }

        #endregion
        
        
        #region Utils

        private int RandomPlayer()
        {
            _playerNb = Random.Range(0, _playerPrefab.Length);
            return _playerNb;
        }

        private void SpawnGhosts()
        {
            
            // 💡 Partie ajoutée pour instancier tous les ghosts enregistrés
            foreach (GhostData ghost in GhostManager.m_instance.m_allGhosts)
            {

                // Crée une rotation Y à partir de la première valeur enregistrée
                Quaternion rotation = Quaternion.Euler(0f, ghost.m_rotations[0], 0f);
                // Instancie une voiture fantôme au bon endroit, avec la bonne rotation
                GameObject ghostCar = Instantiate(_playerPrefab[RandomPlayer()], ghost.m_positions[0], rotation);
                ghostCar.layer = LayerMask.NameToLayer("Ghost");
                // Ajoute le script GhostReplay pour lire les mouvements
                var replay = ghostCar.AddComponent<GhostReplay>();
                // Envoie les données à rejouer à ce ghost
                replay.InitGhost(ghost);
            }
        }

        #endregion
        
        
        #region Private And Protected
        
        [SerializeField] private Transform[] _spawnerPrefab;
        [SerializeField] private GameObject[] _playerPrefab;
        [SerializeField] private GameObject _finishZone;
       
        private int _start;
        private int _finish;
        private int _playerNb;
        private float _ghostDelay = 0.5f;
        private float _ghostTime;
        private bool _spawnGhost;
        
        #endregion
    }
}
