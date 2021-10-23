using UnityEngine;
public class Inventory : MonoBehaviour {
    public int[,] InvArr = new int[,]{{1,1},{0,2},{0,3},{0,4}};
    void Start() {
        /*
        print(InvArr[0,1]); //item ids
        print(InvArr[1,1]);
        print(InvArr[2,1]);
        print(InvArr[3,1]);
        
        print(InvArr[0,0]); //item Selected
        print(InvArr[1,0]);
        print(InvArr[2,0]);
        print(InvArr[3,0]);
        */
    }
    void Update() {
        if (Input.GetKey(KeyCode.Alpha1)) {
            int _count = 0;
            while (_count <= 3) {
                if (InvArr[_count, 0] == 1) {
                    InvArr[_count, 0] = 0;
                }
                _count++;
            }
            InvArr[0, 0] = 1;
        } else {
            if (Input.GetKey(KeyCode.Alpha2)) {
                int _count = 0;
                while (_count <= 3) {
                    if (InvArr[_count, 0] == 1) {
                        InvArr[_count, 0] = 0;
                    }
                    _count++;
                }
                InvArr[1, 0] = 1;
            } else {
                if (Input.GetKey(KeyCode.Alpha3)) {
                    int _count = 0;
                    while (_count <= 3) {
                        if (InvArr[_count, 0] == 1) {
                            InvArr[_count, 0] = 0;
                        }
                        _count++;
                    }
                    InvArr[2, 0] = 1;
                } else {
                    if (Input.GetKey(KeyCode.Alpha4)) {
                        int _count = 0;
                        while (_count <= 3) {
                            if (InvArr[_count, 0] == 1) {
                                InvArr[_count, 0] = 0;
                            }
                            _count++;
                        }
                        InvArr[3, 0] = 1;
                    }
                }
            }
        }
    }
}