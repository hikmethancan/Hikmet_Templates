using UnityEngine;

namespace ObjPooler.Scripts
{
    public class PooledObjInputController : MonoBehaviour
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var obj = Pooler.Instance.Get();
                var pos = Input.mousePosition;
                obj.transform.position = _camera.ScreenToWorldPoint(pos);
                obj.gameObject.SetActive(true);
            }
        }
    }
}
