using System;
using UnityEngine;

namespace Ghost
{
    public class GhostReplay : MonoBehaviour
    {
        #region Api Unity

        private void OnEnable()
        {
            _activation = GetComponent<BoxCollider>();
            _activation.GetComponent<BoxCollider>().enabled = false; ;
        }

        private void FixedUpdate()
        {
            _time += Time.fixedDeltaTime;
            
            // Si on n’a pas de données ou si l'index dépasse la fin de la liste, on arrête ici
            if (_data == null || _index >= _data.m_positions.Count)
            {
                gameObject.SetActive(false);
                return;
            }
            
            // On positionne le fantôme à la position enregistrée à cet index
            transform.position = _data.m_positions[_index];
            // On applique la rotation enregistrée à cet index (rotation sur l'axe Y uniquement)
            transform.rotation = Quaternion.Euler(0f,_data.m_rotations[_index],0f);
            _index++;
            
            if (_time >= _timeDelay) _activation.GetComponent<BoxCollider>().enabled = true;
        }

        #endregion
        
        
        #region Main Methods

        public void InitGhost(GhostData data)
        {
            _data = data;
        }
        
        #endregion
        
        
        #region Privates And Protected
        
        private float _timeDelay = 1f;
        private GhostData _data;
        private int _index = 0;
        private float _time = 0f;
        private Component _activation;
        
        #endregion
    }
}
