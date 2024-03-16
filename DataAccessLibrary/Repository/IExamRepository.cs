﻿using DataAccessLibrary.Model;

namespace DataAccessLibrary.Repository
{
    public interface IExamRepository : IRepository<Exam>
    {
        public bool AddExamQuestions(List<ExamQuestion> examQuestions);
        public bool UpdateTotalGrade(int examId, int totalGrade);
        public List<ExamTaken> GetExamGradesWithIncludes(int examId);
    }
}
