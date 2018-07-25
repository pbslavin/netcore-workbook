using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.Intrastructure
{
    public class DateTimeProvider
    {
        public DateTime Now
        {
            get
            {
                return DateTime.Now.AddDays(2);
            }
        }
    }
}
