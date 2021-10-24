using System;
using UnityEngine;
public class ShootingGun : MonoBehaviour {
    public Inventory inventory = new Inventory();
    public InventoryDisplay inventoryDisplay = new InventoryDisplay();
    public float FireActivation = .1f;
    public float TimeBeforeShoot;
    public float TimeBeforeShoot_Bullet;
    public int PrevSlot;
    public int CurrentSlot;
    public GameObject MiddleScreen;
    public int loop;
    public bool reload = false;
    
    public float reloadTime;
    public int ReserveMags;
    public int bulletsPerMag;
    public float max_distance;
    public int FireRate;
    public int CurrentReserveMagsUsed;
    public int BulletsShot;
    
    //TODO: add more for more guns
    public int[] SBV_28_Mags; //SBV_28_Mags[0] = Bullets Shot, SBV_28_Mags[1] Reserve Mags Used
    private void Start() {
        SBV_28_Mags[1] = 0;
        SBV_28_Mags[0] = 0;
    }
    void Update() {
        CurrentSlot = inventoryDisplay.CurrentSlot;
        TimeBeforeShoot += Time.deltaTime;
        TimeBeforeShoot_Bullet += Time.deltaTime;
        if (reload) {
            if (PrevSlot != CurrentSlot) {
                //changed slots
                TimeBeforeShoot = 0f;
                loop = 0;
            }
        } if (loop >= 1){
            if (TimeBeforeShoot >= reloadTime && SBV_28_Mags[1] != ReserveMags) {
                SBV_28_Mags[1]++;
                SBV_28_Mags[0] = 0;
                loop = 0;
            } else {
                if (TimeBeforeShoot < 3f) {
                    reload = true;
                }
            }
        } if (Input.GetKeyDown(KeyCode.R)&&loop==0) {
            if(loop == 0){TimeBeforeShoot = 0f;loop++;}
        } if(Input.GetAxis("Fire1") >= FireActivation) {
            PrevSlot = inventoryDisplay.CurrentSlot;
            switch (inventory.InvArr[inventoryDisplay.CurrentSlot,1]) {//TODO: add more cases for more guns
                case (2): {//SBV-28
                    SBV_28();
                    break;
                }
            }
        }
    }
    public int SBV_28() {//TODO: add more functions for more guns
        CurrentReserveMagsUsed = SBV_28_Mags[1];
        BulletsShot = SBV_28_Mags[0];
        bulletsPerMag = 5;//how many bullets are in the mag
        ReserveMags = 5;//Reserve Mags
        max_distance = 20f;//max bullet distance
        reloadTime = 4f;//how long in seconds it takes to reload
        FireRate = 1;//FireRate in seconds
        if (SBV_28_Mags[1] >= ReserveMags && SBV_28_Mags[0] >= bulletsPerMag) {
            //out of amo
        } else {
            if (TimeBeforeShoot_Bullet >= FireRate){
                TimeBeforeShoot_Bullet = 0;
                if (SBV_28_Mags[0] < bulletsPerMag){
                    SBV_28_Mags[0]++;
                    RaycastHit hit;
                    int layerMask = 1 << 8;//This would cast rays only against colliders in layer 8
                    layerMask = ~layerMask;
                    if (Physics.Raycast(MiddleScreen.transform.position, MiddleScreen.transform.TransformDirection(Vector3.forward), out hit, max_distance, layerMask)) {
                        Debug.DrawRay(MiddleScreen.transform.position, MiddleScreen.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                        print("hit");
                        //TODO: health code here
                    } else {
                        Debug.DrawRay(MiddleScreen.transform.position, MiddleScreen.transform.TransformDirection(Vector3.forward) * hit.distance, Color.gray);
                        print("miss");
                    }
                }
            }
        }
        return 1;
    }
}