using Spawn;
using UnityEngine;

namespace GameManager
{
    public class GameManager : MonoBehaviour
    {
        public void ResetRound()
        {
            GameObject[] allObjects = FindObjectsOfType<GameObject>();

            foreach (GameObject obj in allObjects)
            {
                if (obj.layer == _playerLayer || obj.layer == _finishLayer || obj.layer == _ghostLayer)
                {
                    Destroy(obj);
                }
            }

            // Lancer le spawn après un court délai (0.5 seconde)
            Invoke(nameof(DelayedSpawn), 0.5f);
        }

        private void DelayedSpawn()
        {
            _spawnerManager.RandomSpawn();
        }
        
        #region Private And Protected
        
        [SerializeField] private int _playerLayer;
        [SerializeField] private int _finishLayer;
        [SerializeField] private int _ghostLayer;
        [SerializeField] private SpawnerManager _spawnerManager;
        
        #endregion
    }
}
