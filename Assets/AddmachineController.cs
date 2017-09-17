using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AddmachineController : MonoBehaviour {

	public Text point_text;
	public Text gold_text;
	public Text cost_text;

	int point = 0;
	int gold = 0;
	int player_point;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("has_played", 0) == 0) {
			PlayerPrefs.SetInt ("player_point", 0);
			save_point ();
		}
		player_point = PlayerPrefs.GetInt ("player_point", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void update_text(int player_gold)
	{
		cost_text.color = Color.black;
		if (point == 0) {
			cost_text.text = "" + 0;
		} else {
			int sum = 0;
			for (int i = 1; i <= point; i++) {
				sum += ( (player_point + i) + 1) * (player_point + i) * 5;
			}
			cost_text.text = "" + sum;
		}
		point_text.text = "" + point;
		gold_text.text = "gold:\n" + player_gold;
	}

	public void add_point(int num)
	{
		point += num;
		if (point < 0) {
			point = 0;
		}
		int sum = 0;
		for (int i = 1; i <= point; i++) {
			sum += ( (player_point + i) + 1) * (player_point + i) * 5;
		}
		gold = sum;

	}

	public int get_point()
	{
		return point;
	}

	public int get_gold()
	{
		return gold;
	}

	public void clear_gold_and_point()
	{
		point = 0;
		gold = 0;
	}

	public void add_cost_point(int num)
	{
		player_point += num;
		save_point ();
	}

	public void save_point()
	{
		PlayerPrefs.SetInt ("player_point", player_point);
		PlayerPrefs.Save ();
	}
}
