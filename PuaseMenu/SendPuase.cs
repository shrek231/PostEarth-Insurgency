using System;
using UnityEngine;
public class SendPuase : MonoBehaviour {
    public Puase puase;
    public void UnPuase() {
        puase = GameObject.Find("FirstPersonWalker").GetComponent<Puase>();
        puase.Return();
    }
}
