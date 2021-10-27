using UnityEngine;
public class GunRecoil : MonoBehaviour {
    public GameObject MiddleScreen;
    public bool addRecoil;
    public int IntensityAngle;
    public float Speed;
    public float prevRotx;
    public bool returnRecoil;
    public float ReturnRecoil;
    public float MiddleScreenRot;
    void Update() {
        if(addRecoil)
            AddRecoil(IntensityAngle,Speed,ReturnRecoil);
        if (returnRecoil) {
            Quaternion newRotation = Quaternion.AngleAxis(0, new Vector3(-1f,0,0));
            MiddleScreen.transform.localRotation = Quaternion.Slerp( MiddleScreen.transform.localRotation, newRotation, Time.deltaTime*ReturnRecoil);
            if (MiddleScreen.transform.localRotation == Quaternion.Euler(0,0,0)) {
                returnRecoil = false;
            }
        }
    
    }
    public void AddRecoil(int _intensityAngle,float _speed,float _returnSpeed) {
        Quaternion newRotation = Quaternion.AngleAxis(_intensityAngle, new Vector3(-1f,0,0));
        MiddleScreen.transform.localRotation = Quaternion.Slerp( MiddleScreen.transform.localRotation, newRotation, Time.deltaTime*_speed);
        if (!addRecoil) {
            MiddleScreenRot = MiddleScreen.transform.localRotation.x;
            ReturnRecoil = _returnSpeed;
            IntensityAngle = _intensityAngle;
            Speed = _speed;
            addRecoil = true;
            prevRotx = Quaternion.Euler(MiddleScreen.transform.localRotation.x,0,0).x;
        } if (MiddleScreen.transform.localRotation == Quaternion.Euler(prevRotx+_intensityAngle*-1f,0,0)) {
            addRecoil = false;
            returnRecoil = true;
        }
    }
}
