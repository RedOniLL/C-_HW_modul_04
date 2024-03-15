using System;

namespace C__HW_modul_04.NewFolder
{
    public class Morze
    {
        private static char[] _letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ".ToCharArray();
        private static string[] _morseCodes = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--..", "-----", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----.", "/" };

        public static string TextToMorse(string text)
        {
            text = text.ToUpper();
            string morse = "";
            foreach (char c in text)
            {
                int index = Array.IndexOf(_letters, c);
                if (index >= 0)
                {
                    morse += _morseCodes[index] + " ";
                }
                else
                {
                    morse += " ";
                }
            }
            return morse.Trim();
        }

        public static string MorseToText(string morse)
        {
            string[] words = morse.Split(new[] { " / " }, StringSplitOptions.RemoveEmptyEntries);
            string text = "";
            foreach (string word in words)
            {
                string[] codes = word.Split(' ');
                foreach (string code in codes)
                {
                    int index = Array.IndexOf(_morseCodes, code);
                    if (index >= 0)
                    {
                        text += _letters[index];
                    }
                }
                text += " ";
            }
            return text.Trim();
        }
    }
}
