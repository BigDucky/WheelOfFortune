using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelContent : MonoBehaviour {


    public GameObject piece;
    public Settings settings;

    private Transform uiCanvas;
    private Transform wheelBackground;
    private float amount;
    private float size;

    private float degree;

	void Start () {
        uiCanvas = GameObject.Find("WheelContent").transform;
        wheelBackground = GameObject.Find("WheelBackground").transform;
        amount = settings.amountOfPieces;
        size = settings.size;
        PieceSetup();
        SpawnWheel();
        uiCanvas.transform.position = wheelBackground.transform.position;
	}

    private void SpawnWheel() {
        for (int i = 0; i < amount; i++) {
            degree = (360 / amount);
            Quaternion rotation = Quaternion.Euler(0, 0, degree * i);
            Vector3 position = new Vector3(0, 0, 0);
            GameObject g = Instantiate(piece,position,rotation,uiCanvas);           
            g.gameObject.name = "Piece" + i;
            int randomNumber = RandomRewardGenerator();
            SetPointText(g, randomNumber);
            ChangePieceColor(g, randomNumber);
            g.GetComponent<InfoContainer>().scoreGain = settings.rewards[randomNumber].points;
        }
    }

    private void SetPointText(GameObject g, int i) {
        Transform pointsText = g.transform.GetChild(1);
        pointsText.transform.Rotate(pointsText.localRotation.x, pointsText.localRotation.y, pointsText.localRotation.x - degree / 2);
        pointsText.GetComponent<Text>().text = settings.rewards[i].points +"";
    }

    private int RandomRewardGenerator() {
       int rewardNr =  Random.Range(0, 10);
        return rewardNr;
    }

    private void PieceSetup() {
        piece.GetComponent<Image>().fillAmount = 1/amount ;
        piece.transform.localScale = new Vector3(size, size, size);     
    }

    private void ChangePieceColor(GameObject gameObject, int i) {
        Color color = settings.rewards[i].color;
        gameObject.GetComponent<Image>().color = color;
    }
	
}
