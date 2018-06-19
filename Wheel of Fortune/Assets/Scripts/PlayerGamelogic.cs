using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGamelogic : MonoBehaviour {

    GameObject wheel;
    public Settings settings;

    public bool spinning;
    private int wheelDrag;
    private float deceleration;
    private float spinSpeed;

    public static int score;
    public static int scoreGained;

    private void Start() {
        wheel = GameObject.Find("WheelContent");
        spinSpeed = settings.spinSpeed;
        deceleration = settings.delecerationPerSecond;
        wheelDrag = settings.playerRotateSpeed;
    }

    void Update () {
        if (Input.GetMouseButton(0)) {
            if (Input.GetAxis("Mouse X") > 3) {
                spinning = true;
            }
            else {
                RotateWheel();
            }
        }
        if (spinning) {
            SpinWheel();
        }
    }

    void RotateWheel() {
        if (!spinning) {
            float rotation = Input.GetAxis("Mouse X") * wheelDrag;
            wheel.transform.Rotate(0, 0, -rotation);
        }
    }

    void SpinWheel() {
        if(spinSpeed == 0) {
            spinning = false;
            spinSpeed = settings.spinSpeed;
            Invoke("UpdateText", 1.5f);
            
        }
        while(spinSpeed > 0) {
            wheel.transform.Rotate(0, 0, (-spinSpeed * Time.deltaTime));
            spinSpeed = spinSpeed - deceleration;
            break;
        }
    }

    void UpdateText() {
        UiManager.instance.ChangeText(UiManager.instance.gainedScoreText, "" + ColissionA.instance.GetScore());
        score += ColissionA.instance.GetScore();
        UiManager.instance.ChangeText(UiManager.instance.totalScoreText, "" + score);
    }
}
