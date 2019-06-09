using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class Scale {
    
    private string scale;
    private List<int> majorScale;

    public Scale(){
        //Major Scale
        majorScale = new List<int>();
        majorScale.Add(16);
        majorScale.Add(18);
        majorScale.Add(20);
        majorScale.Add(22);
        majorScale.Add(24);
        majorScale.Add(27);
        majorScale.Add(31);
    }

    public void setScale(string scale) {
        this.scale = scale;
    }

    public int approxByScale(float frequency) {
        return approxByMajorScale(frequency);
    }

    private int approxByMajorScale(float frequency) {
        List<float> vs = new List<float>();
        foreach(int baseNote in majorScale) {
            float f = frequency % baseNote;
            vs.Add(f);
        }
        int index = vs.IndexOf(vs.Min());
        int finalBaseNote = majorScale[index];

        int scaleFactor = ((int) (frequency / finalBaseNote)) + 1;
        return finalBaseNote * scaleFactor;
    }
}
