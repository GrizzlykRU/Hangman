using System.Collections.Generic;
using Configs.Scripts;
using UnityEngine;
using UnityEngine.Localization.Settings;
using Utility;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.Localization.SmartFormat.Extensions;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using Random = UnityEngine.Random;

namespace Hangman.Scripts
{
    public class StateGame : MonoBehaviour
    {
        [SerializeField] private WordsConfig wordsConfig;
        [SerializeField] private LetterList letterList;
        [SerializeField] private Keyboard keyboard;
        [SerializeField] private UnityEvent<bool> onGameOver;
        [SerializeField] private UnityEvent onGameRestart;

        private List<Word> guessedWords = new();
        private Word currentWord;

        private IntVariable victoryVariable;
        private IntVariable defeatVariable;


        private string Locale => LocalizationSettings.SelectedLocale.Identifier.Code;

        private void OnEnable()
        {
            var source = LocalizationSettings
                .StringDatabase
                .SmartFormatter
                .GetSourceExtension<PersistentVariablesSource>();
            victoryVariable = source["global"]["victoryCount"] as IntVariable;
            victoryVariable.Value = 0;
            defeatVariable = source["global"]["defeatCount"] as IntVariable;
            defeatVariable.Value = 0;
            var alphabet = Alphabets.GetAlphabet(Locale);
            keyboard.Init(alphabet);
            Init();
        }

        public void Init()
        {
            var unguessedWords = wordsConfig.words;
            if (guessedWords.Count < wordsConfig.words.Count)
            {
                unguessedWords = wordsConfig.words.Except(guessedWords).ToList();
            }

            var index = Random.Range(0, unguessedWords.Count - 1);
            currentWord = unguessedWords[index];
            letterList.Init(currentWord.localedWords.First(x => x.language == Locale).word);
        }

        public void OnGameOver(bool victory)
        {
            if (victory)
            {
                victoryVariable.Value++;
                if (guessedWords.Count < wordsConfig.words.Count)
                {
                    guessedWords.Add(currentWord);
                }
            }
            else
            {
                defeatVariable.Value++;
            }

            onGameOver.Invoke(victory);
        }

        public void OnGameRestart()
        {
            Init();
            onGameRestart.Invoke();
        }
    }
}