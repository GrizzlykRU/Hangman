using System;
using System.Collections.Generic;
using UnityEngine;

namespace Configs.Scripts
{
    [Serializable]
    public struct LocaledWord
    {
        public string language;
        public string word;
    }

    [Serializable]
    public class Word
    {
        public List<LocaledWord> localedWords;
    }

    [CreateAssetMenu(menuName = "Configs/WordsConfig", order = 1)]
    public class WordsConfig : ScriptableObject
    {
        public List<Word> words;

    }
}