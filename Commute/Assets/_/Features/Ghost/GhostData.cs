using System.Collections.Generic;
using UnityEngine;

namespace Ghost
{
    [System.Serializable]
    public class GhostData
    {
        #region Publics
        
        public List<Vector3> m_positions = new List<Vector3>();
        public List<float> m_rotations = new List<float>();
        #endregion
    }
}
