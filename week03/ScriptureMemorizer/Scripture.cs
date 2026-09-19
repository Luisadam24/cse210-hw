using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] words = text.Split(' ');

        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + "\n";

        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }

        return result.Trim();
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> availableWords = new List<Word>();

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                availableWords.Add(word);
            }
        }

        int amountToHide = Math.Min(numberToHide, availableWords.Count);

        for (int i = 0; i < amountToHide; i++)
        {
            int randomIndex = _random.Next(availableWords.Count);

            availableWords[randomIndex].Hide();
            availableWords.RemoveAt(randomIndex);
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}