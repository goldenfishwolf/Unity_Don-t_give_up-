using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Go_button : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {


	public StageController sc;


	private BattleController bc;
	private DataController dc;

	// Use this for initialization
	void Start () {
		bc = sc.bc;
		dc = sc.dc;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (gameObject.name == "Go_button") {
			gameObject.GetComponent<Image>().color = Color.black;
			gameObject.transform.FindChild("Text").GetComponent<Text>().color = Color.white;
		} else if (gameObject.name == "test") {
			gameObject.GetComponent<Image>().color = Color.black;
			gameObject.transform.FindChild("Text").GetComponent<Text>().color = Color.white;
		} else if (gameObject.name == "battle_button") {
			gameObject.GetComponent<Image>().color = Color.black;
			gameObject.transform.FindChild("Text").GetComponent<Text>().color = Color.white;
		} else if (gameObject.name == "add_button") {
			gameObject.GetComponent<Image>().color = Color.black;
			gameObject.transform.FindChild("Text").GetComponent<Text>().color = Color.white;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{

		if (gameObject.name == "Go_button") {
			if (!dc.is_out) {
				dc.change_switch (0);
				gameObject.transform.FindChild ("Text").GetComponent<Text> ().text = "Go";
				sc.add_button_appear (false);
				return;
			}
			dc.add_step (false);
			switch (dc.step) {
			case 1:
				if (dc.first_start && !dc.first_monster) {
					StartCoroutine (sc.first_battle ());
					break;
				}
				bc.battle_start (1);
				break;
			case 5:
				if (dc.first_win && !dc.second_monster) {
					StartCoroutine(sc.second_battle());
					break;
				}
				bc.battle_start (2);
				break;
			case 11:
				bc.battle_start (3);
				break;
			case 13:
				bc.battle_start (4);
				break;
			case 17:
				bc.battle_start (5);
				break;
			case 19:
				bc.battle_start (6);
				break;
			case 23:
				bc.battle_start (7);
				break;
			case 29:
				bc.battle_start (8);
				break;
			case 31:
				bc.battle_start (9);
				break;
			case 37:
				bc.battle_start (10);
				break;
			case 41:
				bc.battle_start (11);
				break;
			}
		} else if (gameObject.name == "test") {
			sc.room_bg.transform.position = sc.start_bg.transform.position;
			sc.start_bg.transform.position = new Vector3(10000,0,0);

			bc.battle_start (0);


		} else if (gameObject.name == "battle_button") {
			if (bc.check_attack_done ()) {
				StartCoroutine(bc.attack());
			}

		} else if (gameObject.name == "add_button") {
			StartCoroutine(sc.enter_or_exit_add_point(true));
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (gameObject.name == "Go_button") {
			gameObject.GetComponent<Image>().color = Color.white;
			gameObject.transform.FindChild("Text").GetComponent<Text>().color = Color.black;
		} else if (gameObject.name == "test") {
			gameObject.GetComponent<Image>().color = Color.white;
			gameObject.transform.FindChild("Text").GetComponent<Text>().color = Color.black;
		} else if (gameObject.name == "battle_button") {
			gameObject.GetComponent<Image>().color = Color.white;
			gameObject.transform.FindChild("Text").GetComponent<Text>().color = Color.black;
		} else if (gameObject.name == "add_button") {
			gameObject.GetComponent<Image>().color = Color.white;
			gameObject.transform.FindChild("Text").GetComponent<Text>().color = Color.black;
		}
	}



}
