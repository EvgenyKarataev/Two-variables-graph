namespace TwoVariablesGraph
{
    public class PostfixItem
    {
        public PostfixItem(PostfixItem NewItem)
        {
            this.state = NewItem.state;
            this.constant = NewItem.constant;
            this.functions = NewItem.functions;
            this.vars = NewItem.vars;
            this.knownconst = NewItem.knownconst;
        }

        public PostfixItem(Functions function)
        {
            functions = function;
            state = State.Function;
        }

        public PostfixItem(Vars var)
        {
            vars = var;
            state = State.Vars;
        }

        public PostfixItem(float constant)
        {
            this.constant = constant;
            state = State.Const;
        }

        public PostfixItem(KnownConst knownconst)
        {
            this.knownconst = knownconst;
            state = State.KnownConst;
        }

        public float constant { get; set; }

        public Vars vars { get; set; }

        public Functions functions { get; set; }

        public State state { get; set; }

        public KnownConst knownconst { get; set; }
    }
}
