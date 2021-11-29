using UnityEngine;
using XInputDotNetPure;
public class Controllers : MonoBehaviour {
    // Update is called once per frame
    public bool playerIndexSet = false;
    public PlayerIndex playerIndex;
    public GamePadState state;
    public GamePadState prevState;
    public int RumbleDuration;
    public bool rumble;
    public float Time;
    void Update() {
        if (rumble) {
            Time += UnityEngine.Time.deltaTime;
        } if (Time >= RumbleDuration) {
            GamePad.SetVibration(playerIndex, 0, 0);
            rumble = false;
        }
        // Find a PlayerIndex, for a single player game
        // Will find the first controller that is connected ans use it
        if (!playerIndexSet || !prevState.IsConnected) {
            for (int i = 0; i < 4; ++i) {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected) {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }
    } public void Rumble(int rumbleDuration,int leftMotor,int rightMotor) {
        Time = 0f;
        RumbleDuration = rumbleDuration;
        GamePad.SetVibration(playerIndex, leftMotor, rightMotor);
        rumble = true;
    }
}
