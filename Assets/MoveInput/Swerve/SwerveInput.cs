using UnityEngine;

namespace MoveInput
{
    public class SwerveInput : MonoBehaviour
    {
        [SerializeField] private DynamicJoystick dynamicJoystick;
        [SerializeField] private float speed;
        [SerializeField] private float swerveSpeed;

        private void Update()
        {
            float dirX = 0;
            if (dynamicJoystick.Horizontal != 0)
                dirX += dynamicJoystick.Horizontal * swerveSpeed;
            var direction = new Vector3(dirX, 0, speed);

            transform.Translate(direction * Time.deltaTime);
        }
    }
}
