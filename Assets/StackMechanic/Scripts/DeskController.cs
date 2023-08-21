using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace StackMechanic.Scripts
{
    public class DeskController : MonoBehaviour
    {
        [SerializeField] private List<Transform> stackList;
        [SerializeField] private Transform stackHolder;
        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<Stacking>();
            if(player is null) return;
            StartCoroutine(StackMovement(player));
        }

        private void OnTriggerExit(Collider other)
        {
            var player = other.GetComponent<Stacking>();
            if(player is null) return;
            StopCoroutine(StackMovement(player)); 
        }

        private IEnumerator StackMovement(Stacking stack)
        {
            yield return new WaitForSeconds(.1f);
            while (stack.stackList.Count > 1)
            {
                var last = stack.stackList.Last();
                last.enabled = false;
                stack.stackList.Remove(last);
                stackList.Add(last.transform);
                var index = stackList.IndexOf(last.transform);
                last.transform.SetParent(transform);
                last.transform.DOLocalMove(stackList[index - 1].localPosition + (Vector3.up * .4f),
                    .1f).OnComplete(() =>
                {
                    last.DisableCollider();
                });
                yield return new WaitForSeconds(.1f);
            }
        }
    }
}

