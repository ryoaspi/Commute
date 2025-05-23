using System;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerAssembly
{
    public class PlayerMove : MonoBehaviour
    {
        #region Api Unity
    
        void Start()
        {
        
        }
    
        void Update()
        {
            transform.position += transform.forward * (_playerSpeed * Time.deltaTime);
            RotationCar();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Finish"))
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
        
        

        #endregion
    
    
        #region Private And Protected
    
        [SerializeField] private float _playerSpeed = 3f;
        [SerializeField] private float _playerRotationSpeed = 180f;
    
        #endregion
    }
}
