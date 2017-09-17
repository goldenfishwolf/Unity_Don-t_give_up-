using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Add_button : MonoBehaviour,IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {


	public bool is_atk;


	public StageController sc;
	public Transform def_machine, atk_machine;

	private BattleController bc;
	private AddmachineController ac;
	private DataController dc;
	// Use this for initialization
	void Start () {
		bc = sc.bc;
		ac = sc.ac;
		dc = sc.dc;
		ac.update_text (bc.player_gold);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (gameObject.name == "add") {
			gameObject.GetComponent<Image>().color = Color.black;
		} else if (gameObject.name == "minus") {
			gameObject.GetComponent<Image>().color = Color.black;
		} else if (gameObject.name == "return") {
			gameObject.GetComponent<Image>().color = Color.black;
			gameObject.transform.FindChild("Text").GetComponent<Text>().color = Color.white;
		} else if (gameObject.name == "confirm") {
			gameObject.GetComponent<Image>().color = Color.black;
			gameObject.transform.FindChild("Text").GetComponent<Text>().color = Color.white;
		} else if (gameObject.name == "other") {
			gameObject.GetComponent<Image>().color = Color.black;
			gameObject.transform.FindChild("Text").GetComponent<Text>().color = Color.white;
		}

	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (gameObject.name == "add") {
			gameObject.GetComponent<Image>().color = Color.white;
		} else if (gameObject.name == "minus") {
			gameObject.GetComponent<Image>().color = Color.white;
		} else if (gameObject.name == "return") {
			gameObject.GetComponent<Image>().color = Color.white;
			gameObject.transform.FindChild("Text").GetComponent<Text>().color = Color.black;
		} else if (gameObject.name == "confirm") {
			gameObject.GetComponent<Image>().color = Color.white;
			gameObject.transform.FindChild("Text").GetComponent<Text>().color = Color.black;
		} else if (gameObject.name == "other") {
			gameObject.GetComponent<Image>().color = Color.white;
			gameObject.transform.FindChild("Text").GetComponent<Text>().color = Color.black;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{//1 point = 10 * player_point gold, that is, if player has added two points before, then the third point cost 30 gold
		if (gameObject.name == "add") {
			ac.add_point (1);
			ac.update_text (bc.player_gold);
		} else if (gameObject.name == "minus") {
			ac.add_point (-1);
			ac.update_text (bc.player_gold);
		} else if (gameObject.name == "return") {
			ac.clear_gold_and_point ();
			StartCoroutine(sc.enter_or_exit_add_point (false));
		} else if (gameObject.name == "confirm") {
			if (bc.add_point (is_atk, 4 * ac.get_point(), ac.get_gold())) {
				ac.add_cost_point (ac.get_point ());
				ac.clear_gold_and_point ();
				ac.update_text (bc.player_gold);
				if (dc.second_alive && !dc.go_again) {
					dc.change_switch (7);
					StartCoroutine (sc.go_out_again ());
				}
			} else {
				ac.cost_text.color = Color.red;
			}
		} else if (gameObject.name == "other") {
			Vector3 tem = def_machine.position;
			def_machine.position = atk_machine.position;
			atk_machine.position = tem;
			ac.clear_gold_and_point ();
			ac.update_text (bc.player_gold);
		}
	}
		





}
