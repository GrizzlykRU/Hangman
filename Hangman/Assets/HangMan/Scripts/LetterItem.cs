using UnityEngine;
using UnityEngine.Events;

namespace Hangman.Scripts
{
    public class LetterItem : MonoBehaviour
    {
        [SerializeField] private UnityEvent<string> updateLetter;
        [SerializeField] private UnityEvent onLetterGuessed;
        private bool letterGuessed;
        private char letter;
        
        public bool LetterGuessed => letterGuessed;
        public char Letter => letter;

        public void Init(char letter)
        {
            this.letter = letter;
            updateLetter.Invoke(letter.ToString().ToUpper());
        }

        public void SetLetterGuessed()
        {
            letterGuessed = true;
            onLetterGuessed.Invoke();
        }
    }
}