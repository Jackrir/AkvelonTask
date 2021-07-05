using System;
using System.Collections.Generic;

namespace AkvelonTask
{
    public class BalanceVerificator
    {
        private int GradationRoundBracket {get;set;}
        private int LastOpenRoundBracket { get; set; }
        private int GradationBraces { get; set; }
        private int LastOpenBraces { get; set; }
        private int GradationSquareBracket { get; set; }
        private int LastOpenSquareBracket { get; set; }

        public BalanceVerificator()
        {
            GradationRoundBracket = 0;
            GradationBraces = 0;
            GradationSquareBracket = 0;
            LastOpenRoundBracket = -1;
            LastOpenBraces = -1;
            LastOpenSquareBracket = -1;
        }

        public int IsBalancedBracketsString(string bracketsString)
        {
            int i = 0;
            foreach(char bracket in bracketsString)
            {
                if (!UpdateGradationData(bracket, i))
                    return -2;
                int validationGradationCloseBracketResult = isValidGradationCloseBracket(i);
                if (validationGradationCloseBracketResult != -1)
                    return validationGradationCloseBracketResult;
                i++;
            }
            int validationGradationOpenBracketResult = isValidGradationOpenBracket();
            if (validationGradationOpenBracketResult != -1)
                return validationGradationOpenBracketResult;
            return -1;

        }

        private bool UpdateGradationData(char bracket, int index)
        {
            switch (bracket)
            {
                case '(':
                    GradationRoundBracket++;
                    LastOpenRoundBracket = index;
                    return true;
                case ')':
                    GradationRoundBracket--;
                    return true;
                case '{':
                    GradationBraces++;
                    LastOpenBraces = index;
                    return true;
                case '}':
                    GradationBraces--;
                    return true;
                case '[':
                    GradationSquareBracket++;
                    LastOpenSquareBracket = index;
                    return true;
                case ']':
                    GradationSquareBracket--;
                    return true;
                default:
                    Console.WriteLine("A character ‘{0}’ doesn’t belong to any known brackets type, returns IllegalArgumentException.", bracket);
                    return false;
            }
        }

        private int isValidGradationCloseBracket(int i)
        {
            if (GradationBraces < 0 || GradationRoundBracket < 0 || GradationSquareBracket < 0)
            {
                return i;
            }
            return -1;
        }

        private int isValidGradationOpenBracket()
        {
            if (GradationBraces > 0 || GradationRoundBracket > 0 || GradationSquareBracket > 0)
            {
                if (GradationRoundBracket > 0)
                    return LastOpenRoundBracket;
                else if (GradationBraces > 0)
                    return LastOpenBraces;
                else
                    return LastOpenSquareBracket;
            }
            return -1;
        }
    }
}
