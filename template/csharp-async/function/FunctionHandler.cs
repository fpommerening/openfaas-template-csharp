using System.Threading.Tasks;

namespace Function
{
    public class FunctionHandler
    {
          public Task<string> Handle(string input) 
          {
            return Task.FromResult(string.Format("Hi there - your input was: {0}\n", input));
        }
    }
}
