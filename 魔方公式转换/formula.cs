using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCube
{
    public class Formula
    {
        public List<string> _formula { get; }

        public Formula(string formula)
        {
            _formula = new List<string>();
            StringBuilder temStr = new StringBuilder();
            foreach (char c in formula)
            {
                if ((c <= 90 && c >= 65) || (c <= 122 && c >= 97))
                {
                    _formula.Add(temStr.ToString());
                    temStr.Clear();

                    temStr.Append(c);
                }
                else if (c == '\'')
                {
                    temStr.Append('\'');
                }
                else if (c == '2')
                {
                    _formula.add(temStr.ToString());
                }
            }
            _formula.Add(temStr.ToString());
            _formula.RemoveAt(0);
        }
    }
}
