using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {
    public Text totalScoreText;
    public Text gainedScoreText;
    public static UiManager instance;

    private void Start() {
        instance = this;

        ChangeText(totalScoreText, "0");
        ChangeText(gainedScoreText, "0");
    }

    public void ChangeText(Text toBeChanged, string Text){

        toBeChanged.GetComponent<Text>().text = Text;
    }

}
