using System;
using UnityEngine;
using UnityEngine.UI;
public class GunDisplay : MonoBehaviour {
    public ShootingGun GunScript = new ShootingGun();
    public Text amoText;
    void Update() {
        if (GunScript.reload) {
            amoText.text = GunScript.GunName + "\n" + "...";
        } else {
            string mags = (GunScript.ReserveMags - GunScript.CurrentReserveMagsUsed).ToString();
            string bullets = (GunScript.bulletsPerMag - GunScript.BulletsShot).ToString();
            amoText.text = GunScript.GunName + "\n" + bullets + "/" + mags;
        }
    }
}
