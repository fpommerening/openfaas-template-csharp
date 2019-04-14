using OpenFaaS.Dotnet;

namespace Function
{
    public class FunctionHandler : BaseFunction
    {
        public FunctionHandler(IFunctionContext functionContext)
            : base(functionContext)
        {
        }

        public override string Handle(string input)
        {
            return $"Hi there - your input was: {input}";
        }
    }
}
