using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckTester : MonoBehaviour
{
    [SerializeField]
    List<AbilityCardData> _abilityDeckConfig
        = new List<AbilityCardData>();
    [SerializeField] AbilityCardView _abilityCardView = null;
    [SerializeField] DiscardCardView _discardCardView = null;
    Deck<AbilityCard> _abilityDeck = new Deck<AbilityCard>();
    Deck<AbilityCard> _abilityDiscard = new Deck<AbilityCard>();
    [SerializeField] GameObject CardSlot;

    Deck<AbilityCard> _playerHand = new Deck<AbilityCard>();

    private void Start()
    {
        SetupAbilityDeck();
        Debug.Log(_playerHand.Count);
    }

    private void SetupAbilityDeck()
    {
        foreach(AbilityCardData abilityData in _abilityDeckConfig)
        {
            AbilityCard newAbilityCard = new AbilityCard(abilityData);
            _abilityDeck.Add(newAbilityCard);
        }
        _abilityDeck.Shuffle();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Draw();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            PrintPlayerHand();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayTopCard();
        }
    }

    public void Draw()
    {
        if(CardSlot.activeSelf)
        {
           CardSlot.SetActive(false);
        }

        AbilityCard newCard = _abilityDeck.Draw(DeckPosition.Top);
        Debug.Log("Drew card: " + newCard.Name);
        _playerHand.Add(newCard, DeckPosition.Top);

        _abilityCardView.Display(newCard);
    }

    private void PrintPlayerHand()
    {
        for (int i = 0; i < _playerHand.Count; i++)
        {
            Debug.Log("Player Hand Card: " + _playerHand.GetCard(i).Name);
        }
    }

    public void PlayTopCard()
    {
        AbilityCard targetCard = _playerHand.TopItem;
        targetCard.Play();
        //TODO consider expanding Remove to accept a deck position
        _playerHand.Remove(_playerHand.LastIndex);
        _abilityDiscard.Add(targetCard);
        //Update card on hand
        if(_playerHand.Count <= 0)
        {
            CardSlot.SetActive(true);
        }
        else
        {
            AbilityCard nextCard = _playerHand.TopItem;
            _abilityCardView.Display(nextCard);
        }

        //Update discard pile with card
        _discardCardView.Display(targetCard);
        Debug.Log("Card added to discard: " + targetCard.Name);
    }
}
