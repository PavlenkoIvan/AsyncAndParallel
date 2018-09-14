﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndParallel
{
    public class AsyncExample
    {
        public async Task<TheResponse> ReedThisFile(string filePath)
        {
            var response = new TheResponse();
            response.ThreadId = $" CurrentThread  {Thread.CurrentThread.ManagedThreadId}, {filePath}";
            using (var data = File.OpenText(filePath))
            {
                var str = await data.ReadToEndAsync();
                response.ActionMessage = ActionMessageHelper.ActionResult(str);
            }
            return response;
        }
    }
}
