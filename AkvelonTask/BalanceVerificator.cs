using System;
using System.Collections.Generic;

namespace AkvelonTask
{
    public class BalanceVerificator
    {
        private int GradationRoundBracket { get; set; }
        private List<int> IndexOpenRoundBracketList { get; set; }
        private int GradationBraces { get; set; }
        private List<int> IndexOpenBracesList { get; set; }
        private int GradationSquareBracket { get; set; }
        private List<int> IndexOpenSquareBracketList { get; set; }

        private List<Bracket> LastOpenBracket { get; set; }

        public BalanceVerificator() {

            GradationRoundBracket = 0;
            GradationBraces = 0;
            GradationSquareBracket = 0;
            IndexOpenRoundBracketList = new List<int> {
                -1
            };
            IndexOpenBracesList = new List<int> {
                -1
            };
            IndexOpenSquareBracketList = new List<int> {
                -1
            };
            LastOpenBracket = new List<Bracket>();
        }

        public int IsBalancedBracketsString(string bracketsString) {

            int i = 0;
            foreach(char bracket in bracketsString) {

                Bracket typeBracket;
                if (!UpdateGradationData(bracket, i, out typeBracket)) {

                    return -2;
                }
                int validationGradationCloseBracketResult = IsValidGradationCloseBracket(i, typeBracket);
                if (validationGradationCloseBracketResult != -1) {

                    return validationGradationCloseBracketResult + 1;
                }
                i++;
            }
            int validationGradationOpenBracketResult = IsValidGradationOpenBracket();
            if (validationGradationOpenBracketResult != -1) {

                return validationGradationOpenBracketResult + 1;
            }
            return -1;

        }

        private bool UpdateGradationData(char bracket, int index, out Bracket typeBracket) {

            switch (bracket) {

                case '(':
                    GradationRoundBracket++;
                    IndexOpenRoundBracketList.Add(index);
                    LastOpenBracket.Add(Bracket.RoundBracketOpen);
                    typeBracket = Bracket.RoundBracketOpen;
                    return true;

                case ')':
                    GradationRoundBracket--;
                    typeBracket = Bracket.RoundBracketClose;
                    return true;

                case '{':
                    GradationBraces++;
                    IndexOpenBracesList.Add(index);
                    LastOpenBracket.Add(Bracket.BracesOpen);
                    typeBracket = Bracket.BracesOpen;
                    return true;

                case '}':
                    GradationBraces--;
                    typeBracket = Bracket.BracesClose;
                    return true;

                case '[':
                    GradationSquareBracket++;
                    IndexOpenSquareBracketList.Add(index);
                    LastOpenBracket.Add(Bracket.SquareBracketOpen);
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

            if (GradationBraces < 0 || GradationRoundBracket < 0 || GradationSquareBracket < 0) {

                return i;
            }

            if(IsClosedBracket(lastTypeBracket)) {

                if (LastOpenBracket[LastOpenBracket.Count - 1] != lastTypeBracket - 3) {

                    return LasterOpenIndexBracket();
                } else {
                    LastOpenBracket.RemoveAt(LastOpenBracket.Count - 1);
                    DeleteLastOpenIndex(lastTypeBracket - 3);
                }
            }
            return -1;
        }

        private int IsValidGradationOpenBracket() {

            if (GradationBraces > 0 || GradationRoundBracket > 0 || GradationSquareBracket > 0) {

                if (GradationRoundBracket > 0) {

                    return IndexOpenRoundBracketList[IndexOpenRoundBracketList.Count - 1];
                } else if (GradationBraces > 0) {
                    return IndexOpenBracesList[IndexOpenBracesList.Count - 1];
                } else {
                    return IndexOpenSquareBracketList[IndexOpenSquareBracketList.Count - 1];
                }
            }
            return -1;
        }

        private int LasterOpenIndexBracket() {

            if (IndexOpenRoundBracketList[IndexOpenRoundBracketList.Count - 1] > IndexOpenBracesList[IndexOpenBracesList.Count - 1] 
                && IndexOpenRoundBracketList[IndexOpenRoundBracketList.Count - 1] > IndexOpenSquareBracketList[IndexOpenSquareBracketList.Count - 1]) {

                return IndexOpenRoundBracketList[IndexOpenRoundBracketList.Count - 1];
            } else if (IndexOpenBracesList[IndexOpenBracesList.Count - 1] > IndexOpenRoundBracketList[IndexOpenRoundBracketList.Count - 1] 
                && IndexOpenBracesList[IndexOpenBracesList.Count - 1] > IndexOpenSquareBracketList[IndexOpenSquareBracketList.Count - 1]) {
                return IndexOpenBracesList[IndexOpenBracesList.Count - 1];
            } else {
                return IndexOpenSquareBracketList[IndexOpenSquareBracketList.Count - 1];
            }
                
        }

        private bool IsClosedBracket(Bracket bracket) {

            if (bracket > Bracket.SquareBracketOpen) {

                return true;
            } else {
                return false;
            }
        }

        private void DeleteLastOpenIndex(Bracket bracket)
        {
            switch (bracket) {

                case Bracket.RoundBracketOpen:
                    IndexOpenRoundBracketList.RemoveAt(IndexOpenRoundBracketList.Count - 1);
                    break;
                case Bracket.BracesOpen:
                    IndexOpenBracesList.RemoveAt(IndexOpenBracesList.Count - 1);
                    break;
                case Bracket.SquareBracketOpen:
                    IndexOpenSquareBracketList.RemoveAt(IndexOpenSquareBracketList.Count - 1);
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
