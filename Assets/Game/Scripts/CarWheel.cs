using UnityEngine;

namespace Game.Scripts {
    public class CarWheel : MonoBehaviour {
        public Rigidbody WheelBody;
        public FixedJoint Joint;

        private float direction;

        public void UpdateWheelPosition(bool flip, float wheelWidth, float wheelRadius, float wheelRotation,
            float axleAngle, float axleRadius, float axleWidth,
            Rigidbody connectedTo) {
            var a = axleAngle * Mathf.Deg2Rad;

            var y = Mathf.Cos(a) * axleRadius;

            var z = Mathf.Sin(a) * axleRadius;

            direction = flip ? 1 : -1;

            Joint.connectedBody = null;

            var wheelTransform = transform;
            wheelTransform.localPosition = new Vector3(axleWidth * direction, y, z);
            wheelTransform.rotation = Quaternion.Euler(wheelRotation, 0, 0);

            WheelBody.transform.localScale = new Vector3(wheelWidth * direction, wheelRadius, wheelRadius);
            WheelBody.maxAngularVelocity = 100;

            Joint.connectedBody = connectedTo;
        }

        private void Update() {
            WheelBody.AddRelativeTorque(10, 0, 0);
//            if (Collider.isGrounded) {
//                Collider.motorTorque = 30;
//            }
        }
    }
}