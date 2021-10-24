using UnityEngine;
using UnityEngine.UI;
public class InventoryDisplay : MonoBehaviour {
    public Inventory InvScript = new Inventory();
    private int[] SlotBuffer = new int[]{1,0,0,0};
    public int InvCount = 0;
    public int CurrentSlot;
    public Image slot1;
    public Image slot2;
    public Image slot3;
    public Image slot4;
    public Sprite Empty;
    public Sprite ID1;
    public Sprite ID2;
    public Sprite ID3;
    public Sprite ID4;
    void Update() {
        UpdateInv();//update the inv display
        if (InvCount==4) { //split between multiple frames for performance
            InvCount = 0;
        }
        if (InvScript.InvArr[InvCount, 0] == 1) {
            if (SlotBuffer[InvCount] != 1) {//wait untill thares a change to update for performance
                SlotBuffer[0] = 0;
                SlotBuffer[1] = 0;
                SlotBuffer[2] = 0;
                SlotBuffer[3] = 0;
                SlotBuffer[InvCount] = 1;
                CurrentSlot = InvCount;
                //print(CurrentSlot); //current selected slot
                //print(InvScript.InvArr[CurrentSlot,1]); //current selected item id
                Color c = slot1.color;
                c.a = .5f;
                slot1.color = c;
                slot2.color = c;
                slot3.color = c;
                slot4.color = c;
                if (CurrentSlot == 0) {
                    Color _c = slot1.color;
                    _c.a = 1;
                    slot1.color = _c;
                } else {
                    if (CurrentSlot == 1) {
                        Color _c = slot2.color;
                        _c.a = 1;
                        slot2.color = _c;
                    } else {
                        if (CurrentSlot == 2) {
                            Color _c = slot3.color;
                            _c.a = 1;
                            slot3.color = _c;
                        } else {
                            if (CurrentSlot == 3) {
                                Color _c = slot4.color;
                                _c.a = 1;
                                slot4.color = _c;
                            }
                        }
                    }
                }
                UpdateInv();
            }
        }
        InvCount++;
    }
    public void UpdateInv() {
        Sprite SelectedId = Empty;
        switch (InvScript.InvArr[CurrentSlot,1]) {//TODO: add more cases for more items
            case (0):{
                SelectedId = Empty;
                break;
            }case (1): {
                SelectedId = ID1;//key
                break;
            }case (2): {
                SelectedId = ID2;//gun
                break;
            }case (3): {
                SelectedId = ID3;
                break;
            }case (4): {
                SelectedId = ID4;
                break;
            }
        } switch (CurrentSlot) {
            case (0): {
                slot1.GetComponent<Image>().sprite = SelectedId;
                break;
            }case (1): {
                slot2.GetComponent<Image>().sprite = SelectedId;
                break;
            }case (2): {
                slot3.GetComponent<Image>().sprite = SelectedId;
                break;
            }case (3): {
                slot4.GetComponent<Image>().sprite = SelectedId;
                break;
            }
        }
    }
}