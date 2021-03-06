using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Player : Target {

    public RectTransform handPos;
    public RectTransform boardPos;
	public RectTransform deckPos;

	public RectTransform graveyardPos;


	private const int MaxCardsInHand = 6;
	public int reputation = 30;
    public int corruption = 0;
    public int sexisme = 0;

    public List<Card> deck;
    public List<Card> hand;
    public List<Card> board;

	public Board boardUI;

	public Card HoveredCard = null;

	public const int cardWidth = 136;
	// Use this for initialization

    protected override void init(){
		base.init();
        TargetType = TargetType.Player;
    }

	public void ClearAll() {
		foreach (var card in hand) {
			card.transform.localScale = Vector3.zero;
		}
		foreach (var card in deck) {
			card.transform.localScale = Vector3.zero;
		}
		foreach (var card in board) {
			card.transform.localScale = Vector3.zero;
		}

		foreach (Transform card in graveyardPos.transform) {
			card.localScale = Vector3.zero;
		}

		hand.Clear();
		deck.Clear();
		board.Clear();
	}


    public void OnTurnStart()
    {
        Draw();
		
        foreach(Card c in board){
            //c.selectable.interactable = true;
			c.OnTurnStart();
        }
		/*foreach (Card c in hand){
           // c.selectable.interactable = true;
        }*/
		ResetOutlines(GameManager.instance.offlineMode || GameManager.instance.localPlayerTurn);
	    //boardUI.selectable.interactable = true;
    }

    public void OnTurnEnd()
    {
		ResetOutlines(false);
        foreach (Card c in board){
            //c.selectable.interactable = false;
			c.OnTurnEnd();
        }
        /*foreach (Card c in hand){
            //c.selectable.interactable = false;
        }*/
		//boardUI.selectable.interactable = false;
    }

	public void MoveToBoard(Card c) {
		photonView.RPC("MoveToBoardRPC", PhotonTargets.AllBuffered, c.photonView.viewID);
	}

	[RPC]
	void MoveToBoardRPC(int viewID) {
		var c = PhotonView.Find(viewID).GetComponent<Card>();

		if (!hand.Contains(c))
			return;

		hand.Remove(c);
		board.Add(c);
		c.owner.IncreaseCorruption(c.corruptionCost);
		c.owner.IncreaseSexisme(c.sexismeCost);
		c.place = Place.Board;
		c.effect.OnPlacedOnBoard();
		SoundManager.Instance.PlayCardSlide();
	}

	public void MoveToHand(CardActor actor) {
		if (!board.Contains(actor))
			return;

		SoundManager.Instance.PlayCardSlide();
		if (hand.Count >= MaxCardsInHand) {
			actor.destroy();
			return;
		}
		board.Remove(actor);
		hand.Add(actor);
		actor.place = Place.Hand;
		actor.attack = actor.baseAttack;
		actor.reputation = actor.baseReputation;
		actor.canAttack = false;
		actor.preventAttack = false;

		var outline = actor.GetComponent<Outline>();
		var color = outline.effectColor;
		color.a = 0;
		outline.effectColor = color;


	}

	public void DrawRPC(int times = 1) {
		photonView.RPC("Draw", PhotonTargets.AllBuffered, times);
	}

	[RPC]
    public void Draw(int times = 1) {

		
        if (times < 1) {
            return;
        }
        if (deck.Count == 0)
			ChangeReputation(-times);
        else{
            if (hand.Count < MaxCardsInHand) {

				if (this != GameManager.instance.localPlayer && !GameManager.instance.offlineMode)
					return;

                Card card = deck[Random.Range(0, deck.Count-1)];
				deck.Remove(card);
				hand.Add(card);
				card.place = Place.Hand;
				card.effect.OnDraw();
	            card.show();
				SoundManager.Instance.PlayCardPlace();
				photonView.RPC("HasDrawn", PhotonTargets.OthersBuffered, card.photonView.viewID);

                Draw(times - 1);
            }
        }
    }

	[RPC]
	void HasDrawn(int viewId) {
		var card = PhotonView.Find(viewId).GetComponent<Card>();
		deck.Remove(card);
		hand.Add(card);
		card.place = Place.Hand;
		card.effect.OnDraw();
		SoundManager.Instance.PlayCardPlace();
	}

    void Update() {
        DisplayDeck();
        DisplayHand();
        DisplayBoard();
    }

	public void OutlinePossibleTargets(Card c) {

		Player p2 = GameManager.instance.getOtherPlayer(this);

		Outline outline;
		Color col;
		foreach (var card in board) {
			outline = card.GetComponent<Outline>();
			col = outline.effectColor;
			col.a = c.isValidTarget(card) ? 255 : 0;
			outline.effectColor = col;
		}
		foreach (var card in p2.board) {
			outline = card.GetComponent<Outline>();
			col = outline.effectColor;
			col.a = c.isValidTarget(card) ? 255 : 0;
			outline.effectColor = col;
		}
		foreach (var card in hand) {
			outline = card.GetComponent<Outline>();
			col = outline.effectColor;
			col.a = card == GameManager.instance.cardSelected ? 255 : 0;
			outline.effectColor = col;
		}


		outline = GameObject.Find("Context").GetComponent<Outline>();
		col = outline.effectColor;
		col.a = c.cardType == CardType.Context ? 255 : 0;
		outline.effectColor = col;
		
		outline = GetComponent<Outline>();
		col = outline.effectColor;
		col.a = c.isValidTarget(this) ? 255 : 0;
		outline.effectColor = col;
		
		outline = p2.GetComponent<Outline>();
		col = outline.effectColor;
		col.a = c.isValidTarget(p2) ? 255 : 0;
		outline.effectColor = col;

	}

	public void ResetOutlines(bool outlinePossibilities) {
		Player p2 = GameManager.instance.getOtherPlayer(this);

		Outline outline;
		Color col;
		foreach (var card in board) {
			outline = card.GetComponent<Outline>();
			col = outline.effectColor;
			col.a = ((CardActor) card).canAttack && outlinePossibilities ? 255 : 0;
			outline.effectColor = col;
		}
		foreach (var card in p2.board) {
			outline = card.GetComponent<Outline>();
			col = outline.effectColor;
			col.a = 0;
			outline.effectColor = col;
		}
		foreach (var card in hand) {
			outline = card.GetComponent<Outline>();
			col = outline.effectColor;
			col.a = outlinePossibilities ? 255:0;
			outline.effectColor = col;
		}

		outline = GameObject.Find("Context").GetComponent<Outline>();
		col = outline.effectColor;
		col.a = 0;
		outline.effectColor = col;
		

		outline = GetComponent<Outline>();
		col = outline.effectColor;
		col.a = 0;
		outline.effectColor = col;

		outline = p2.GetComponent<Outline>();
		col = outline.effectColor;
		col.a = 0;
		outline.effectColor = col;
	}

    public void DisplayDeck()
    {
        foreach (var card in deck)
        {
			if(card.InAnimation) continue;
			card.transform.SetParent(deckPos);
            card.transform.localPosition = new Vector3(0, 0, 0);
            card.hide();
        }
    }

    public void DisplayHand() {
		

	    var offsetX = Mathf.Min(handPos.rect.width/hand.Count, cardWidth);
		var offset = new Vector3(offsetX , 0,0);
		var pos = handPos.position + new Vector3((-hand.Count/2) * offsetX,0,0);
	    //pos += offset/2;

	    if (HoveredCard) {
		    if(HoveredCard.place == Place.Hand)
				pos -= offset / 10f;
	    }
		    

        foreach (var card in hand) {

	        var tr = card.GetComponent<RectTransform>();
			tr.SetParent(handPos);

	        if (HoveredCard == card)
				pos += offset/10f;

			if (transform.position != pos && !card.InAnimation) {
				card.InAnimation = true;
				var card1 = card;
				card.transform.DOMove(pos, 0.5f).OnComplete(() => { card1.InAnimation = false; }).SetEase(Ease.OutCubic);
			}

			if (HoveredCard == card)
				pos += offset/10f;

	        pos += offset;

	        if (GameManager.instance.offlineMode) {
		        if (GameManager.instance.activePlayer() == this)
					card.show();
				else
			        card.hide();
	        }else{
		        if (GameManager.instance.localPlayer == this) 
					card.show();
		        else {
					card.hide();
		        }
		        
	        }
        }
		

		if (GameManager.instance.cardSelected )
			GameManager.instance.cardSelected.transform.SetAsLastSibling();

		if (HoveredCard) {
			HoveredCard.transform.SetAsLastSibling();
		}

    }

    public void DisplayBoard() {
        Vector3 pos = boardPos.position + new Vector3(-cardWidth * board.Count / 2, 0, 0);
        var offset = new Vector3(cardWidth, 0, 0);
        foreach (var card in board) {

	        
		        card.transform.SetParent(GameObject.Find("Cards").transform);
		        if (card.transform.position != pos && !card.InAnimation) {
			        card.InAnimation = true;
			        var card1 = card;
					card.transform.DOMove(pos, 0.5f).SetEase(Ease.OutCubic).OnComplete(() => { card1.InAnimation = false; });
		        }
	        
	        pos += offset;
			card.show();
        }
    }

	public void ChangeReputation(int value)
    {
        reputation = Mathf.Clamp(reputation + value,0,30);

		var color = "green";
		if (value < 0) {
			color = "maroon";
			Shake();
		}

		var go = (GameObject)Instantiate(Resources.Load("FloatingText"), transform.position, Quaternion.identity);
		go.GetComponent<Text>().text = "<color=" + color + ">" + value + "</color>";

		if (reputation == 0)
        {
            GameManager.instance.playerDied(this);
        }
    }


    public bool IsInHand(Card c) {
        return hand.Contains(c);   
    }

    public bool IsInDeck(Card c) {
        return deck.Contains(c);
    }

    public void ShuffleDeck() {
        // TODO SHUFFLE DECK
    }

    public void IncreaseCorruption(int cost) {
        if (GameManager.instance.contextCard) {
            cost = (int)(cost * GameManager.instance.contextCard.corruptionMultiplier);
        }
        corruption += cost;
    }
    public void IncreaseSexisme(int cost) {
        if (GameManager.instance.contextCard) {
            cost = (int)(cost * GameManager.instance.contextCard.sexismeMultiplier);
        }
        sexisme += cost;
    }

    public void RemoveCard(Card c)
    {
        if (hand.Contains(c))
            hand.Remove(c);
        if (board.Contains(c))
            board.Remove(c);
        if (deck.Contains(c))
            deck.Remove(c);
    }


	public void Discard(Card c) {
		if (c.owner != this || c.place != Place.Hand) return;
		photonView.RPC("DiscardRPC", PhotonTargets.AllBuffered, c.photonView.viewID);
	}

	public void Discard(int nb) {

		if (this != GameManager.instance.localPlayer && !GameManager.instance.offlineMode)
			return;

		if (nb > hand.Count)
			nb = hand.Count;

		for (var i = 0; i < nb; i++) {
			var n = Random.Range(0, hand.Count - 1);
			photonView.RPC("DiscardRPC", PhotonTargets.AllBuffered, hand[n].photonView.viewID);
		}


	}
	[RPC]
	void DiscardRPC(int viewId) {
		PhotonView.Find(viewId).GetComponent<Card>().destroy(true);
	}

	public void Swap() {
		
		var other = GameManager.instance.getOtherPlayer(this);

		var old = other.handPos.position;
		other.handPos.position = handPos.position;
		handPos.position = old;


		old = other.boardPos.position;
		other.boardPos.position = boardPos.position;
		boardPos.position = old;

		old = other.deckPos.position;
		other.deckPos.position = deckPos.position;
		deckPos.position = old;

		other.graveyardPos.anchorMin = new Vector2(0,1);
		other.graveyardPos.anchorMax = new Vector2(0, 1);

		var tr = other.graveyardPos.GetChild(0).GetComponent<RectTransform>();
		tr.anchoredPosition = new Vector2(tr.anchoredPosition.x, -tr.anchoredPosition.y);
		tr = graveyardPos.GetChild(0).GetComponent<RectTransform>();
		tr.anchoredPosition = new Vector2(tr.anchoredPosition.x, -tr.anchoredPosition.y);

		graveyardPos.anchorMin = Vector2.zero;
		graveyardPos.anchorMax = Vector2.zero;
		old = other.graveyardPos.anchoredPosition;
		other.graveyardPos.anchoredPosition = graveyardPos.anchoredPosition;
		graveyardPos.anchoredPosition = old;
		


		other.GetComponent<RectTransform>().anchorMin = Vector2.one;
		other.GetComponent<RectTransform>().anchorMax = Vector2.one;
		GetComponent<RectTransform>().anchorMin = Vector2.zero;
		GetComponent<RectTransform>().anchorMax = Vector2.zero;
		old = other.GetComponent<RectTransform>().anchoredPosition;
		other.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
		GetComponent<RectTransform>().anchoredPosition = old;
		



		var stats = transform.FindChild("Stats");
		old = stats.localPosition;
		old.x = -old.x;
		stats.localPosition = old;

		stats = other.transform.FindChild("Stats");
		old = stats.localPosition;
		old.x = -old.x;
		stats.localPosition = old;

	}
}
