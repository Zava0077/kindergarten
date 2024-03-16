using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField] private Transform _panelCard;
	[SerializeField] private List<Card> _cards;

	[SerializeField] private int _numberCard;

	public void Start()
	{
		for(int i = 0; i < _panelCard.childCount; i++)
		{
			_cards.Add(_panelCard.GetChild(i).GetComponent<Card>());
		}
	}

	public void OpenCards()
	{
		var OpenCard = 0;

		foreach (Card card in _cards) 
		{ 
			if (card.Down)
			{
				if(OpenCard == 0)
				{
					_numberCard = card.Number;	
				}
				OpenCard++;
			}
		}

		if (OpenCard == 2)
		{
			CheackCard();
		}
	}
	public void CheackCard()
	{
		var a = 0;

		foreach (Card card in _cards)
		{
			if (card.Down && card.Number == _numberCard)
			{
				a++;
			}
		}

		if (a == 2)
		{
			FindCards();
		}
		else
		{
			NoFindCards();
		}
	}
	public void FindCards()
	{
		foreach (Card card in _cards)
		{
			if (card.Down)
			{
				card.GetComponent<Card>().FindCard();
			}
		}
	}
	public void NoFindCards()
	{
		foreach (Card card in _cards)
		{
			if (card.Down)
			{
				card.GetComponent<Card>().NoFindCard();
			}
		}
	}
}
