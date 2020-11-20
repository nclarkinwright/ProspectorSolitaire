using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An enum defines a variable type with a few prenamed values
public enum eCardState
{
    drawpile,
    tableau,
    target,
    discard
}

public class CardProspector : Card
{
    [Header("Set Dynamicaly: CardProspector")]
    // This is how you use the enum eCardState
    public eCardState state = eCardState.drawpile;
    // The hiddenBy list stores which other cards will keep this one face down
    public List<CardProspector> hiddenBy = new List<CardProspector>();
    // The layoutID matches this card to the tableau XML if it's a tableau card
    public int layoutID;
    // The SlotDef class stores information pulled in from the LayoutXML <slot>
    public SlotDef slotDef;

    // This allows the card to react to being clicked
    public override void OnMouseUpAsButton()
    {
        // Call the CardClicked method on the Prospector singleton
        Prospector.S.CardClicked(this);
        // Also call the base class (Card.cs) version of this method
        base.OnMouseUpAsButton();
    }

    // Make CardProspector a Gold CardProspector
    public void MakeGoldCard()
    {
        // Make card front gold
        GameObject cpFront = this.transform.Find("Card_Front").gameObject;
        SpriteRenderer frontSR = cpFront.GetComponent<SpriteRenderer>();
        frontSR.sprite = Prospector.S.deck.cardFrontGold;
        
        // Set card back to gold
        SpriteRenderer cpBack = this.back.GetComponent<SpriteRenderer>();
        cpBack.sprite = Prospector.S.deck.cardBackGold;
        
        // Return when finished
        //return (cp);
    }

}
