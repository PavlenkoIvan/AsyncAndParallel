using System.IO;
using System.Threading;

namespace AsyncAndParallel
{
    public class SyncExample
    {
        public TheResponse ReedThisFile(string filePath)
        {
            var response = new TheResponse();
            response.ThreadId = $" CurrentThread  {Thread.CurrentThread.ManagedThreadId}, {filePath}";
            using (var data = File.OpenText(filePath))
            {
                var str = data.ReadToEnd();
                response.ActionMessage = ActionMessageHelper.ActionResult(str);
            }
            return response;
        }
    }
}
