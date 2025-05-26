using Ghost;
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
        
        #endregion
        
        
        #region Main Methods

        public void RestartRound()
        {
            //Supprime tous les objets sur le layer "player"
            int playerLayer = LayerMask.NameToLayer("Player");
            int finishlayer = LayerMask.NameToLayer("Finish");
            
            GameObject[] allObjects = FindObjectsOfType<GameObject>();

            foreach (GameObject obj in allObjects)
            {
                if (obj.layer == finishlayer || obj.layer == playerLayer || obj.layer == LayerMask.NameToLayer("Ghost"))
                {
                    Destroy(obj);
                }
            }
            // relance un nouveau spawn
            RandomSpawn();
        }

        public void RandomSpawn()
        {
            _start = Random.Range(0, _spawnerPrefab.Length);
            _finish = Random.Range(0, _spawnerPrefab.Length);

            if (_start == _finish)
            {
                _finish = Random.Range(0, _spawnerPrefab.Length);
            }

            Instantiate(_playerPrefab[RandomPlayer()], _spawnerPrefab[_start].position,
                Quaternion.LookRotation(_spawnerPrefab[_start].transform.forward));
            Instantiate(_finishZone, _spawnerPrefab[_finish].position, Quaternion.identity);

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
        
        
        #region Utils

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
