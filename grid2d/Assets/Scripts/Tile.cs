﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile{

	public GameObject gamePrefab;

	private Vector2 _position;
	private bool _isBoundary;
	private bool _isOccupied;
	private bool _isVisible;
	private bool _blocksLight;
	private bool _isExplored;
	private bool _isLit;

	private List<Entity> _objects;

	private Color32 COLOR_LIT = new Color32(215, 215, 215, 255);
	private Color32 COLOR_EXPLORE = new Color32(80, 80, 80, 255);
	private Color32 COLOR_UNEXPLORED = new Color32(0, 0, 0, 255);

	private Gradient gradient = new Gradient();

	public Tile (Vector2 position, bool isBoundary, bool isVisible, bool blocksLight, bool isExplored, bool isLit)
	{
		_position = position;
		_isBoundary = isBoundary;
		_isVisible = isVisible;
		_blocksLight = blocksLight;
		_isExplored = isExplored;
		_isLit = isLit;
		_objects = new List<Entity> ();

		GradientColorKey[] gck = new GradientColorKey[2];
		gck [0].color = COLOR_LIT; gck [0].time = 0.0f;
		gck [1].color = new Color32(100, 100, 100, 255); gck [1].time = 1.0f;
		GradientAlphaKey[] gak = new GradientAlphaKey[2];
		gak [0].alpha = 1.0f; gak [0].time = 0.0f;
		gak [1].alpha = 1.0f; gak [1].time = 1.0f;
		gradient.SetKeys (gck, gak);
	}

	public Vector2 position
	{
		get { return _position; }
		set { _position = value; }
	}

	public bool isBoundary
	{
		get { return _isBoundary; }
		set { _isBoundary = value; }
	}

	public bool isOccupied
	{
		get { return _isOccupied; }
		set { _isOccupied = value; }
	}

	public bool isVisible
	{
		get { return _isVisible; }
		set { _isVisible = value; }
	}

	public bool blocksLight
	{
		get { return _blocksLight; }
		set { _blocksLight = value; }
	}

	public bool isExplored
	{
		get { return _isExplored; }
		set { _isExplored = value; }
	}

	public bool isLit
	{
		get { return _isLit; }
		set { _isLit = value; }
	}

	public void addEntity (Entity e)
	{
		_objects.Add (e);
	}

	public List<Entity> getObjects ()
	{
		return _objects;
	}

	public void markTileAsLit(float gradientValue)
	{
		gamePrefab.GetComponent<SpriteRenderer> ().color = (Color32) gradient.Evaluate(gradientValue);

		_isLit = true;
		_isExplored = true;
	}

	public void markTileAsUnexplored()
	{
		gamePrefab.GetComponent<SpriteRenderer> ().color = COLOR_UNEXPLORED;
		_isLit = false;
		_isExplored = false;
	}

	public void markTileAsExplored()
	{
		gamePrefab.GetComponent<SpriteRenderer> ().color = COLOR_EXPLORE;
	}
}
