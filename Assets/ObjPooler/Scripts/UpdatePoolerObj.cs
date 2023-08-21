using System;
using System.Collections;
using UnityEngine;

namespace ObjPooler.Scripts
{
    public class UpdatePoolerObj : MonoBehaviour
    {
        private event Action OnStartLifeTime;
        
        private Camera _camera;
        private float _lifeTime = 3f;
        private float _startLife = 0f;


        private void OnEnable()
        {
            StartCoroutine(Timer());
        }

        private void OnDisable()
        {
            // OnStartLifeTime -= HandleLifeTime;
        }

        private void HandleLifeTime()
        {
            StartCoroutine(Timer());
        }

        private void Start()
        {
            _camera = Camera.main;
            // StartCoroutine(Timer());
        }
        
        

        private IEnumerator Timer()
        {
            _startLife = 0f;
            while (_startLife < _lifeTime)
            {
                _startLife += Time.deltaTime;
                yield return null;
            }
            Pooler.Instance.ReturnToPool(this);
            OnStartLifeTime?.Invoke();
        }
    }
}
