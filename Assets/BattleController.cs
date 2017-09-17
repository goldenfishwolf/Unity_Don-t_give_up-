using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour {

	bool attack_done = true;
	int player_max_hp;
	int player_hp;
	int player_atk;
	int player_def;
	int player_lv;
	public int player_gold;

	int stage_num;
	string mon_name;
	int mon_max_hp;
	int mon_hp;
	int mon_atk;
	int mon_def;
	int mon_gold;
	public Text mon_name_text, mon_hp_text, mon_atk_text, mon_def_text,
				player_hp_text, player_atk_text, player_def_text, player_lv_text,
				mon_damage_text, player_damage_text;
	public Image mon_image, room_bg;
	public Image go_button, attack_button;
	public Transform monster_thing;
	public StageController sc;
	int mon_lv;
	private DataController dc;
	// Use this for initialization
	void Start () {
		dc = sc.dc;
		monster_thing.position = sc.not_use_pos;
		if (PlayerPrefs.GetInt ("has_played", 0) == 0) {
			player_hp = 100;
			player_max_hp = 100;
			player_atk = 10;
			player_def = 10;
			player_lv = 1;
			stage_num = 0;
			//====================================================
			//攻攻守攻攻攻攻攻攻攻攻
			int id = 1;
			PlayerPrefs.SetString("mon_name_" + id,"床底下的陰影");
			PlayerPrefs.SetInt("mon_hp_" + id,10);
			PlayerPrefs.SetInt ("mon_atk_" + id, 13);
			PlayerPrefs.SetInt ("mon_def_" + id, 7);
			PlayerPrefs.SetInt ("mon_gold_" + id, 10);
			//ATK=10 DEF=10 HP-9
			//100//0

			id = 2;
			PlayerPrefs.SetString("mon_name_" + id,"衣櫃裡的陰影");
			PlayerPrefs.SetInt("mon_hp_" + id,40);
			PlayerPrefs.SetInt ("mon_atk_" + id, 105);
			PlayerPrefs.SetInt ("mon_def_" + id, 10);
			PlayerPrefs.SetInt ("mon_gold_" + id, 30);
			//ATK=24 DEF=20 HP-170
			//ATK=20 DEF=24 HP-324
			//200//1

			id = 3;
			PlayerPrefs.SetString("mon_name_" + id,"床底下的陰影");
			PlayerPrefs.SetInt("mon_hp_" + id,220);
			PlayerPrefs.SetInt ("mon_atk_" + id, 75);
			PlayerPrefs.SetInt ("mon_def_" + id, 25);
			PlayerPrefs.SetInt ("mon_gold_" + id, 60);
			//ATK=48 DEF=40 HP-315
			//ATK=44 DEF=44 HP-341
			//ATK=40 DEF=48 HP-378
			//400//2

			id = 4;
			PlayerPrefs.SetString("mon_name_" + id,"床底下的陰影");
			PlayerPrefs.SetInt("mon_hp_" + id,500);
			PlayerPrefs.SetInt ("mon_atk_" + id, 150);
			PlayerPrefs.SetInt ("mon_def_" + id, 32);
			PlayerPrefs.SetInt ("mon_gold_" + id, 70);
			//ATK=82 DEF=70 HP-800
			//ATK=78 DEF=74 HP-760
			//ATK=74 DEF=78 HP-792
			//ATK=70 DEF=82 HP-884
			//800//3

			id = 5;
			PlayerPrefs.SetString("mon_name_" + id,"床底下的陰影");
			PlayerPrefs.SetInt("mon_hp_" + id,870);
			PlayerPrefs.SetInt ("mon_atk_" + id, 187);
			PlayerPrefs.SetInt ("mon_def_" + id, 78);
			PlayerPrefs.SetInt ("mon_gold_" + id, 100);
			//ATK=126 DEF=110 HP-1386
			//ATK=122 DEF=114 HP-1387
			//ATK=118 DEF=118 HP-1449
			//ATK=114 DEF=122 HP-1560
			//ATK=110 DEF=126 HP-1647
			//1600//4

			id = 6;
			PlayerPrefs.SetString("mon_name_" + id,"床底下的陰影");
			PlayerPrefs.SetInt("mon_hp_" + id,1357);
			PlayerPrefs.SetInt ("mon_atk_" + id, 256);
			PlayerPrefs.SetInt ("mon_def_" + id, 81);
			PlayerPrefs.SetInt ("mon_gold_" + id, 130);
			//ATK=184 DEF=160 HP-1344
			//ATK=180 DEF=164 HP-1288
			//ATK=176 DEF=168 HP-1320
			//ATK=172 DEF=172 HP-1260
			//ATK=168 DEF=176 HP-1280
			//ATK=164 DEF=180 HP-1292
			//ATK=160 DEF=184 HP-1296
			//3200//6

			id = 7;
			PlayerPrefs.SetString("mon_name_" + id,"床底下的陰影");
			PlayerPrefs.SetInt("mon_hp_" + id,2025);
			PlayerPrefs.SetInt ("mon_atk_" + id, 289);
			PlayerPrefs.SetInt ("mon_def_" + id, 36);
			PlayerPrefs.SetInt ("mon_gold_" + id, 150);
			//ATK=184 DEF=160 HP-1677
			//ATK=180 DEF=164 HP-1750
			//ATK=176 DEF=168 HP-1694
			//ATK=172 DEF=172 HP-1638
			//ATK=168 DEF=176 HP-1695
			//ATK=164 DEF=180 HP-1635
			//ATK=160 DEF=184 HP-1680
			//3200//6

			id = 8;
			PlayerPrefs.SetString("mon_name_" + id,"死亡的陰影");
			PlayerPrefs.SetInt("mon_hp_" + id,3000);
			PlayerPrefs.SetInt ("mon_atk_" + id, 450);
			PlayerPrefs.SetInt ("mon_def_" + id, 100);
			PlayerPrefs.SetInt ("mon_gold_" + id, 200);
			//ATK=248 DEF=220 HP-5750
			//ATK=244 DEF=224 HP-5876
			//ATK=240 DEF=228 HP-5994
			//ATK=236 DEF=232 HP-6104
			//ATK=232 DEF=236 HP-6206
			//ATK=228 DEF=240 HP-6300
			//ATK=224 DEF=244 HP-6386
			//ATK=220 DEF=248 HP-6666
			//6400//7

			id = 9;
			PlayerPrefs.SetString("mon_name_" + id,"失業的陰影");
			PlayerPrefs.SetInt("mon_hp_" + id,4500);
			PlayerPrefs.SetInt ("mon_atk_" + id, 780);
			PlayerPrefs.SetInt ("mon_def_" + id, 123);
			PlayerPrefs.SetInt ("mon_gold_" + id, 250);
			//ATK=326 DEF=290 HP-10780
			//ATK=322 DEF=294 HP-10692
			//ATK=318 DEF=298 HP-11086
			//ATK=314 DEF=302 HP-
			//ATK=310 DEF=306 HP-
			//ATK=306 DEF=310 HP-
			//ATK=302 DEF=314 HP-
			//ATK=298 DEF=318 HP-
			//ATK=294 DEF=322 HP-
			//ATK=290 DEF=326 HP-
			//12800//9

			id = 10;
			PlayerPrefs.SetString("mon_name_" + id,"毒品的陰影");
			PlayerPrefs.SetInt("mon_hp_" + id,7400);
			PlayerPrefs.SetInt ("mon_atk_" + id, 917);
			PlayerPrefs.SetInt ("mon_def_" + id, 171);
			PlayerPrefs.SetInt ("mon_gold_" + id, 290);
			//ATK=414 DEF=370 HP-16410
			//ATK=410 DEF=374 HP-16290
			//ATK=406 DEF=378 HP-16709
			//ATK=402 DEF=382 HP-
			//ATK=398 DEF=386 HP-
			//ATK=394 DEF=390 HP-
			//ATK=390 DEF=394 HP-
			//ATK=386 DEF=398 HP-
			//ATK=382 DEF=402 HP-
			//ATK=378 DEF=406 HP-
			//ATK=374 DEF=410 HP-
			//ATK=370 DEF=414 HP-
			//25600//11
			id = 11;
			PlayerPrefs.SetString("mon_name_" + id,"死亡的陰影");
			PlayerPrefs.SetInt("mon_hp_" + id,12345);
			PlayerPrefs.SetInt ("mon_atk_" + id, 1234);
			PlayerPrefs.SetInt ("mon_def_" + id, 234);
			PlayerPrefs.SetInt ("mon_gold_" + id, 10);
			//ATK=508 DEF=460 HP-34830
			//ATK=504 DEF=464 HP-34650
			//ATK=500 DEF=468 HP-35236
			//ATK=496 DEF=472 HP-
			//ATK=492 DEF=476 HP-
			//ATK=488 DEF=480 HP-
			//ATK=484 DEF=484 HP-
			//ATK=480 DEF=488 HP-
			//ATK=476 DEF=492 HP-
			//ATK=472 DEF=496 HP-
			//ATK=468 DEF=500 HP-
			//ATK=464 DEF=504 HP-
			//ATK=460 DEF=508 HP-
			//51200//12
			save_status ();
			print(PlayerPrefs.GetInt ("player_lv", 10));
		}
		player_lv = PlayerPrefs.GetInt ("player_lv", 1);
		player_max_hp = PlayerPrefs.GetInt ("player_max_hp", 100);
		player_hp = PlayerPrefs.GetInt ("player_hp", 100);
		player_atk = PlayerPrefs.GetInt ("player_atk", 10);
		player_def = PlayerPrefs.GetInt ("player_def", 10);
		player_gold = PlayerPrefs.GetInt ("player_gold", 0);
		stage_num = PlayerPrefs.GetInt ("stage_num", 0);
		print (player_lv + " " + player_max_hp + " " + player_hp + " " + player_atk + " " + player_def + " " + player_gold + " " + stage_num);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void battle_start(int id)
	{
		mon_image.sprite = Resources.Load ("mon_" + id) as Sprite;
		if (mon_image.sprite == null) {
			mon_image.color = Color.black;
		} else {
			mon_image.color = Color.white;
		}
		mon_name = PlayerPrefs.GetString ("mon_name_" + id, "test monster");
		mon_max_hp = PlayerPrefs.GetInt ("mon_hp_" + id, 10);
		mon_hp = mon_max_hp;
		mon_atk = PlayerPrefs.GetInt ("mon_atk_" + id, 13);
		mon_def = PlayerPrefs.GetInt ("mon_def_" + id, 7);
		mon_gold = PlayerPrefs.GetInt ("mon_gold_" + id, 10);
		update_status (true);
		update_status (false);
		player_damage_text.text = "";
		mon_damage_text.text = "";
		change_battle ();
		monster_thing.position = sc.standard_pos;
		sc.player_thing.position = sc.standard_pos;
		stage_num = id;
		save_status ();
	}

	public IEnumerator attack()
	{
		Vector3 tem;
		tem = mon_damage_text.transform.position;
		attack_done = false;
		int damage = player_atk - mon_def;
		if (damage < 0) {
			damage = 0;
		}
		mon_hp -= damage;
		if (mon_hp <= 0) {
			mon_hp = 0;
		}
		mon_damage_text.color = new Color (1,0,0,0);
		update_status(true);
		mon_damage_text.text = "" + damage;

		if (damage != 0) {
			StartCoroutine (tremble (mon_image.gameObject));
		}

		for (float i = 0f; i < 1.0f; i += 0.05f) {
			mon_damage_text.color = Color.red;//i);
			mon_damage_text.transform.position = tem + new Vector3(0,20*4*i*i,0);
			//mon_damage_text.transform.position += new Vector3 (5, 5, 0);
			yield return new WaitForSeconds (0.01f);
		}
//		for (float i = 1f; i > 0.0f; i -= 0.05f) {
//			mon_damage_text.color = new Color (1,0,0,i);
//			//mon_damage_text.transform.position += new Vector3 (5, 5, 0);
//			yield return new WaitForSeconds (0.02f);
//		}
		yield return new WaitForSeconds (0.5f);
		mon_damage_text.color = new Color (1,0,0,0);				
		mon_damage_text.transform.position = tem;
		if (check_end (true)) {
			attack_done = true;
			yield break;
		}

		tem = player_damage_text.transform.position;
		damage = mon_atk - player_def;
		if (damage < 0) {
			damage = 0;
		}
		player_hp -= damage;
		if (player_hp <= 0) {
			player_hp = 0;
		}
		player_damage_text.color = new Color (1,0,0,0);
		update_status(false);
		player_damage_text.text = "" + damage;
		if (damage != 0) {
			StartCoroutine (tremble (room_bg.gameObject));
		}

		for (float i = 0f; i < 1.0f; i += 0.05f) {
			player_damage_text.color = Color.red;

			player_damage_text.transform.position += new Vector3(0,(40*i + 1)/5,0);
			yield return new WaitForSeconds (0.01f);
		}
		yield return new WaitForSeconds (0.5f);
//		for (float i = 1f; i > 0.0f; i -= 0.05f) {
//			player_damage_text.color = new Color (1,0,0,i);
//
//			//player_damage_text.transform.position += new Vector3 (5, 5, 0);
//			yield return new WaitForSeconds (0.02f);
//		}
//		yield return new WaitForSeconds (0.06f);
		player_damage_text.color = new Color (1,0,0,0);
		player_damage_text.transform.position = tem;
		if (check_end (false)) {
			attack_done = true;
			yield break;
		}
		attack_done = true;

	}

	public bool check_attack_done()
	{
		return attack_done;
	}

	public IEnumerator tremble(GameObject g)
	{
		Vector3 tem = g.transform.position;
		for (int i = 1; i <= 5; i++) {
			g.transform.position = tem + new Vector3( i * i,0,0);
			yield return new WaitForSeconds (0.005f);
		}
		for (int i = 5; i >= 1; i--) {
			g.transform.position = tem + new Vector3( i * i,0,0);
			yield return new WaitForSeconds (0.0025f);
		}
		for (int i = 1; i <= 5; i++) {
			g.transform.position = tem - new Vector3( i * i,0,0);
			yield return new WaitForSeconds (0.0025f);
		}
		for (int i = 5; i >= 1; i--) {
			g.transform.position = tem - new Vector3( i * i,0,0);
			yield return new WaitForSeconds (0.005f);
		}
		g.transform.position = tem;
	}

	bool check_end(bool is_monster)
	{
		if (is_monster) {
			if (mon_hp == 0) {
				player_gold += mon_gold;
				monster_thing.position = sc.not_use_pos;
				change_battle ();
				if (dc.first_monster && !dc.first_win) {
					StartCoroutine(sc.first_win());
					return true;
				}
				print (stage_num);
				if (stage_num == 11) {
					if (dc.twentieth_dead) {
						StartCoroutine(sc.bad_end());
						return true;
					}
					if (dc.tenth_dead) {
						StartCoroutine(sc.true_end());
						return true;
					}
					StartCoroutine(sc.good_end());
					return true;
				}
				StartCoroutine (sc.battle_end (mon_gold));
				return true;
			}
		} else {
			if (player_hp == 0) {
				dc.add_deadnum(false);
				dc.change_switch (0);
				dc.add_step (true);
				stage_num = 0;
				level_up ();
				change_battle ();
				if (dc.second_monster && !dc.first_dead) {
					StartCoroutine (sc.first_dead ());
				} else {
					StartCoroutine (sc.player_dead ());
				}
				return true;
			}
		}
		return false;
	}

	public void level_up()
	{
		player_max_hp *= 2;
		player_hp = player_max_hp;
		player_atk += 10*player_lv;
		player_def += 10*player_lv;
		player_lv++;
		save_status ();
	}
	public bool add_point(bool isatk, int num, int gold)
	{
		print (gold);
		print (player_gold);
		if (player_gold < gold) {
			return false;
		}

		if (isatk) {
			player_gold -= gold;
			player_atk += num;
			update_status (false);
			return true;
		}
		player_gold -= gold;
		player_def += num;
		update_status (false);
		return true;
	}

	public void update_status(bool is_monster)
	{
		if (is_monster) {
			mon_name_text.text = mon_name;
			mon_hp_text.text = "HP: " + mon_hp + "/" + mon_max_hp;
			mon_atk_text.text = "ATK: " + mon_atk;
			mon_def_text.text = "DEF: " + mon_def;
		} else {
			player_lv_text.text = "LV: " + player_lv;
			player_hp_text.text = "HP: " + player_hp + "/" + player_max_hp;
			player_atk_text.text = "ATK: " + player_atk;
			player_def_text.text = "DEF: " + player_def;
		}
	}

	public void change_battle()
	{
		Vector3 tem = go_button.transform.position;
		go_button.transform.position = attack_button.transform.position;
		attack_button.transform.position = tem;
	}

	public void game_end()
	{
		player_hp = 100;
		player_max_hp = 100;
		player_atk = 10;
		player_def = 10;
		player_lv = 1;
		stage_num = 0;
		save_status ();
		dc.close ();
		dc.add_deadnum (true);
		dc.add_step (true);
	}

	public void save_status()
	{
		PlayerPrefs.SetInt ("player_lv", player_lv);
		PlayerPrefs.SetInt ("player_max_hp", player_max_hp);
		PlayerPrefs.SetInt ("player_hp",player_hp);
		PlayerPrefs.SetInt ("player_atk",player_atk);
		PlayerPrefs.SetInt ("player_def",player_def);
		PlayerPrefs.SetInt ("player_lv",player_lv);
		PlayerPrefs.SetInt ("stage_num",stage_num);

		PlayerPrefs.Save();
	}
}
