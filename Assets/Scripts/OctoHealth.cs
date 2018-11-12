using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class OctoHealth : MonoBehaviour {

	int health;
	GameObject player;
	GameObject pauseText;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		health = 3;
		player = GameObject.Find("Character");
		pauseText = GameObject.Find("pausetext");
		hidePaused (pauseText);
	}

	// Update is called once per frame
	void Update () {
		if (player.transform.position.y <= (float)-8.6)
		{
			// move back to zero location
			//player.transform.position = new Vector3((float)-5.11, (float)2.36, (float)0);
			Application.LoadLevel(Application.loadedLevel);
		}

		if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused(pauseText);
			} else if (Time.timeScale == 0){
				Time.timeScale = 1;
				hidePaused(pauseText);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "HorseEnemy"){
			if (health == 3) {
				DestroyObject (GameObject.Find ("healthfull"));
				health--;
			} else if (health == 2) {
				DestroyObject (GameObject.Find ("healthmid"));
				health--;
			} else if (health == 1) {
				DestroyObject (GameObject.Find ("healthlow"));
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if(coll.gameObject.tag == "winner") {
			DestroyObject(GameObject.Find("pullrequestsucc"));
			Application.LoadLevel ("Menu");
		}
	}

	void showPaused(GameObject g){
		g.SetActive (true);
	}

	void hidePaused(GameObject g){
		g.SetActive (false);
	}
}
