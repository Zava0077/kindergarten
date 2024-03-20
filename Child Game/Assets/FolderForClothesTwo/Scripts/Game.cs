using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField] private Transform _panelCard;
	[SerializeField] private List<Card> _cards;

	[SerializeField] private int _numberCard;
	[SerializeField] private bool _findCard;

	[SerializeField] private GameObject _winPanel;

	public bool FindCard => _findCard;

	public void Awake()
	{
		_panelCard.GetChild(1).transform.SetSiblingIndex(Random.Range(0, _panelCard.childCount));
	}

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
				StartCoroutine(Win(card));
			}
		}
	}
	public void NoFindCards()
	{
		foreach (Card card in _cards)
		{
			if (card.Down)
			{
				StartCoroutine(NoFind(card));
			}
		}
	}

	IEnumerator NoFind(Card card)
	{
		_findCard = true;
		yield return new WaitForSeconds(1f);
		card.GetComponent<Card>().NoFindCard();
		_findCard = false;
	}

	IEnumerator Win(Card card)
	{
		_findCard = true;
		yield return new WaitForSeconds(1f);
		card.GetComponent<Card>().FindCard();
		_findCard = false;
		Win();
	}

	public void Win()
	{
		var a = 0;

		foreach (Card card in _cards)
		{
			if (card.Find)
			{
				a++;
			}
		}

		if (a == _panelCard.childCount) 
		{ 
			_winPanel.SetActive(true);
		
		}
	}
}
