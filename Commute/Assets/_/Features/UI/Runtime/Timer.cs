using TMPro;
using UnityEngine;

namespace UiManager
{
    public class Timer : MonoBehaviour
    {
        #region Publics
        
        public float m_currentTime;
        
        #endregion
        
        
        #region Api Unity
        
        void Start()
        {
            m_currentTime = _timerMax;
        }
        void Update()
        {
            m_currentTime -= Time.deltaTime;
            _timerText.text = m_currentTime.ToString().Normalize();

            if (m_currentTime <= 0)
            {
                Time.timeScale = 0;
            }
        }
        
        #endregion
        
        
        #region Private And Protected

        [SerializeField] private float _timerMax = 60;
        [SerializeField] private TMP_Text _timerText;

        #endregion
    }
}
