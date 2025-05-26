using System.Collections.Generic;
using UnityEngine;

namespace Ghost
{
    public class GhostManager : MonoBehaviour
    {
        #region Publics

        public static GhostManager m_instance;
        
        public List<GhostData> m_allGhosts = new List<GhostData>();
        

        #endregion
        
        
        #region Api Unity

        private void Awake()
        {
            if (m_instance == null) m_instance = this;
            else Destroy(gameObject);
        }

        #endregion
    }
}
