using UnityEngine;

namespace Game.Scripts {
    public class CarWheel : MonoBehaviour {
        public WheelCollider Collider;
        public MeshRenderer Visual;
        public FixedJoint Joint;

        public void UpdateWheelPosition(bool flip, float rotation, float angle, float radius, float width,
            Rigidbody connectedTo) {
            var a = angle * Mathf.Deg2Rad;

            var y = Mathf.Cos(a) * radius;

            var z = Mathf.Sin(a) * radius;

            var flipDirection = flip ? -1 : 1;

            Joint.connectedBody = null;

            var wheelTransform = transform;
            wheelTransform.localPosition = new Vector3(-width * flipDirection, y, z);
            wheelTransform.rotation = Quaternion.Euler(rotation, 0, 0);
            wheelTransform.localScale = new Vector3(flipDirection, 1, 1);

            Joint.connectedBody = connectedTo;
        }

        private void Update() {
            Quaternion quat;
            Vector3 pose;
            Collider.GetWorldPose(out pose, out quat);

            var visualTransform = Visual.transform;
            visualTransform.rotation = quat;
            visualTransform.position = pose;

            if (Collider.isGrounded) {
                Collider.motorTorque = 30;
            }
        }
    }
}