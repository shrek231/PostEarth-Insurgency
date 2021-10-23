using UnityEngine;
public class DropItem : MonoBehaviour {
    public Inventory inventory = new Inventory();
    public InventoryDisplay inventoryDisplay = new InventoryDisplay();
    public GameObject ID_1;
    void Update() {
        if (Input.GetKey(KeyCode.Q)) {
            Drop();
        }
    }
    public void Drop() {
        int droped_item = inventory.InvArr[inventoryDisplay.CurrentSlot, 1];
        inventory.InvArr[inventoryDisplay.CurrentSlot, 1] = 0; //no item
        switch (droped_item) {
            case (1): {
                GameObject Droped_Item = Instantiate(ID_1, transform.position, Quaternion.identity);
                Droped_Item.name = "id:1";
                Droped_Item.transform.eulerAngles = new Vector3(-90,0,0);
                break;
            }
        }
    }
}
