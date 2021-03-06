﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Boomlagoon.JSON;

public class RankCell : MonoBehaviour 
{
	public RawImage ProfileImage;
	public Text TextRank, TextName, TextPoint;

    // Use this for initialization
    void Start()
    {
        var rect = GetComponent<RectTransform>();
    }

	public void SetData(JSONObject user)
	{
		string url = user["FacebookPhotoURL"].Str ;
		Debug.Log (url);
		HTTPClient.Instance.GET (url, delegate(WWW obj) 
        {
			ProfileImage.texture = obj.texture;
		});

		TextRank.text = user ["Rank"].Number.ToString();
		TextName.text = user ["FacebookName"].Str;
		TextPoint.text = user ["Point"].Number.ToString();
	}
}
