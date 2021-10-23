using UnityEngine;

public class ShootingGun : MonoBehaviour {
    public Inventory inventory = new Inventory();
    public InventoryDisplay inventoryDisplay = new InventoryDisplay();
    public float FireActivation = .1f;
    public float TimeBeforeShoot;
    public bool reloading;
    public int PrevSlot;
    public int CurrentSlot;
    public GameObject MiddleScreen;
    void Start() {
    }
    void Update() {
        CurrentSlot = inventoryDisplay.CurrentSlot;//1
        TimeBeforeShoot += Time.deltaTime;
        if(Input.GetAxis("Fire1") >= FireActivation) {
            if (reloading) {
                if (PrevSlot != CurrentSlot) {
                    //changed slots
                    TimeBeforeShoot = 0f;
                }
            }
            PrevSlot = inventoryDisplay.CurrentSlot;//1
            switch (inventory.InvArr[inventoryDisplay.CurrentSlot,1]) {
                case (2): {//SBV-28
                    reloading = SBV_28(TimeBeforeShoot);
                    break;
                }
            }
        }
    }
    public bool SBV_28(float timeBeforeShoot) {
        bool reload = false;
        if (timeBeforeShoot >= 3f) {//how long in seconds it takes to shoot 1 bullet
            RaycastHit hit;
            int layerMask = 1 << 8;
            layerMask = ~layerMask;
            if (Physics.Raycast(MiddleScreen.transform.position, MiddleScreen.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask)) {
                Debug.DrawRay(MiddleScreen.transform.position, MiddleScreen.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                //TODO: health code here
            }
            TimeBeforeShoot = 0;
        } else {
            if (timeBeforeShoot < 3f) {
                reload = true;
            }
        }
        return reload;
    }
}
