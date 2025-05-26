using UnityEngine;

namespace Ghost
{
    public class GhostReplay : MonoBehaviour
    {
        #region Api Unity

        private void FixedUpdate()
        {
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
        }

        #endregion
        
        
        #region Main Methods

        public void InitGhost(GhostData data)
        {
            _data = data;
        }
        
        #endregion
        
        
        #region Privates And Protected
        
        private GhostData _data;
        private int _index = 0;

        #endregion
    }
}
