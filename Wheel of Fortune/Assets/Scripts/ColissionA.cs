using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColissionA : MonoBehaviour {

    public string firstObject;
    public string lastObject;

    private GameObject currentObject;

    public static ColissionA instance;

    private void Start() {
        instance = this;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        firstObject = collision.transform.parent.name;
        currentObject = collision.collider.gameObject;
        if(firstObject != lastObject) {
            SoundManager.instance.PlaySound(0);
            lastObject = firstObject;
        }
    }

    public int GetScore() {
        if(currentObject != null) {
            int score = currentObject.transform.parent.GetComponent<InfoContainer>().scoreGain;
            return score;
        }
        else {
            int score = 0;
            return score;
        }

    }

}
