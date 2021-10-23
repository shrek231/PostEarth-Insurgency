using CMF;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class Puase : MonoBehaviour {
    public Canvas mainCanvas;
    public MouseCursorLock mcs = new MouseCursorLock();
    public EventSystem mainEventSystem;
    private bool Puased;
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && Puased == false) {
            Puased = true;
            mainCanvas.enabled = false;
            //mainEventSystem.enabled = false;
            mcs.enabled = false;
            SceneManager.LoadScene("PuaseMenu", LoadSceneMode.Additive);
        } else {
            if (Input.GetKeyDown(KeyCode.Escape) && Puased == true) {
                Return();
            }
        }
    }
    public void Return() {
        SceneManager.UnloadSceneAsync("PuaseMenu");
        //mainEventSystem.enabled = true;
        mainCanvas.enabled = true;
        mcs.enabled = true;
        Puased = false;
    }
}
