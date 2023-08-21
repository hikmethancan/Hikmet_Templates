using System.Collections.Generic;
using Deneme.Scripts;
using UnityEngine;

namespace StackMechanic.Scripts
{
    public class Stacking : SingletonObjects<Stacking>
    {
        public Vector3 offset;
        public Transform stackHolderPos;
        public List<StackingObjController> stackList = new List<StackingObjController>();

        private const string Stack = "Stack";

        private void OnTriggerEnter(Collider other)
        {
            var stackable = other.GetComponent<IStackable>();
            if (stackable != null)
            {
                stackable.AddStack();
            }
        }
    }
}
