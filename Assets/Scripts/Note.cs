using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note
{
    private int midiNumber;
    private int octave;
    private string note;

    public Note(int midiNumber, int octave, string note)
    {
        this.midiNumber = midiNumber;
        this.octave = octave;
        this.note = note;
    }

    public int getMidiNumber()
    {
        return midiNumber;
    }

    public int getOctave()
    {
        return octave;
    }

    public string getNote()
    {
        return note;
    }
}
