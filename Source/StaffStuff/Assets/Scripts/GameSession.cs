﻿using System;
using UnityEngine;
using UnityRandom = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class GameSession : Singleton<GameSession>
{
	public GameObject visitorPrefab;
	public uint popularity = 10;
    public uint maxPopularity = 100;

	public float time;
    public float maxTime = 5f;
	private float currentTimer;

	private void Start()
	{
		if(visitorPrefab == null) throw new NullReferenceException();
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
	}

	private void Update()
	{
		time += Time.time;
		currentTimer += Time.deltaTime;
		if (currentTimer >= 0.5f)
		{
			var x = UnityRandom.Range(-10.0f, 10.0f);
			Instantiate(visitorPrefab, new Vector3(x, -8.0f, 0.0f), new Quaternion());
			currentTimer = 0.0f;
		}
	}

	public void DecreasePopularity(VisitorTypes visitorType)
	{
		popularity -= 1;
		Debug.Log(popularity);
	}

	public void IncreasePopularity(VisitorTypes visitorType)
	{
		popularity += 1;
		Debug.Log(popularity);
	}
}
