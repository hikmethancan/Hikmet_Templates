using System;
using DG.Tweening;
using UnityEngine;

namespace StackMechanic.Scripts
{
    public class StackingObjController : MonoBehaviour, IStackable
    {
        public float followSpeed = 20f;
        public float followDistanceY = .4f;

        private Collider _collider;
        public bool IsStacked { get; set; }

        private int _index;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        private void Update()
        {
            if (!IsStacked) return;

            var movePos = Stacking.Instance.stackList[_index - 1].transform
                .position + (Vector3.up * .4f);
            var moveRot = Stacking.Instance.stackList[_index - 1].transform.rotation;
            transform.position = Vector3.Lerp(transform.position, movePos, followSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, moveRot, followSpeed * Time.deltaTime);
        }

        public void DisableCollider()
        {
            _collider.enabled = false;
        }
        public void AddStack()
        {
            Stacking.Instance.stackList.Add(this);
            // transform.SetParent(Stacking.Instance.transform);
            _index = Stacking.Instance.stackList.IndexOf(this);
            var nextPos = Stacking.Instance.stackList[_index - 1].transform.position + (Vector3.up * .4f);
            transform.DOJump(nextPos, 1, 1, .2f).OnComplete(() =>
            {
                IsStacked = true;
            });
        }

        public void RemoveStack()
        {
            IsStacked = false;
            Stacking.Instance.stackList.Remove(this);
        }
    }
}