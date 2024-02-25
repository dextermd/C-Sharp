using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_20
{
    internal interface IFileOperations
    {
        void WriteToFile(string path, string data, bool append);
        void WriteLogToFile(string path, string data, bool append);
        void ReadLineByLineFromFile(string path);
        void ReadLineFromFile(string path);
        void ReadEvenLineFromFile(string path);
        void ReadAllFromFile(string path);
        void DeleteFile(string path);
        bool IsFileExist(string path);
        void Show(string message);
        void ReplaceWordFromFile(string path, string oldWord, string newWord, string pathLog);
        (int, int, int, int) CountValueEvenOddTwoFiveDigit(string path);
    }
}
