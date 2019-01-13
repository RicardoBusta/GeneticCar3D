using UnityEngine;

namespace Game.Scripts {
    public class CarGenerator : MonoBehaviour {
        public CarPart CarPartPrefab;
        public CarWheel CarWheelPrefab;
        public Rigidbody CarCoreRigidbody;

        private CarPart[] CarParts;
        private CarWheel[] CarWheels;

        private float[] angles;
        private float[] radius;

        private void Start() {
            CarParts = new CarPart[16];

            CarWheels = new CarWheel[16];

            for (var i = 0; i < 16; i++) {
                CarParts[i] = Instantiate(CarPartPrefab, transform);
                CarWheels[i] = Instantiate(CarWheelPrefab, transform);
            }

            angles = new float[8];

            var totalWeight = 0.0f;
            var weights = new float[8];
            radius = new float[8];
            for (var i = 0; i < 8; i++) {
                weights[i] = Random.Range(1.0f,10.0f);
                totalWeight += weights[i];
                radius[i] = Random.Range(0.0f, 2.0f);
            }

            var totalAngles = 0.0f;
            for (var i = 0; i < 8; i++) {
                angles[i] = totalAngles+(weights[i]/totalWeight)*360;
                totalAngles = angles[i];
            }

            GenerateCar();
        }

        public void GenerateCar() {
            CarCoreRigidbody.position = transform.position;
            for (var i = 0; i < 8; i++) {
                var angle1 = angles[i];
                var angle2 = angles[(i + 1) % 8];

                var rad1 = radius[i];
                var rad2 = radius[(i + 1) % 8];

                const int carWidth = 1;

                CarParts[i].Joint.connectedBody = null;
                CarParts[i].UpdateCarShape(false, angle1, angle2, rad1, rad2, carWidth, carWidth, carWidth*1.5f);
                CarParts[i].Joint.connectedBody = CarCoreRigidbody;
                CarParts[i + 8].Joint.connectedBody = null;
                CarParts[i + 8].UpdateCarShape(true, angle1, angle2, rad1, rad2, carWidth, carWidth, carWidth*1.5f);
                CarParts[i + 8].Joint.connectedBody = CarCoreRigidbody;

                CarWheels[i].UpdateWheelPosition(false, angle1+180, angle1, rad1, carWidth, CarParts[i].Body);
                CarWheels[i + 8].UpdateWheelPosition(true, angle1+180, angle1, rad1, carWidth, CarParts[i + 8].Body);
            }
        }
    }
}