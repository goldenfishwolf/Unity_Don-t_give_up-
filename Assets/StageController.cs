using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageController : MonoBehaviour {

	public Image start_bg;
	public Image room_bg;
	public Image transport;
	public Text[] roll_text;
	public BattleController bc;
	public DataController dc;
	public AddmachineController ac;
	public Transform player_image;
	public Transform start_button;
	public Transform button;
	public Transform player_thing;
	public Transform add_point_button;
	public Transform go_button;
	public Transform add_point;
	public GameObject return_button;


	public Vector3 standard_pos;
	public Vector3 not_use_pos;

	// Use this for initialization
	void Start () {
		go_button.FindChild ("Text").GetComponent<Text> ().text = "Open Door";
		go_button.gameObject.SetActive (false);
		dc = GameObject.Find ("Main Camera").GetComponent<DataController>();
		not_use_pos = new Vector3 (10000, 0, 0);
		standard_pos = transport.transform.position;
		transport.color = new Color (1, 1, 1, 0);
		//roll_text.text = "";
		transport.transform.position = not_use_pos;
		player_thing.position = not_use_pos;
		add_point_button.position = not_use_pos;
		add_point.position = not_use_pos;
		return_button.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		;
	}

	public IEnumerator battle_end(int gold)
	{
		transport.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (0.5f, 0.03f, 0.06f));
		roll_text [0].text = "獲得 "+ gold + " 金錢";
		for (float i = 0f; i < 1.0f; i += 0.05f) {
			roll_text [0].color = new Color (1, 1, 1, i);
			yield return new WaitForSeconds (0.03f);
		}
		yield return new WaitForSeconds (1.5f);
		for (float i = 1.0f; i > 0f; i -= 0.05f) {
			roll_text [0].color = new Color (1, 1, 1, i);
			yield return new WaitForSeconds (0.03f);
		}
		yield return StartCoroutine (change_transport_alpha (0f, 0.015f, 0.06f));
		transport.transform.position = not_use_pos;
	}

	public IEnumerator return_game_start()
	{
		transport.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (1f, 0.03f, 0.06f));

		start_bg.transform.position = not_use_pos;
		room_bg.transform.position = standard_pos;
		room_bg.sprite = Resources.Load ("bg1") as Sprite;
		print("bg1");
		int stage_num = PlayerPrefs.GetInt ("stage_num", 0);
		if (stage_num != 0) {
			bc.battle_start(stage_num);
		}
		yield return StartCoroutine (change_transport_alpha (0f, 0.015f, 0.06f));
		transport.transform.position = not_use_pos;
	}

	public IEnumerator new_game_start()
	{
//		PlayerPrefs.SetInt ("has_played",1);
//		PlayerPrefs.Save ();
		dc.open();
		transport.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (1f, 0.03f, 0.06f));

		start_bg.transform.position = not_use_pos;
		room_bg.transform.position = standard_pos;
		player_image.position = standard_pos;
		room_bg.sprite = Resources.Load ("bg1") as Sprite;
		print("bg1");
		start_button.FindChild("Text").GetComponent<Text>().text = "Return Game";
		yield return StartCoroutine (change_transport_alpha (0.5f, 0.025f, 0.06f));

		yield return StartCoroutine(story_roll_text_word (1));	

		room_bg.sprite = Resources.Load ("bg2") as Sprite;
		print("bg2");
		dc.is_out = true;
		go_button.FindChild ("Text").GetComponent<Text> ().text = "Go";
		yield return StartCoroutine(story_roll_text_word (2));

//		room_bg.sprite = Resources.Load ("bg3") as Sprite;
//		print("bg3");
//
//		yield return StartCoroutine(story_roll_text_word (3));

		yield return StartCoroutine (change_transport_alpha (0f, 0.015f, 0.06f));
		go_button.gameObject.SetActive (true);
		transport.transform.position = not_use_pos;
		dc.change_switch (1);

	}

	public IEnumerator first_battle()
	{
		dc.change_switch (2);
		transport.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (0.5f, 0.015f, 0.06f));

		player_thing.position = standard_pos;
		bc.battle_start (1);
		yield return StartCoroutine (story_roll_text_word (4));
		yield return StartCoroutine (change_transport_alpha (0f, 0.015f, 0.06f));
		transport.transform.position = not_use_pos;
	}

	public IEnumerator first_win()
	{
		dc.change_switch (3);
		transport.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (0.5f, 0.015f, 0.06f));
		yield return StartCoroutine (story_roll_text_word (5));
		yield return StartCoroutine (change_transport_alpha (0f, 0.015f, 0.06f));
		transport.transform.position = not_use_pos;
	}

	public IEnumerator second_battle()
	{
		dc.change_switch (4);
		transport.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (0.5f, 0.015f, 0.06f));
		bc.battle_start (2);
		yield return StartCoroutine (story_roll_text_word (6));
		yield return StartCoroutine (change_transport_alpha (0f, 0.015f, 0.06f));
		transport.transform.position = not_use_pos;
	}

	public IEnumerator first_dead()
	{
		dc.change_switch (5);
		transport.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (0.5f, 0.015f, 0.06f));
		yield return StartCoroutine (story_roll_text_word (7));
		yield return StartCoroutine (player_dead ());

	}

	public IEnumerator second_alive()
	{
		transport.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (1f, 0.015f, 0.06f));
		start_bg.transform.position = not_use_pos;
		room_bg.transform.position = standard_pos;

		room_bg.sprite = Resources.Load ("bg4") as Sprite;



		transport.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (0.5f, 0.025f, 0.06f));
		transport.transform.position = standard_pos;
		yield return StartCoroutine (story_roll_text_word (8));
		dc.change_switch (6);
//		room_bg.sprite = Resources.Load ("bg5") as Sprite;
		yield return StartCoroutine (enter_or_exit_add_point (true));
		transport.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (0.5f, 0.015f, 0.06f));
		yield return StartCoroutine (story_roll_text_word (9));
		yield return StartCoroutine (change_transport_alpha (0f, 0.025f, 0.06f));
		add_button_appear (true);
		transport.transform.position = not_use_pos;
	}

	public IEnumerator go_out_again()
	{
		yield return StartCoroutine (enter_or_exit_add_point (false));
		return_button.SetActive (true);
		transport.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (0.5f, 0.025f, 0.06f));
		yield return StartCoroutine (story_roll_text_word (10));
		yield return StartCoroutine (change_transport_alpha (0f, 0.015f, 0.06f));
		transport.transform.position = not_use_pos;
	}

	public IEnumerator tenth_dead()
	{
		transport.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (1f, 0.015f, 0.06f));
		dc.change_switch (8);
		room_bg.transform.position = standard_pos;
		room_bg.sprite = Resources.Load ("bg6") as Sprite;
		start_bg.transform.position = not_use_pos;
		yield return StartCoroutine (change_transport_alpha (0.5f, 0.025f, 0.06f));
		yield return StartCoroutine (story_roll_text_word (11));
		yield return StartCoroutine (change_transport_alpha (0f, 0.015f, 0.06f));
		transport.transform.position = not_use_pos;
	}

	public IEnumerator twentieth_dead()
	{
		transport.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (1f, 0.015f, 0.06f));
		dc.change_switch (9);
		room_bg.transform.position = standard_pos;
		room_bg.sprite = Resources.Load ("bg6") as Sprite;
		start_bg.transform.position = not_use_pos;
		yield return StartCoroutine (change_transport_alpha (0.5f, 0.025f, 0.06f));
		yield return StartCoroutine (story_roll_text_word (12));
		yield return StartCoroutine (change_transport_alpha (0f, 0.015f, 0.06f));
		transport.transform.position = not_use_pos;
	}

//	public IEnumerator thirtieth_dead()
//	{
//		transport.transform.position = standard_pos;
//		yield return StartCoroutine (change_transport_alpha (1f, 0.015f, 0.06f));
//		dc.change_switch (10);
//		room_bg.transform.position = standard_pos;
//		room_bg.sprite = Resources.Load ("bg6") as Sprite;
//		start_bg.transform.position = not_use_pos;
//		yield return StartCoroutine (change_transport_alpha (0.5f, 0.025f, 0.06f));
//		yield return StartCoroutine (story_roll_text_word (13));
//		yield return StartCoroutine (change_transport_alpha (0f, 0.015f, 0.06f));
//		transport.transform.position = not_use_pos;
//	}

	public IEnumerator true_end()
	{
		transport.transform.position = standard_pos;
		go_button.position = not_use_pos;
		player_thing.position = not_use_pos;
		player_image.position = not_use_pos;
		yield return StartCoroutine (change_transport_alpha (1f, 0.015f, 0.06f));
		room_bg.sprite = Resources.Load ("bg_true_end1") as Sprite;
		yield return StartCoroutine (change_transport_alpha (0.5f, 0.03f, 0.06f));
		yield return StartCoroutine (story_roll_text_word (101));
		yield return StartCoroutine (change_transport_alpha (1f, 0.015f, 0.06f));
		room_bg.sprite = Resources.Load ("bg_true_end2") as Sprite;
		yield return StartCoroutine (change_transport_alpha (0.5f, 0.03f, 0.06f));
		yield return StartCoroutine (story_roll_text_word (102));
		yield return StartCoroutine (change_transport_alpha (1f, 0.015f, 0.06f));
		start_button.FindChild("Text").GetComponent<Text>().text = "New Game";
		bc.game_end ();
		PlayerPrefs.SetInt ("has_played", 0);
		PlayerPrefs.Save ();
		room_bg.transform.position = not_use_pos;
		start_bg.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (0f, 0.03f, 0.06f));
		transport.transform.position = not_use_pos;
	}

	public IEnumerator good_end()
	{
		transport.transform.position = standard_pos;
		go_button.position = not_use_pos;
		player_thing.position = not_use_pos;
		player_image.position = not_use_pos;
		yield return StartCoroutine (change_transport_alpha (1f, 0.015f, 0.06f));
		room_bg.sprite = Resources.Load ("bg_good_end1") as Sprite;
		yield return StartCoroutine (change_transport_alpha (0.5f, 0.03f, 0.06f));
		yield return StartCoroutine (story_roll_text_word (201));
		yield return StartCoroutine (change_transport_alpha (1f, 0.015f, 0.06f));
		room_bg.sprite = Resources.Load ("bg_good_end2") as Sprite;
		yield return StartCoroutine (change_transport_alpha (0.5f, 0.03f, 0.06f));
		yield return StartCoroutine (story_roll_text_word (202));
		yield return StartCoroutine (change_transport_alpha (1f, 0.015f, 0.06f));
		bc.game_end ();
		start_button.FindChild("Text").GetComponent<Text>().text = "New Game";
		PlayerPrefs.SetInt ("has_played", 0);
		PlayerPrefs.Save ();
		room_bg.transform.position = not_use_pos;
		start_bg.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (0f, 0.03f, 0.06f));
		transport.transform.position = not_use_pos;
	}

	public IEnumerator bad_end()
	{
		transport.transform.position = standard_pos;
		go_button.position = not_use_pos;
		player_thing.position = not_use_pos;
		player_image.position = not_use_pos;
		yield return StartCoroutine (change_transport_alpha (1f, 0.015f, 0.06f));
		room_bg.sprite = Resources.Load ("bg_bad_end1") as Sprite;
		yield return StartCoroutine (change_transport_alpha (0.5f, 0.03f, 0.06f));
		yield return StartCoroutine (story_roll_text_word (301));
		yield return StartCoroutine (change_transport_alpha (1f, 0.015f, 0.06f));
		room_bg.sprite = Resources.Load ("bg_bad_end2") as Sprite;
		yield return StartCoroutine (change_transport_alpha (0.5f, 0.03f, 0.06f));
		yield return StartCoroutine (story_roll_text_word (302));
		yield return StartCoroutine (change_transport_alpha (1f, 0.015f, 0.06f));
		bc.game_end ();
		start_button.FindChild("Text").GetComponent<Text>().text = "New Game";
		PlayerPrefs.SetInt ("has_played", 0);
		PlayerPrefs.Save ();
		room_bg.transform.position = not_use_pos;
		start_bg.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (0f, 0.03f, 0.06f));
		transport.transform.position = not_use_pos;
	}




	public IEnumerator change_transport_alpha(float alpha, float time_slice, float time)
	{
		float delta = (alpha - transport.color.a)/20;
		for (int i = 0; i < 20; i++) {
			transport.color = new Color (0, 0, 0, transport.color.a + delta);
			yield return new WaitForSeconds (time_slice);
		}
		yield return new WaitForSeconds (time);
	}

	public IEnumerator player_dead()
	{
		transport.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (1f, 0.03f, 0.06f));
		add_button_appear (true);
		bc.update_status (false);
		go_button.FindChild ("Text").GetComponent<Text> ().text = "Open";
		bc.monster_thing.position = not_use_pos;
		room_bg.transform.position = not_use_pos;
		start_bg.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (0f, 0.025f, 0.06f));
		transport.transform.position = not_use_pos;
	}

	public IEnumerator story_roll_text_word(int id)
	{
		dialogs tem_dialogs;
		tem_dialogs = dc.next_dialog (id);

		bool is_max = false;
		for (int i = 0, j = 0; i < tem_dialogs.size; i++) {
			is_max = false;
			if ((int)Mathf.Ceil ((float)tem_dialogs.str [i].Length / dc.dialog_word_max_num) + j > dc.dialog_row_max_num) {
				is_max = true;
			}
			if (is_max) {
				i -= 1;
				yield return new WaitForSeconds (3.0f);
				for (int k = 0; k < j; k++) {
					roll_text [k].color = new Color (1, 1, 1, 0);
				}

				for (int k = 0; k < dc.dialog_row_max_num; k++) {
					roll_text [k].text = "";
				}
				j = 0;
				continue;
			}
			yield return StartCoroutine (roll_text_word (tem_dialogs.str [i], j));
			j = (int)Mathf.Ceil ((float)tem_dialogs.str [i].Length / dc.dialog_word_max_num) + j;
		}
		yield return new WaitForSeconds (3.0f);
		for (int k = 0; k < dc.dialog_row_max_num; k++) {
			roll_text [k].color = new Color (1, 1, 1, 0);
		}

		for (int k = 0; k < dc.dialog_row_max_num; k++) {
			roll_text [k].text = "";
		}

//		for (int i = 0, j = 0, k = 0; i < tem_dialogs.size; i++, j++) {
//			
//			tem.Add (tem_dialogs.str [i]);
//			if (i == tem_dialogs.size - 1 && j != dc.dialog_row_max_num - 1) {
//				k = 1;
//			}
//			if (j == dc.dialog_row_max_num - 1 || k == 1) {
//				yield return StartCoroutine (roll_text_word (tem));
//
//				tem.Clear ();
//				j = -1;
//			}
//		}
	}


	public IEnumerator roll_text_word(string text, int num)
	{
		string tem_str = text;
		int j = 17;
		for (int i = 0; i < (int)Mathf.Ceil((float)text.Length / dc.dialog_word_max_num) ; i++) {
			roll_text [num + i].color = new Color (1, 1, 1, 0);
			if (tem_str.Length < 17) {
				roll_text [num + i].text = tem_str;
			} else {
				j = 17;
				for (int k = 0,temp = 0; k < tem_str.Length; j++) {
					temp = tem_str.Substring (0, j).IndexOf ("......", k);
					if (temp == -1 || temp > j - 6) {
						break;
					}
					k = tem_str.Substring (0, j).IndexOf ("......", k) + 6;
					j = j + 4;
				}
				roll_text [num + i].text = tem_str.Substring(0, j);
			}
			if (tem_str.Length > 17) {
				tem_str = tem_str.Substring (17);
			}

		}
		for(float k = 0f; k < 1f; k += 0.05f) {
			for (int i = 0; i < (int)Mathf.Ceil ((float)text.Length / dc.dialog_word_max_num); i++) {
				roll_text[num + i].color = new Color (1f, 1f, 1f, k);
			}
			yield return new WaitForSeconds (0.03f);
		}
		yield return new WaitForSeconds (1.0f);
	}
//	public IEnumerator roll_text_word(List<string> text)
//	{
//		for (int i = 0; i < text.Count; i++) {
//			roll_text [i].color = new Color (1, 1, 1, 0);
//			roll_text [i].text = text[i];
//			for(float k = 0f; k < 1f; k += 0.05f) {
//				roll_text[i].color = new Color (1f, 1f, 1f, k);
//				yield return new WaitForSeconds (0.03f);
//			}
//			yield return new WaitForSeconds (0.3f);
//		}
//		yield return new WaitForSeconds (2.0f);
//
//		for (int k = 0; k < text.Count; k++) {
//			roll_text [k].color = new Color (1, 1, 1, 0);
//		}
//
//		for (int k = 0; k < 11; k++) {
//			roll_text [k].text = "";
//		}
//
//	}

	public void add_button_appear(bool isappear)
	{
		if (isappear) {
			add_point_button.position = go_button.position + new Vector3(0,-90,0);
			return;
		}
		add_point_button.position = not_use_pos;
	}

	public IEnumerator enter_or_exit_add_point(bool isenter)
	{
		transport.transform.position = standard_pos;
		yield return StartCoroutine (change_transport_alpha (1f, 0.015f, 0.06f));
		if (isenter) {
			button.position = not_use_pos;
			player_thing.position = not_use_pos;
			add_point.position = standard_pos;
			ac.update_text (bc.player_gold);
			yield return StartCoroutine (change_transport_alpha (0f, 0.015f, 0.06f));
			transport.transform.position = not_use_pos;
			yield break;
		}
		button.position = standard_pos;
		player_thing.position = standard_pos;
		add_point.position = not_use_pos;
		yield return StartCoroutine (change_transport_alpha (0f, 0.015f, 0.06f));
		transport.transform.position = not_use_pos;
	}
}
