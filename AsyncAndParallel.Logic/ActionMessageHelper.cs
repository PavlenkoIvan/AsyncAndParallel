using System.Linq;

namespace AsyncAndParallel
{
    public class ActionMessageHelper
        {
        public static string ActionResult(string content)
        {
            var count = content.Where(x => x == '0').Count();
            return $"It contains o {count} times";
        }

    }
}
