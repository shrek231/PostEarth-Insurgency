using UnityEngine;
public class PickUpItem : MonoBehaviour {
    public DropItem dropitem = new DropItem();
    public Inventory inventory = new Inventory();
    public InventoryDisplay inventoryDisplay = new InventoryDisplay();
    void OnTriggerStay(Collider other) {
        if (other.CompareTag("Object")) {
            if (Input.GetKey(KeyCode.E)) {
                if (inventory.InvArr[inventoryDisplay.CurrentSlot, 1] == 0) {
                    PickUp(other);
                } else {
                    dropitem.Drop();//drop current item
                    PickUp(other);//pickup item on ground
                }
            }
        }
    }
    public void PickUp(Collider other) {
        inventory.InvArr[inventoryDisplay.CurrentSlot, 1] = int.Parse(other.name.Split('_')[1]); //item must have the id as the name, example: id:2
        Destroy(other.gameObject);
    }
}