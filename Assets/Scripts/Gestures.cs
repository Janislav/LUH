using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Leap;

public class Gestures {
    
    public bool isFist(Hand hand) {
        if (!hand.Fingers[0].IsExtended && !hand.Fingers[1].IsExtended &&
            !hand.Fingers[2].IsExtended && !hand.Fingers[3].IsExtended &&
            !hand.Fingers[4].IsExtended) {
            return true;
        } else {
            return false;
        }
    }

    public bool isPointer(Hand hand) {
        if (!hand.Fingers[0].IsExtended && hand.Fingers[1].IsExtended &&
            !hand.Fingers[2].IsExtended && !hand.Fingers[3].IsExtended &&
            !hand.Fingers[4].IsExtended)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isPeace(Hand hand) {
        if (!hand.Fingers[0].IsExtended && hand.Fingers[1].IsExtended &&
    hand.Fingers[2].IsExtended && !hand.Fingers[3].IsExtended &&
    !hand.Fingers[4].IsExtended)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isThumpAndPointer(Hand hand) {
        if ( hand.Fingers[0].IsExtended && hand.Fingers[1].IsExtended &&
            !hand.Fingers[2].IsExtended && !hand.Fingers[3].IsExtended &&
            !hand.Fingers[4].IsExtended)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}