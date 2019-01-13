using UnityEngine;

namespace Game.Scripts {
    public class CarGenerator : MonoBehaviour {
        public CarPart CarPartPrefab;
        public CarWheel CarWheelPrefab;
        public Rigidbody CarCoreRigidbody;

        private CarPart[] CarParts;
        private CarWheel[] CarWheels;

        private float[] angles;

        private void Start() {
            CarParts = new CarPart[16];

            CarWheels = new CarWheel[16];

            for (var i = 0; i < 16; i++) {
                CarParts[i] = Instantiate(CarPartPrefab, transform);
                CarWheels[i] = Instantiate(CarWheelPrefab, transform);
            }

            angles = new float[8];

            for (var i = 0; i < 8; i++) {
                angles[i] = i * 45;
            }

            GenerateCar();
        }

        public void GenerateCar() {
            for (var i = 0; i < 8; i++) {
                var angle1 = angles[i];
                var angle2 = angles[(i + 1) % 8];

                CarParts[i].Joint.connectedBody = null;
                CarParts[i].UpdateCarShape(false, angle1, angle2, 1, 1, 0.5f, 0.5f, 1);
                CarParts[i].Joint.connectedBody = CarCoreRigidbody;
                CarParts[i + 8].Joint.connectedBody = null;
                CarParts[i + 8].UpdateCarShape(true, angle1, angle2, 1, 1, 0.5f, 0.5f, 1);
                CarParts[i + 8].Joint.connectedBody = CarCoreRigidbody;

                CarWheels[i].UpdateWheelPosition(false, angle1+180, angle1, 1, 0.5f, CarParts[i].Body);
                CarWheels[i + 8].UpdateWheelPosition(true, angle1+180, angle1, 1, 0.5f, CarParts[i + 8].Body);
            }
        }
    }
}