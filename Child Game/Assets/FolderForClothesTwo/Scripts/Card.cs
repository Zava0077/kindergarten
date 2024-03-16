using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
	[SerializeField] private Game _game;

	[SerializeField] private Sprite _backSprite;
	[SerializeField] private Sprite _frontSprite;
	[SerializeField] private Sprite _winSprite;


	[SerializeField] private int _number;

	public bool Down => this.GetComponent<Image>().sprite == _frontSprite;
	public int Number => _number;

	public void OnMouseDown()
	{
		if (!Down)
		{
			this.GetComponent<Image>().sprite = _frontSprite;
			_game.OpenCards();
		}
		
	}

	public void NoFindCard()
	{
		this.GetComponent<Image>().sprite = _backSprite;
	}
	public void FindCard()
	{
		this.GetComponent<Image>().sprite = _winSprite;
	}

}
