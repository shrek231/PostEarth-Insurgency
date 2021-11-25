using System;
using CMF;
using UnityEngine;
public class GunRecoil : MonoBehaviour {
    public float Target;
    public bool shoot;
    public int IntensityAngle;
    public float Speed;
    public CameraController camCon = new CameraController();
    public void AddRecoil(int _intensityAngle,int _speed) {
        Target += _intensityAngle;
        shoot = true;
        Speed = _speed;
        
        //CamControlls.transform.Rotate(_intensityAngle*-1, CamControlls.transform.localRotation.y, CamControlls.transform.localRotation.z, Space.Self);
    }
    public void Update() {
        if (shoot) {
            camCon.currentXAngle += Speed * Time.deltaTime*-1;
            Target -= Speed * Time.deltaTime;
            if (Target <= 0) {
                shoot = false;
                Target = 0;
            }
        }
    }
}
