using DG.Tweening;
using GoogleFu;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardAction : Card {

    public bool canTargetEnemyPlayer = false;
    public bool canTargetAllies = false;
	public bool canTargetSelf = false;
	public bool canTargetActors = false;

	

    protected override void init(){
        base.init();
        cardType = CardType.Action;
    }

	
    public override bool isValidTarget(Target t) {
	    return effect.IsValidTarget(t);
    }

	[RPC]
	protected override void useOnRPC(int viewID) {

		Target t = PhotonView.Find(viewID).GetComponent<Target>();


		SoundManager.Instance.PlayCardFlip();

		show();

		destroy();

		owner.IncreaseCorruption(corruptionCost);
		owner.IncreaseSexisme(sexismeCost);


		t.transform.DOShakeScale(0.5f, .5f);

		effect.OnActionPerformed(t);

		
	}

}