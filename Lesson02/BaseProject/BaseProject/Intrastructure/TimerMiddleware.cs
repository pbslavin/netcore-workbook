using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.Intrastructure
{
    public class TimerMiddleware
    {
        private readonly RequestDelegate _next;
        public TimerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }        

        public async Task InvokeAsync(HttpContext context)
        {
            var start = new Stopwatch();
            start.Start();
            await _next(context);
            start.Stop();
            Console.WriteLine($"Time from beginning to end of request: {start.ElapsedMilliseconds} milliseconds.");
        }
    }
}