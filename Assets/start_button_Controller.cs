using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;

public class start_button_Controller : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

	public StageController sc;
	private DataController dc;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("has_played", 0);
		PlayerPrefs.Save ();
		dc = sc.dc;
		if (gameObject.name == "start_game") {
			if (PlayerPrefs.GetInt ("has_played",0) == 0) {
				gameObject.transform.FindChild("Text").GetComponent<Text>().text = "New Game";
			} else {
				gameObject.transform.FindChild("Text").GetComponent<Text>().text = "Return Game";
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (gameObject.name == "start_game") {
			gameObject.GetComponent<Image>().color = Color.black;
			gameObject.transform.FindChild("Text").GetComponent<Text>().color = Color.white;
		} else if (gameObject.name == "end_game") {
			gameObject.GetComponent<Image>().color = Color.black;
			gameObject.transform.FindChild("Text").GetComponent<Text>().color = Color.white;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{

		if (gameObject.name == "start_game") {
			dc.step = 0;
			dc.is_out = false;
			if (PlayerPrefs.GetInt ("has_played",0) == 0) {
				StartCoroutine(sc.new_game_start());
				PlayerPrefs.SetInt ("has_played", 1);
				PlayerPrefs.Save ();
			} else {
				if (dc.first_dead && !dc.second_alive) {
					StartCoroutine(sc.second_alive());
					return;
				}
				if (dc.dead_num == 10) {
					StartCoroutine (sc.tenth_dead ());
					return;
				}
				if (dc.dead_num == 20) {
					StartCoroutine (sc.twentieth_dead ());
					return;
				}
//				if (dc.dead_num == 30) {
//					StartCoroutine (sc.thirtieth_dead ());
//					return;
//				}
				StartCoroutine (sc.return_game_start ());
				print(PlayerPrefs.GetInt ("has_played",0));
			}
		} else if (gameObject.name == "end_game") {
			Application.Quit ();
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (gameObject.name == "start_game") {
			gameObject.GetComponent<Image>().color = Color.white;
			gameObject.transform.FindChild("Text").GetComponent<Text>().color = Color.black;
		} else if (gameObject.name == "end_game") {
			gameObject.GetComponent<Image>().color = Color.white;
			gameObject.transform.FindChild("Text").GetComponent<Text>().color = Color.black;
		}
	}
}
