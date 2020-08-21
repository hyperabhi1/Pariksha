using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pariksha
{
    class Models
    {
        public int[] AnswerSheet { get; set; }
        public Score Score { get; set; }
        public string[] submittedAnswers { get; set; }
        public FileDetails QuestionPaperDetails { get; set; }
        public FileDetails AnswerPaperDetails { get; set; }
    }
    class Score
    {
        public string TimeTaken { get; set; }
        public double MarksObtained { get; set; }
        public int OutOff { get; set; }
        public int Correct { get; set; }
        public int InCorrect { get; set; }
        public int Skipped { get; set; }
    }
    class FileDetails
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileSize { get; set; }
    }
}
