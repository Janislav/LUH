using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class Scale {
    
    private List<string> cMajorScale;
    private List<string> bMajorScale;
    private List<string> activeScale;
    private List<Note> notes;

    public Scale(){

        activeScale = new List<string>();
        notes = new List<Note>();

        //Major Scale
        cMajorScale = new List<string>();

        cMajorScale.Add("C");
        cMajorScale.Add("D");
        cMajorScale.Add("E");
        cMajorScale.Add("F");
        cMajorScale.Add("G");
        cMajorScale.Add("A");

        bMajorScale = new List<string>();

        bMajorScale.Add("B");
        bMajorScale.Add("C#");
        bMajorScale.Add("D#");
        bMajorScale.Add("E");
        bMajorScale.Add("F#");
        bMajorScale.Add("G#");
        bMajorScale.Add("A#");

        notes.Add(new Note(21, 0, "A"));
        notes.Add(new Note(22, 0, "A#"));
        notes.Add(new Note(23, 0, "B"));

        notes.Add(new Note(24, 1, "C"));
        notes.Add(new Note(25, 1, "C#"));
        notes.Add(new Note(26, 1, "D"));
        notes.Add(new Note(27, 1, "D#"));
        notes.Add(new Note(28, 1, "E"));
        notes.Add(new Note(29, 1, "F"));
        notes.Add(new Note(30, 1, "F#"));
        notes.Add(new Note(31, 1, "G"));
        notes.Add(new Note(32, 1, "G#"));
        notes.Add(new Note(33, 1, "A"));
        notes.Add(new Note(34, 1, "A#"));
        notes.Add(new Note(35, 1, "B"));

        notes.Add(new Note(36, 2, "C"));
        notes.Add(new Note(37, 2, "C#"));
        notes.Add(new Note(38, 2, "D"));
        notes.Add(new Note(39, 2, "D#"));
        notes.Add(new Note(40, 2, "E"));
        notes.Add(new Note(41, 2, "F"));
        notes.Add(new Note(42, 2, "F#"));
        notes.Add(new Note(43, 2, "G"));
        notes.Add(new Note(44, 2, "G#"));
        notes.Add(new Note(45, 2, "A"));
        notes.Add(new Note(46, 2, "A#"));
        notes.Add(new Note(47, 2, "B"));

        notes.Add(new Note(48, 3, "C"));
        notes.Add(new Note(49, 3, "C#"));
        notes.Add(new Note(50, 3, "D"));
        notes.Add(new Note(51, 3, "D#"));
        notes.Add(new Note(52, 3, "E"));
        notes.Add(new Note(53, 3, "F"));
        notes.Add(new Note(54, 3, "F#"));
        notes.Add(new Note(55, 3, "G"));
        notes.Add(new Note(56, 3, "G#"));
        notes.Add(new Note(57, 3, "A"));
        notes.Add(new Note(58, 3, "A#"));
        notes.Add(new Note(59, 3, "B"));

        notes.Add(new Note(60, 4, "C"));
        notes.Add(new Note(61, 4, "C#"));
        notes.Add(new Note(62, 4, "D"));
        notes.Add(new Note(63, 4, "D#"));
        notes.Add(new Note(64, 4, "E"));
        notes.Add(new Note(65, 4, "F"));
        notes.Add(new Note(66, 4, "F#"));
        notes.Add(new Note(67, 4, "G"));
        notes.Add(new Note(68, 4, "G#"));
        notes.Add(new Note(69, 4, "A"));
        notes.Add(new Note(70, 4, "A#"));
        notes.Add(new Note(71, 4, "B"));

        notes.Add(new Note(72, 5, "C"));
        notes.Add(new Note(73, 5, "C#"));
        notes.Add(new Note(74, 5, "D"));
        notes.Add(new Note(75, 5, "D#"));
        notes.Add(new Note(76, 5, "E"));
        notes.Add(new Note(77, 5, "F"));
        notes.Add(new Note(78, 5, "F#"));
        notes.Add(new Note(79, 5, "G"));
        notes.Add(new Note(80, 5, "G#"));
        notes.Add(new Note(81, 5, "A"));
        notes.Add(new Note(82, 5, "A#"));
        notes.Add(new Note(83, 5, "B"));

        notes.Add(new Note(84, 6, "C"));
        notes.Add(new Note(85, 6, "C#"));
        notes.Add(new Note(86, 6, "D"));
        notes.Add(new Note(87, 6, "D#"));
        notes.Add(new Note(88, 6, "E"));
        notes.Add(new Note(89, 6, "F"));
        notes.Add(new Note(90, 6, "F#"));
        notes.Add(new Note(91, 6, "G"));
        notes.Add(new Note(92, 6, "G#"));
        notes.Add(new Note(93, 6, "A"));
        notes.Add(new Note(94, 6, "A#"));
        notes.Add(new Note(95, 6, "B"));

        notes.Add(new Note(96, 7, "C"));
        notes.Add(new Note(97, 7, "C#"));
        notes.Add(new Note(98, 7, "D"));
        notes.Add(new Note(99, 7, "D#"));
        notes.Add(new Note(100, 7, "E"));
        notes.Add(new Note(101, 7, "F"));
        notes.Add(new Note(102, 7, "F#"));
        notes.Add(new Note(103, 7, "G"));
        notes.Add(new Note(104, 7, "G#"));
        notes.Add(new Note(105, 7, "A"));
        notes.Add(new Note(106, 7, "A#"));
        notes.Add(new Note(107, 7, "B"));

        notes.Add(new Note(108, 8, "C"));
        notes.Add(new Note(109, 8, "C#"));
        notes.Add(new Note(110, 8, "D"));
        notes.Add(new Note(111, 8, "D#"));
        notes.Add(new Note(112, 8, "E"));
        notes.Add(new Note(113, 8, "F"));
        notes.Add(new Note(114, 8, "F#"));
        notes.Add(new Note(115, 8, "G"));
        notes.Add(new Note(116, 8, "G#"));
        notes.Add(new Note(117, 8, "A"));
        notes.Add(new Note(118, 8, "A#"));
        notes.Add(new Note(119, 8, "B"));

        notes.Add(new Note(120, 9, "C"));
        notes.Add(new Note(121, 9, "C#"));
        notes.Add(new Note(122, 9, "D"));
        notes.Add(new Note(123, 9, "D#"));
        notes.Add(new Note(124, 9, "E"));
        notes.Add(new Note(125, 9, "F"));
        notes.Add(new Note(126, 9, "F#"));
        notes.Add(new Note(127, 9, "G"));
    }

    public int getNextNoteInKey(int midiNote) {

        if (midiNote < 21) midiNote = 21;
        if (midiNote > 127) midiNote = 127;

        Note note = notes.Find(i => i.getMidiNumber() == midiNote);
        bool foundNote;
        Note tempNote;
        int foundInUp = 0;
        int foundInDown = 0;

        //0 -> look in down and up take what is closer
        int lookUpMode = 0;
        //1 -> look in up
        if(note.getOctave() <= 1) lookUpMode = 1;
        //2 -> look in down
        if (note.getOctave() >= 9) lookUpMode = 2;

        tempNote = note;
        foundNote = false;
        int upWay = 0;

        //UP
        while(!foundNote && (lookUpMode == 0 || lookUpMode == 1)) {
            if(activeScale.Contains(tempNote.getNote())) {
                foundNote = true;
                foundInUp = tempNote.getMidiNumber();
                upWay++;
            } else {
                tempNote = notes.Find(i => i.getMidiNumber() == tempNote.getMidiNumber() + 1);
            }
        }

        tempNote = note;
        foundNote = false;
        int downWay = 0;

        //DOWN
        while (!foundNote && (lookUpMode == 0 || lookUpMode == 2)) {
            if (activeScale.Contains(tempNote.getNote())) {
                foundNote = true;
                foundInDown = tempNote.getMidiNumber();
                downWay++;
            } else {
                tempNote = notes.Find(i => i.getMidiNumber() == tempNote.getMidiNumber() - 1);
            }
        }

        if(lookUpMode == 0) 
            if (upWay < downWay) return foundInUp; else return foundInDown;

        if (lookUpMode == 1) return foundInUp;
        if (lookUpMode == 2) return foundInDown;

        return 0;
    }

    public void setScale(string scale) {
        if(scale.Equals("CMajor")) {
            activeScale = cMajorScale;
        }
        if (scale.Equals("BMajor")) {
            activeScale = bMajorScale;
        }
    }

    /** Scales the a input number down to a more midi scale.
    **/
    public int generateNote(int yPos) {
        if(yPos <= 0) {
            return 1;
        }
        int temp = yPos / 5;
        return temp;
    }
}
