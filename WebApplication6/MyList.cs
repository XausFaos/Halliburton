namespace WebApplication6
{
    public enum SortMethod: int
    {
        Up = 0,
        Down = 1,
        reverse = 2
    }

    public enum SortType: int
    {
        lenght = 0,
        compareTo = 1
    }

    public class MyList
    {
        public string[] Words { get; set; }
        public SortMethod SortMethod { get; set; }
        public SortType SortType { get; set; }
        public MyList(string words, SortMethod _sort, SortType _type ,char separator)
        {
            SortMethod = _sort;
            SortType = _type;
            
            Words = SplitText(words, separator);
            
        }

        public void Sort()
        {
            switch (SortMethod)
            {
                case SortMethod.Up:
                    BubleSort(Words);
                    break;

                case SortMethod.Down:
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
            string temp = null;

            for (int i = 0; i <= words.Length - 2; i++)
                for (int j = 0; j <= words.Length - 2; j++)
                {
                    switch (SortType)
                    {
                        case SortType.lenght:
                            if (words[j].Length > words[j + 1].Length)
                                temp = words[j];
                            break;

                        case SortType.compareTo:
                            if (words[j].CompareTo(words[j + 1]) > 0)
                                temp = words[j];
                            break;

                        default:
                            temp = null;
                            break;
                    }

                    if (temp != null)
                    {
                        words[j] = words[j + 1];
                        words[j + 1] = temp;
                        temp = null;
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
