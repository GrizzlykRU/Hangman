using System.Collections.Generic;
using UnityEngine;

namespace Hangman.Scripts
{

    public class Keyboard : MonoBehaviour
    {
        [SerializeField] private KeyboardItem keyboardTemplate;

        public void Init(string alphabet)
        {
            foreach (var letter in alphabet.ToCharArray())
            {
                var keyboardItem = Instantiate(keyboardTemplate, transform);
                keyboardItem.Init(letter);
                keyboardItem.gameObject.SetActive(true);
            }
        }
    }
}
