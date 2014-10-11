using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PersonBehaviorScript : MonoBehaviour {
	 	
	private GameObject[] people;
	private List<int> deleted;
	private MicControlC mic;
	int counter;
	int pause_counter;
	int babble_counter;
	
	void Start () {
		people = GameObject.FindGameObjectsWithTag("Audience");
		deleted = new List<int> ();
		mic = GetComponent<MicControlC> ();
		counter = 0;
		pause_counter = 0;
		babble_counter = 0;
	}
		
	void Update () {

		if (counter % 150 == 0) {

			float loud = mic.loudness;

			// too soft
			if (loud < 150.0) {
				reduceAudience ();
				pause_counter++;
			} else {
				pause_counter = 0;
			}

			if (pause_counter == 4) {
				reduceAudience();
				reduceAudience();
			}

			// too loud
			if (loud > 400.0) {
				increaseAudience ();
				increaseAudience ();
			}
			if (loud > 300.0) {
				increaseAudience();
				increaseAudience();
				babble_counter++;
			} else {
				babble_counter = 0;
			}
			if (loud > 200.0) {
				increaseAudience();
				increaseAudience();	
			}

			if (babble_counter == 8) {
				reduceAudience ();
				reduceAudience ();
			}

		}

		counter++;
	}

	void reduceAudience () {
		if (deleted.Count < people.Length ) {
			int decreaseHere = Random.Range (0, people.Length);
			while (deleted.Contains (decreaseHere)) {
				decreaseHere = Random.Range (0, people.Length);
			}
			people[decreaseHere].animation.Play();
			people[decreaseHere].GetComponent<MoveScript>().speed = 2f;
			//people [decreaseHere].SetActive (false);
			deleted.Add (decreaseHere);
		}
	}

	void increaseAudience () {

		int index = Random.Range (0, deleted.Count);
		if (deleted.Count == 0)
						return;
		int increaseHere = deleted[index];
		people[increaseHere].SetActive(true);
		people [increaseHere].GetComponent<MoveScript> ().speed = 0f;
		deleted.RemoveAt (index);
	}
}