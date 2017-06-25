using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


public class SettingsPopUP : MonoBehaviour {
	public  SettingsPopUP playButton;
	public UnityEvent signalOnClick = new UnityEvent();
	public GameObject settingPrefab;
	public void _onClick()
	{
		this.signalOnClick.Invoke();
	}

	void Start()
	{
		playButton.signalOnClick.AddListener(this.showSetting);
	}
	void showSetting()
	{
		GameObject parent = UICamera.first.transform.parent.gameObject;
		GameObject obj = NGUITools.AddChild (parent, settingPrefab);
		SettingsPopUP popup = obj.GetComponent<SettingsPopUP> ();
		obj.transform.localScale = new Vector3 (0.52f, 0.54f, 1f);
	}
		}
