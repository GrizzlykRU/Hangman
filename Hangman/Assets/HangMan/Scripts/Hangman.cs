using System.Collections.Generic;
using Configs.Scripts;
using UnityEngine;
using UnityEngine.Localization.Settings;
using Utility;
using System.Linq;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Hangman.Scripts
{
    public class Hangman : MonoBehaviour
    {
        [SerializeField] private List<GameObject> hangmanSteps;
        [SerializeField] private UnityEvent<bool> onGameOver;
        private int mistakesCount = 0;

        public void OnWrongGuess()
        {
            hangmanSteps[mistakesCount].SetActive(true);
            if (++mistakesCount == hangmanSteps.Count)
            {
                onGameOver.Invoke(false);
            }
        }

        public void Reset()
        {
            mistakesCount = 0;
            foreach (var step in hangmanSteps)
            {
                step.SetActive(false);
            }
        }
    }
}