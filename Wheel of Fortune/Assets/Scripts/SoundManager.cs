using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public List<AudioClip> totalSounds;

    public static SoundManager instance;

	// Use this for initialization
	void Start () {
        instance = this;
	}
	
    public void PlaySound(int soundID) {

        this.GetComponent<AudioSource>().PlayOneShot(totalSounds[soundID]);
    }
}
