using System;
using System.Collections.Generic;
using System.Text;

namespace TSEmployeeProject.Controls
{
    public interface IMessage
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
