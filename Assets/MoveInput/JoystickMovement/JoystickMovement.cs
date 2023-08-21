using UnityEngine;

namespace MoveInput.JoystickMovement
{
    public class JoystickMovement : MonoBehaviour
    { 
        [Header("References")]
        [SerializeField] private DynamicJoystick dynamicJoystick;
        [SerializeField] private Rigidbody rb;
        
        [Header("Movement")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private bool moveRigidbody;

        private Vector3 _direction;

        private void FixedUpdate()
        {
            if(!moveRigidbody) return;
            _direction = new Vector3(dynamicJoystick.Horizontal * moveSpeed,
                rb.velocity.y, dynamicJoystick.Vertical * moveSpeed);
            rb.velocity = _direction;
            if(dynamicJoystick.Horizontal != 0 || dynamicJoystick.Vertical != 0)
                transform.rotation = Quaternion.
                    LookRotation(new Vector3(dynamicJoystick.Horizontal, 0, dynamicJoystick.Vertical));
        }

        private void Update()
        {
            if(moveRigidbody) return;
            if(dynamicJoystick.Horizontal == 0 && dynamicJoystick.Vertical == 0) return;
            transform.rotation = Quaternion.
                    LookRotation(new Vector3(dynamicJoystick.Horizontal, 0, dynamicJoystick.Vertical));
            _direction = Vector3.forward * moveSpeed;
            transform.Translate(_direction * Time.deltaTime);
            

        }
    }
}
