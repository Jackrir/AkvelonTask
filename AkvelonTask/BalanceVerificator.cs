using System;
using System.Collections.Generic;

namespace AkvelonTask
{
    public class BalanceVerificator
    {
        private int GradationRoundBracket {get;set;}
        private List<int> IndexOpenRoundBracket { get; set; }
        private int GradationBraces { get; set; }
        private List<int> IndexOpenBraces { get; set; }
        private int GradationSquareBracket { get; set; }
        private List<int> IndexOpenSquareBracket { get; set; }

        private List<Bracket> lastOpenBracket { get; set; }

        public BalanceVerificator() {

            GradationRoundBracket = 0;
            GradationBraces = 0;
            GradationSquareBracket = 0;
            IndexOpenRoundBracket = new List<int>();
            IndexOpenRoundBracket.Add(-1);
            IndexOpenBraces = new List<int>();
            IndexOpenBraces.Add(-1);
            IndexOpenSquareBracket = new List<int>();
            IndexOpenSquareBracket.Add(-1);
            lastOpenBracket = new List<Bracket>();
        }

        public int IsBalancedBracketsString(string bracketsString) {

            int i = 0;
            foreach(char bracket in bracketsString) {

                Bracket typeBracket;
                if (!UpdateGradationData(bracket, i, out typeBracket))

                    return -2;
                int validationGradationCloseBracketResult = IsValidGradationCloseBracket(i, typeBracket);
                if (validationGradationCloseBracketResult != -1)

                    return validationGradationCloseBracketResult;
                i++;
            }
            int validationGradationOpenBracketResult = IsValidGradationOpenBracket();
            if (validationGradationOpenBracketResult != -1)

                return validationGradationOpenBracketResult;
            return -1;

        }

        private bool UpdateGradationData(char bracket, int index, out Bracket typeBracket) {

            switch (bracket) {

                case '(':
                    GradationRoundBracket++;
                    IndexOpenRoundBracket.Add(index);
                    lastOpenBracket.Add(Bracket.RoundBracketOpen);
                    typeBracket = Bracket.RoundBracketOpen;
                    return true;
                case ')':
                    GradationRoundBracket--;
                    typeBracket = Bracket.RoundBracketClose;
                    return true;
                case '{':
                    GradationBraces++;
                    IndexOpenBraces.Add(index);
                    lastOpenBracket.Add(Bracket.BracesOpen);
                    typeBracket = Bracket.BracesOpen;
                    return true;
                case '}':
                    GradationBraces--;
                    typeBracket = Bracket.BracesClose;
                    return true;
                case '[':
                    GradationSquareBracket++;
                    IndexOpenSquareBracket.Add(index);
                    lastOpenBracket.Add(Bracket.SquareBracketOpen);
                    typeBracket = Bracket.SquareBracketOpen;
                    return true;
                case ']':
                    GradationSquareBracket--;
                    typeBracket = Bracket.SquareBracketClose;
                    return true;
                default:
                    Console.WriteLine("A character ‘{0}’ doesn’t belong to any known brackets type, returns IllegalArgumentException.", bracket);
                    typeBracket = Bracket.RoundBracketOpen;
                    return false;
            }
        }

        private int IsValidGradationCloseBracket(int i, Bracket lastTypeBracket) {

            if (GradationBraces < 0 || GradationRoundBracket < 0 || GradationSquareBracket < 0)

                return i;
            if(IsClosedBracket(lastTypeBracket)) {

                if (lastOpenBracket[lastOpenBracket.Count - 1] != lastTypeBracket - 3)

                    return LasterOpenIndexBracket();
                else {
                    lastOpenBracket.RemoveAt(lastOpenBracket.Count - 1);
                    DeleteLastOpenIndex(lastTypeBracket - 3);
                }
            }

            return -1;
        }

        private int IsValidGradationOpenBracket() {

            if (GradationBraces > 0 || GradationRoundBracket > 0 || GradationSquareBracket > 0) {

                if (GradationRoundBracket > 0)

                    return IndexOpenRoundBracket[IndexOpenRoundBracket.Count - 1];
                else if (GradationBraces > 0)
                    return IndexOpenBraces[IndexOpenBraces.Count - 1];
                else
                    return IndexOpenSquareBracket[IndexOpenSquareBracket.Count - 1];
            }
            return -1;
        }

        private int LasterOpenIndexBracket() {

            if (IndexOpenRoundBracket[IndexOpenRoundBracket.Count - 1] > IndexOpenBraces[IndexOpenBraces.Count - 1] 
                && IndexOpenRoundBracket[IndexOpenRoundBracket.Count - 1] > IndexOpenSquareBracket[IndexOpenSquareBracket.Count - 1])

                return IndexOpenRoundBracket[IndexOpenRoundBracket.Count - 1];
            else if (IndexOpenBraces[IndexOpenBraces.Count - 1] > IndexOpenRoundBracket[IndexOpenRoundBracket.Count - 1] 
                && IndexOpenBraces[IndexOpenBraces.Count - 1] > IndexOpenSquareBracket[IndexOpenSquareBracket.Count - 1])
                return IndexOpenBraces[IndexOpenBraces.Count - 1];
            else
                return IndexOpenSquareBracket[IndexOpenSquareBracket.Count - 1];
        }

        private bool IsClosedBracket(Bracket bracket) {

            if (bracket > Bracket.SquareBracketOpen)

                return true;
            else
                return false;
        }

        private void DeleteLastOpenIndex(Bracket bracket)
        {
            switch (bracket) {

                case Bracket.RoundBracketOpen:
                    IndexOpenRoundBracket.RemoveAt(IndexOpenRoundBracket.Count - 1);
                    break;
                case Bracket.BracesOpen:
                    IndexOpenBraces.RemoveAt(IndexOpenBraces.Count - 1);
                    break;
                case Bracket.SquareBracketOpen:
                    IndexOpenSquareBracket.RemoveAt(IndexOpenSquareBracket.Count - 1);
                    break;
            }
        }

        public enum Bracket {

            RoundBracketOpen = 1,
            BracesOpen,
            SquareBracketOpen,
            RoundBracketClose,
            BracesClose,
            SquareBracketClose

        }
    }
}
