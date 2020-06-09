using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;
using System.Collections;
public class DialogViewer 
{
    public DialogViewer() {}
    public IEnumerator ctor(Writer[] texts, FileReader code, DialogParser source)
    {
        Queue<Writer> deactivationQueue;
        int lengthQueue = int.MaxValue;
        var Lines = new List<string[]>();
        
        
        foreach (var line in code.Lines)
        {
            Lines.Add(line.Split(' '));
        }

        for (int i = 0; i < Lines.Count;)
        {
            if (Lines[i].Length == 0 || Lines[i][0] == "")
                Lines.RemoveAt(i);
            else
                i++;
        }

        { 
            if (Lines[0][0].ToLower() != "mode") throw new Exception("first line must contain mode instruction");
            if (Lines[0][1].ToLower() == "u") deactivationQueue = new Queue<Writer>(texts.Length);
            else
            {
                lengthQueue = int.Parse(Lines[0][2].ToLower());
                deactivationQueue = new Queue<Writer>(lengthQueue);
            }

            if (Lines[1][0].ToLower() != "length") throw new Exception("second line must contain length instruction");
            if (int.Parse(Lines[1][1].ToLower()) > texts.Length) throw new Exception();
        }
        yield return new WaitForEndOfFrame();
        Writer currentText = null;
        for (int i = 2; i < Lines.Count; i++)
        {
            switch (Lines[i][0].ToLower())
            {
                case "phrase":
                    if ((currentText) == null)
                    {
                        throw new Exception();
                    }
                    
                    while (currentText.isWriting != 0) yield return new WaitForSeconds(0.01f);
                    yield return currentText.WriteText(source.Phrases[0], Lines[i].Length == 1);
                    source.Phrases.RemoveAt(0);
                    break;

                case "set":
                    currentText = texts[int.Parse(Lines[i][1])];
                    currentText.TurnOn();
                    deactivationQueue.Enqueue(currentText);
                    if (deactivationQueue.Count > lengthQueue && !deactivationQueue.Peek().CurrentGameObject.Equals(currentText.CurrentGameObject))
                    {
                        while (deactivationQueue.Peek().isWriting != 0) yield return new WaitForSeconds(0.01f);
                        deactivationQueue.Dequeue().TurnOff();
                    }
                    break;


            }
        }
    }
}
