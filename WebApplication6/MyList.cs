namespace WebApplication6
{
    public enum SortMethod: int
    {
        lenghtUp = 0,
        lenghtDown = 1,
        reverse = 2
    }

    public class MyList
    {
        public string[] Words { get; set; }
        public SortMethod SortMethod { get; set; }

        public MyList(string words, SortMethod _sort, char separator)
        {
            SortMethod = _sort;
            Words = SplitText(words, separator);
            
        }

        public void Sort()
        {
            switch (SortMethod)
            {
                case SortMethod.lenghtUp:
                    BubleSort(Words);
                    break;

                case SortMethod.lenghtDown:
                    BubleSort(Words, true);
                    break;

                case SortMethod.reverse:
                    Reverse();
                    break;
            }
        }

        public string[] SplitText(string text, char separator)
        {
            return text.Split(separator);
        }

        private void BubleSort(string[] words, bool reverse = false)
        {
            string temp;

            for (int i = 0; i <= words.Length - 2; i++)
                for (int j = 0; j <= words.Length - 2; j++)
                {
                    if (words[j].Length > words[j + 1].Length)
                    {
                        temp = words[j];
                        words[j] = words[j + 1];
                        words[j + 1] = temp;
                    }
                }

            if (reverse) Reverse();
        }

        public string ToString(char separator)
        {
            return string.Join(separator, Words);
        }

        public void Reverse()
        {
            string temp;
            for(int i = 0; i < Words.Length / 2; i++)
            {
                temp = Words[Words.Length - i - 1];
                Words[Words.Length - i - 1] = Words[i];
                Words[i] = temp;
            }
        }
        
    }


}
