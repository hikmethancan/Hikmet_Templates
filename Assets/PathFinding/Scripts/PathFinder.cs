using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace PathFinding.Scripts
{
    public class PathFinder : MonoBehaviour
    {
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            var target = DeskManager.Instance.deskList.OrderBy(num => num.IsBusy = false).First();
            if(!target.IsBusy)
                _agent.SetDestination(target.transform.position);    
            target.IsBusy = true;
            
            
        }
    }
}
