using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class dialogs
{
	public dialogs()
	{
		size = 0;
		str = new List<string> ();
	}

	public int size;
	public List<string> str;

};

public class DataController : MonoBehaviour {


	public StageController sc;
	public int dialog_word_max_num = 17;
	public int dialog_row_max_num = 11;
	public int step = 0;
	public int dead_num = 0;
	public bool is_out = false;
	public bool first_start = false;//1
	public bool first_monster = false;//2
	public bool first_win = false;//3
	public bool second_monster = false;//4
	public bool first_dead = false;//5
	public bool second_alive = false;//6
	public bool go_again = false;//7
	public bool tenth_dead = false;//8
	public bool twentieth_dead = false;//9
	public bool thirtieth_dead = false;//10

	private StreamReader sr;

	// Use this for initialization
	void Start () {
		dead_num = PlayerPrefs.GetInt ("dead_num", 0);
		step = PlayerPrefs.GetInt("step",0);
		dead_num = PlayerPrefs.GetInt("dead_num",0);
		is_out = (PlayerPrefs.GetInt("is_out",0) == 0 ? false : true);
		first_start = (PlayerPrefs.GetInt("first_start",0) == 0 ? false : true);//1
		first_monster = (PlayerPrefs.GetInt("first_monster",0) == 0 ? false : true);//2
		first_win = (PlayerPrefs.GetInt("first_win",0) == 0 ? false : true);//3
		second_monster = (PlayerPrefs.GetInt("second_monster",0) == 0 ? false : true);//4
		first_dead = (PlayerPrefs.GetInt("first_dead",0) == 0 ? false : true);//5
		second_alive = (PlayerPrefs.GetInt("second_alive",0) == 0 ? false : true);//6
		go_again = (PlayerPrefs.GetInt("go_again",0) == 0 ? false : true);//7
		tenth_dead = (PlayerPrefs.GetInt("tenth_dead",0) == 0 ? false : true);//8
		twentieth_dead = (PlayerPrefs.GetInt("twentieth_dead",0) == 0 ? false : true);//9
//		thirtieth_dead = (PlayerPrefs.GetInt("thirtieth_dead",0) == 0 ? false : true);//10
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void change_switch(int id)
	{
		switch (id) {
		case 0:
			is_out = !is_out;
			PlayerPrefs.SetInt ("is_out",(is_out == false ? 0 : 1));
			break;
		case 1:
			first_start = !first_start;
			PlayerPrefs.SetInt ("first_start",(first_start == false ? 0 : 1));
			break;
		case 2:
			first_monster = !first_monster;
			PlayerPrefs.SetInt ("first_monster",(first_monster == false ? 0 : 1));
			break;
		case 3:
			first_win = !first_win;
			PlayerPrefs.SetInt ("first_win",(first_win == false ? 0 : 1));
			break;
		case 4:
			second_monster = !second_monster;
			PlayerPrefs.SetInt ("second_monster",(second_monster == false ? 0 : 1));
			break;
		case 5:
			first_dead = !first_dead;
			PlayerPrefs.SetInt ("first_dead",(first_dead == false ? 0 : 1));
			break;
		case 6:
			second_alive = !second_alive;
			PlayerPrefs.SetInt ("second_alive",(second_alive == false ? 0 : 1));
			break;
		case 7:
			go_again = !go_again;
			PlayerPrefs.SetInt ("go_again",(go_again == false ? 0 : 1));
			break;
		case 8:
			tenth_dead = !tenth_dead;
			PlayerPrefs.SetInt ("tenth_dead",(tenth_dead == false ? 0 : 1));
			break;
		case 9:
			twentieth_dead = !twentieth_dead;
			PlayerPrefs.SetInt ("twentieth_dead",(twentieth_dead == false ? 0 : 1));
			break;
//		case 10:
//			thirtieth_dead = !thirtieth_dead;
//			PlayerPrefs.SetInt ("second_alive",(second_alive == false ? 0 : 1));
//			break;
		default:
			break;
		}
		PlayerPrefs.Save ();
	}

	public void add_deadnum(bool clean)
	{
		dead_num ++;
		if (clean) {
			dead_num = 0;
		}
		PlayerPrefs.SetInt ("dead_num", dead_num);
		PlayerPrefs.Save ();
	}

	public void add_step(bool clean)
	{
		step ++;
		if (clean) {
			step = 0;
		}
		PlayerPrefs.SetInt ("step", step);
		PlayerPrefs.Save ();
	}

	public dialogs next_dialog(int id)
	{
		dialogs tem = new dialogs ();
		string tem_str = "";
		for (;;) {
			tem_str = sr.ReadLine();
			print (tem_str);
			if (tem_str.IndexOf(""+id) != -1) {
				tem_str = tem_str.Split ( (""+id).ToCharArray()) [0];
				break;
			}
			for (;;) {
				tem_str = sr.ReadLine();
				if (tem_str == null || tem_str == ";") {
					break;
				}
			}
		}
		for(;;)
		{
			tem.str.Add (tem_str);
			print (tem_str);
			tem_str = sr.ReadLine();
			if (tem_str == null || tem_str == ";") {
				break;
			}
		}
		tem.size = tem.str.Count;
		return tem;
	}

	public void open()
	{
		string path = Application.dataPath + "/Resources/test.txt";
		if (!File.Exists (path))
			print ("load data error!");
		sr = File.OpenText(path);;
	}

	public void close()
	{
		sr.Close();
	}

}
