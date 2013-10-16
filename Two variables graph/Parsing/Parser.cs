using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TwoVariablesGraph
{
    /// <summary>
        /// 
        /// </summary>
    public enum Functions
    {
            Sum,
            Difference,
            Multiplication,
            Division,
            Power,
            Sin,
            Cos,
            Tg,
            Ctg,
            ArcSin,
            ArcCos,
            ArcTg,
            ArcCtg,
            Ln,
            Lg
    } ;

    public enum KnownConst
    {
        Pi,
        e
    } ;

    public enum Vars
    {
        X,
        Y
    } ;

    public enum State
    {
        Function,
        Vars,
        Const,
        KnownConst
    } ;

    public class Parser
    {
        private const string _gram = @"(?<number>[0-9]+(\.[0-9]+)?)?"
            + @"(?<sings>[+\-\*/\(\)\^])?" 
            + @"(?<fun>(sin|cos|tg|ctg|arcsin|arccos|arctg|arcctg|lg|ln))?" 
            + @"(?<vars>(x|y|pi|e))?";

        private int _currentpos = 0;
        private readonly ArrayList _stek;
        private readonly List<PostfixItem> _postfix;

        public Parser()
        {
            _stek = new ArrayList();
            _postfix = new List<PostfixItem>();
        }

        public PostfixItem this [int index]
        {
            get { return _postfix[index]; }
            set { _postfix[index] = value; }
        }

        public int Count
        {
            get { return _postfix.Count; }
        }

        public bool Parse(string chain)
        {
            Regex gram = new Regex(_gram);
            var matches = gram.Matches(chain);

            _postfix.Clear();
            _currentpos = 0;
            _stek.Clear();
            
            foreach (Match match in matches)
            {
                if (match.Groups["number"].Value != "")
                    _stek.Add(match.Groups["number"].Value);
                if (match.Groups["sings"].Value != "")
                    _stek.Add(match.Groups["sings"].Value);
                if (match.Groups["fun"].Value != "")
                    _stek.Add(match.Groups["fun"].Value);
                if (match.Groups["vars"].Value != "")
                    _stek.Add(match.Groups["vars"].Value);
            }

            return Add();
        }

        private bool TryMatch(string value)
        {
            if (_currentpos == _stek.Count) return false;
            if ((string)_stek[_currentpos] == value)
            {
                _currentpos++;
                return true;
            }
            return false;
        }

        private bool Add()
        {
            if (!Mult()) 
                return false;
            while (true)
            {
                if (TryMatch("+"))
                {
                    if (!Mult())
                        return false;
                    _postfix.Add(new PostfixItem(Functions.Sum));
                }
                else
                {
                    if (TryMatch("-"))
                    {
                        if (!Mult())
                            return false;
                        _postfix.Add(new PostfixItem(Functions.Difference));
                    }
                    else 
                        return true;
                        
                }
                    
            }
            
        }

        private bool Mult()
        {
            if (!Power())  //Value
                return false;
            while (true)
            {
                if (TryMatch("*"))
                {
                    if (!Power())
                        return false;
                    _postfix.Add(new PostfixItem(Functions.Multiplication));
                }
                else
                {
                    if (TryMatch("/"))
                    {
                        if (!Power())
                            return false;
                        _postfix.Add(new PostfixItem(Functions.Division));
                    }
                    else
                        return true;
                }
            }
            
        }

        private bool Power()
        {
            if (!Value())  //Value
                return false;
            while (true)
            {
                if (TryMatch("^"))
                {
                    if (!Value())
                        return false;
                    _postfix.Add(new PostfixItem(Functions.Power));
                }
                else
                {
                    return true;
                }
            } 
        }

        private bool Trig()
        {
          //  if (!Value())
          //      return false;
          //  while (true)
          //  {
                if (TryMatch("sin"))
                {
                    if (!Value())
                        return false;
                    _postfix.Add(new PostfixItem(Functions.Sin));
                }
                else
                {
                    if (TryMatch("cos"))
                    {
                        if (!Value())
                            return false;
                        _postfix.Add(new PostfixItem(Functions.Cos));
                    }
                   else
                        if (TryMatch("tg"))
                        {
                            if (!Value())
                                return false;
                            _postfix.Add(new PostfixItem(Functions.Tg));
                        }
                        else
                            if (TryMatch("ctg"))
                            {
                                if (!Value())
                                    return false;
                                _postfix.Add(new PostfixItem(Functions.Ctg));
                            }
                            else
                                if (TryMatch("arcsin"))
                                {
                                    if (!Value())
                                        return false;
                                    _postfix.Add(new PostfixItem(Functions.ArcSin));
                                }
                                else
                                    if (TryMatch("arccos"))
                                    {
                                        if (!Value())
                                            return false;
                                        _postfix.Add(new PostfixItem(Functions.ArcCos));
                                    }
                                    else
                                        if (TryMatch("arctg"))
                                        {
                                            if (!Value())
                                                return false;
                                            _postfix.Add(new PostfixItem(Functions.ArcTg));
                                        }
                                        else
                                            if (TryMatch("arcctg"))
                                            {
                                                if (!Value())
                                                    return false;
                                                _postfix.Add(new PostfixItem(Functions.ArcCtg));
                                            }
                                            else
                                            if (TryMatch("lg"))
                                            {
                                                if (!Value())
                                                    return false;
                                                _postfix.Add(new PostfixItem(Functions.Lg));
                                            }
                                            else
                                                if (TryMatch("ln"))
                                                {
                                                    if (!Value())
                                                        return false;
                                                    _postfix.Add(new PostfixItem(Functions.Ln));
                                                }
                                                else
                                                    return false;
                }
        //    }
            return true;
        }

        private bool Value()
        {
            if (!Trig())
            if (TryMatch("("))
            {
                if (!Add())
                    return false;
                if (!TryMatch(")")) 
                    return false;
                
            }
            else
            {
                string num;
                if (Number(out num))
                {
                    if (num == "x")
                        _postfix.Add(new PostfixItem(Vars.X));
                    else if (num == "y")
                        _postfix.Add(new PostfixItem(Vars.Y));
                    else if (num == "pi")
                        _postfix.Add(new PostfixItem(KnownConst.Pi));
                    else if (num == "e")
                        _postfix.Add(new PostfixItem(KnownConst.e));
                    else
                        _postfix.Add(new PostfixItem((float)Convert.ToDouble(num)));
                }
                else
                    return false;
            }
            return true;
        }

        private bool Number(out string num)
        {
            if (_currentpos == _stek.Count)
            {
                num = "";
                return false;
            }
            try
            {
                if ((string)_stek[_currentpos] != "x" && (string)_stek[_currentpos] != "y"
                    && (string)_stek[_currentpos] != "pi" && (string)_stek[_currentpos] != "e")
                    Convert.ToDouble(_stek[_currentpos]);
                num = (string)_stek[_currentpos];
                _currentpos++;
                return true;
            }
            catch (Exception)
            {
                num = "";
                return false;
            }
        }
    }
}
