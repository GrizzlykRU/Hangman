using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

namespace Hangman.Scripts
{

    public class LetterList : MonoBehaviour
    {
        [SerializeField] private LetterItem letterTemplate;
        [SerializeField] private UnityEvent onWrongGuess;
        [SerializeField] private UnityEvent<bool> onAllLettersGuessed;

        private List<char> guessedLetters = new();
        private List<LetterItem> allLetters = new();

        public void Init(string word)
        {
            Reset();
            foreach (var letter in word.ToCharArray())
            {
                var letterItem = Instantiate(letterTemplate, transform);
                letterItem.Init(letter);
                letterItem.gameObject.SetActive(true);
                allLetters.Add(letterItem);
            }
        }

        public void GuessLetter(char letter)
        {
            if (!guessedLetters.Contains(letter))
            {
                guessedLetters.Add(letter);
                var letters = allLetters.FindAll(x => x.Letter == letter);
                if (letters.Count == 0)
                {
                    onWrongGuess.Invoke();
                }
                else
                {
                    foreach (var item in letters)
                    {
                        item.SetLetterGuessed();
                    }
                    if (allLetters.All(x => x.LetterGuessed))
                    {
                        onAllLettersGuessed.Invoke(true);
                    }
                }
            }
        }

        private void Reset()
        {
            guessedLetters.Clear();
            foreach (var letter in allLetters)
            {
                Destroy(letter.gameObject);
            }
            allLetters.Clear();
        }
    }
}
