using System;
using System.Collections.Generic;
using System.Text;
public class Scripture
{
    private Reference _reference;

    public List<Word> _words;

    public Scripture (Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        foreach (string word in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            _words.Add(new Word(word));
        }
    }
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int hiddenCount = 0;
        while (hiddenCount < numberToHide)
    {
        int wordIndex = random.Next(_words.Count);
        if (!_words[wordIndex].IsHidden())
        {
            _words[wordIndex].Hide();
            hiddenCount++; 
        }
    }
    }
    public string GetDisplayText()
    {
        StringBuilder displayText = new StringBuilder();
        displayText.AppendLine(_reference.GetDisplayText());
        foreach (Word word in _words)
        {
            displayText.Append(word.GetDisplayText() + " ");
        }
        return displayText.ToString().Trim();
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