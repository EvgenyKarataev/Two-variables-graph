using System;

namespace TwoVariablesGraph
{
    static class Constants
    {
        public static float GetConst(PostfixItem Item)
        {
            switch (Item.state)
            {
                case State.Const:
                    return Item.constant;
                case State.KnownConst:
                    switch (Item.knownconst)
                    {
                        case KnownConst.Pi:
                            return (float)Math.PI;
                        case KnownConst.e:
                            return (float)Math.E;
                    }
                    break;
            }
            return 0f;
        }
    }
}
