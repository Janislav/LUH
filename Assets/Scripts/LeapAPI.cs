using UnityEngine;
using System.Collections;
using Leap;

public class LeapAPI {
    
    private Hand GetHand(HandList hands, string side) {
        if (hands.IsEmpty)
        {
            return null;
        }

        if (hands.Count == 1)
        {
            if(side.Equals("left")) {
                if (hands[0].IsLeft && hands[0].IsValid)
                {
                    return hands[0];
                }
                else
                {
                    return null;
                }
            }

            if(side.Equals("right")) {
                if (hands[0].IsRight && hands[0].IsValid)
                {
                    return hands[0];
                }
                else
                {
                    return null;
                }
            }
        }

        if (hands.Count > 1)
        {
            foreach (Hand hand in hands)
            {
                if(side.Equals("left")) {
                    if (hand.IsLeft && hand.IsValid)
                    {
                        return hand;
                    }
                }
                if (side.Equals("right"))
                {
                    if (hand.IsRight && hand.IsValid)
                    {
                        return hand;
                    }
                }
            }
        }

        return null;
    }

    public Hand GetLeftHand(HandList hands) {
        return GetHand(hands, "left");
    }

    public Hand GetRightHand(HandList hands) {
        return GetHand(hands, "right");
    }
}