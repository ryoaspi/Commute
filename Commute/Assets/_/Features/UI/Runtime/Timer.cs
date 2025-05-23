using UnityEngine;

namespace UiManager
{
    public class Timer : MonoBehaviour
    {
        #region Api Unity
        
        void Start()
        {
            _currentTime = _timerMax;
        }

        
        void Update()
        {
            _currentTime -= Time.deltaTime;
        }
        
        #endregion
        
        
        #region Private And Protected

        [SerializeField] private float _timerMax = 60;

        private float _currentTime;

        #endregion
    }
}
