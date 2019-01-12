using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelVisual : MonoBehaviour
{
    public WheelCollider Wheel;
    public GameObject WheelModel;

    private void Update() {
        Quaternion quat;
        Vector3 pose;
        Wheel.GetWorldPose(out pose, out quat);

        WheelModel.transform.rotation = quat;
        WheelModel.transform.position = pose;
    }
}
