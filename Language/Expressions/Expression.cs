using Compiler.Structure;

namespace Language.Expressions
{
    public abstract class Expression
    {
        public abstract object? Precompute();

        //Takes in the output of the next component, and outputs its own input.
        public abstract Connector Compile(Connector output);
    }
}