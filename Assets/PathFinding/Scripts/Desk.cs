using UnityEngine;

namespace PathFinding.Scripts
{
    public class Desk : MonoBehaviour
    {
        public bool IsBusy { get; set; }

        private void Awake()
        {
            IsBusy = false;
        }
    }
}
