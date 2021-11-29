using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
public class GunDisplay : MonoBehaviour {
    public ShootingGun GunScript = new ShootingGun();
    public Text amoText;
    public GameObject SBV_28;
    public Inventory inv = new Inventory();
    public InventoryDisplay invDisp = new InventoryDisplay();
    public Transform GunHolder;
    private GameObject Spawned;
    private int count;
    private GameObject Mag;
    public GameObject Empty;
    void Update() {
        if (GunScript.reload) {
            count++;
            //all guns need to have the mag named "Mag"
            if (count == 1) {
                //play reload animation
                Mag = Spawned.gameObject.transform.Find("Mag").gameObject;
                Destroy(Mag);
            }
            amoText.text = GunScript.GunName + "\n" + "...";
        } else {
            if (count > 0) {
                //finish animation
                GameObject SpawnedMag = Instantiate(SBV_28.gameObject.transform.Find("Mag").gameObject, Spawned.transform);
                SpawnedMag.name = "Mag";
                //SpawnedMag.transform.localPosition = new Vector3(0,-.2f,0);
                //SpawnedMag.transform.localEulerAngles = new Vector3(0,180,0);
            }
            count = 0;
            string mags = (GunScript.ReserveMags - GunScript.CurrentReserveMagsUsed).ToString();
            string bullets = (GunScript.bulletsPerMag - GunScript.BulletsShot).ToString();
            amoText.text = GunScript.GunName + "\n" + bullets + "/" + mags;
        }

        switch (inv.InvArr[invDisp.CurrentSlot, 1]) {//TODO: add more cases for more Guns
            case(2): {
                if (Spawned.name != "id_2"){
                    Destroy(Spawned);
                    Spawned = Instantiate(SBV_28, GunHolder);
                    Spawned.name = "id_2";
                    Spawned.transform.localPosition = new Vector3(0,-.2f,0);
                    Spawned.transform.localEulerAngles = new Vector3(0,180,0);
                }
                break;
            }
            default: {
                Destroy(Spawned);
                Spawned = Empty;
                Spawned.name = "none";
                break;
            }
        }
    }
}