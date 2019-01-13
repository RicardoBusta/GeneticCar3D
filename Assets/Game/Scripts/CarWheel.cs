using UnityEngine;

namespace Game.Scripts {
    public class CarWheel : MonoBehaviour {
        public Rigidbody WheelBody;
        public FixedJoint Joint;

        private float direction;

        public void UpdateWheelPosition(bool flip, float rotation, float angle, float radius, float width,
            Rigidbody connectedTo) {
            var a = angle * Mathf.Deg2Rad;

            var y = Mathf.Cos(a) * radius;

            var z = Mathf.Sin(a) * radius;

            direction = flip ? 1 : -1;

            Joint.connectedBody = null;

            var wheelTransform = transform;
            wheelTransform.localPosition = new Vector3(width * direction, y, z);
            wheelTransform.rotation = Quaternion.Euler(rotation, flip ? 0 : 180, 0);

            var wheelRadius = Random.Range(0.5f, 3f);
            WheelBody.transform.localScale = new Vector3(Random.Range(0.5f, 2.0f), wheelRadius, wheelRadius);

            Joint.connectedBody = connectedTo;
        }

        private void Update() {
            WheelBody.AddRelativeTorque(10 * direction, 0, 0);
//            if (Collider.isGrounded) {
//                Collider.motorTorque = 30;
//            }
        }
    }
}