using UnityEngine;
public class ShootingGun : MonoBehaviour {
    public Inventory inventory = new Inventory();
    public InventoryDisplay inventoryDisplay = new InventoryDisplay();
    public float FireActivation = .1f;
    public float TimeBeforeShoot;
    public float TimeBeforeShoot_Bullet;
    public bool reloading;
    public int PrevSlot;
    public int CurrentSlot;
    public GameObject MiddleScreen;
    public int BulletsShot;
    public int loop;
    public bool reload = false;
    void Start() {
    }
    void Update() {
        CurrentSlot = inventoryDisplay.CurrentSlot;
        TimeBeforeShoot += Time.deltaTime;
        TimeBeforeShoot_Bullet += Time.deltaTime;
        if (reloading) {
            if (PrevSlot != CurrentSlot) {
                //changed slots
                TimeBeforeShoot = 0f;
                BulletsShot = 0;
                loop = 0;
            }
        } if (Input.GetKey(KeyCode.R)) {
            loop++;
            if(loop == 1){TimeBeforeShoot = 0f;}
            if (TimeBeforeShoot >= 5f) {//how long in seconds it takes to reload TODO: somehow get this value form the current gun that you are holding
                BulletsShot = 0;
                loop = 0;
            } else {
                if (TimeBeforeShoot < 3f) {
                    reload = true;
                }
            }
        } if(Input.GetAxis("Fire1") >= FireActivation) {
            PrevSlot = inventoryDisplay.CurrentSlot;
            switch (inventory.InvArr[inventoryDisplay.CurrentSlot,1]) {//TODO: add more cases for more guns
                case (2): {//SBV-28
                    reloading = SBV_28();
                    break;
                }
            }
        }
    }
    public bool SBV_28() {//TODO: add more functions for more guns
        if (TimeBeforeShoot_Bullet >= 3f){//how long in seconds it takes to shoot 1 bullet
            TimeBeforeShoot_Bullet = 0;
            if (BulletsShot < 5){//how many bullets are in the mag
                BulletsShot++;
                RaycastHit hit;
                int layerMask = 1 << 8;
                layerMask = ~layerMask;
                if (Physics.Raycast(MiddleScreen.transform.position, MiddleScreen.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask)) {
                    Debug.DrawRay(MiddleScreen.transform.position, MiddleScreen.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    //TODO: health code here
                } else {
                    Debug.DrawRay(MiddleScreen.transform.position, MiddleScreen.transform.TransformDirection(Vector3.forward) * hit.distance, Color.gray);
                }
            }
        }
        return reload;
    }
}