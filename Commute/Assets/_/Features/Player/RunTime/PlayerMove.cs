using System;
using System.Collections.Generic;
using Ghost;
using Spawn;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerAssembly
{
    public class PlayerMove : MonoBehaviour
    {
        #region Api Unity
    
        void FixedUpdate()
        {
            transform.position += transform.forward * (_playerSpeed * Time.deltaTime);
            RotationCar();
            
            //Enregistrement du mouvement
            _positions.Add(transform.position);
            _rotations.Add(transform.rotation.y);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_hasFinished) return;
            if (other.gameObject.layer == LayerMask.NameToLayer("Finish"))
            {
                _hasFinished = true;
                SaveAsGhost();
                gameObject.SetActive(false);
                _spawnerManager.RestartRound();
                other.gameObject.SetActive(false);

            }

            if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle")|| other.gameObject.layer == LayerMask.NameToLayer("Ghost"))
            {
                gameObject.SetActive(false);
            }
        }

        #endregion
        
        
        #region Main Methods
        
        
        
        #endregion
    
    
        #region Utils

        private void RotationCar()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(transform.up * (-_playerRotationSpeed * Time.deltaTime));
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(transform.up * (_playerRotationSpeed * Time.deltaTime));
            }
        }

        private void SaveAsGhost()
        {
            GhostData ghost = new GhostData();
            ghost.m_positions.AddRange(_positions);
            ghost.m_rotations.AddRange(_rotations);
            
            GhostManager.m_instance.m_allGhosts.Add(ghost);
        }
        
        

        #endregion
    
    
        #region Private And Protected
    
        [SerializeField] private float _playerSpeed = 3f;
        [SerializeField] private float _playerRotationSpeed = 180f;
        [SerializeField] private SpawnerManager _spawnerManager;
        
        private List<Vector3> _positions = new List<Vector3>();
        private List<float> _rotations = new List<float>();
        private bool _hasFinished = false;
    
        #endregion
    }
}
