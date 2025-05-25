using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Ghost
{
    [System.Serializable]
    public class GhostData : MonoBehaviour
    {
        #region Publics
        
        public List<Vector3> m_positions = new List<Vector3>();
        public List<float> m_rotations = new List<float>();
        #endregion
    }
}
