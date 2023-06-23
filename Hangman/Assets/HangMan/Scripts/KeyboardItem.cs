using UnityEngine;
using UnityEngine.Events;

namespace Hangman.Scripts
{

    public class KeyboardItem : MonoBehaviour
    {
        [SerializeField] private UnityEvent<string> updateLetter;
        [SerializeField] private LetterList letterList;
        private char letter;

        public void Init(char letter)
        {
            this.letter = letter;
            updateLetter.Invoke(letter.ToString().ToUpper());
        }

        public void OnClick()
        {
            letterList.GuessLetter(letter);
        }
    }
}
