using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concept_0_03
{
    class Question1Class
    {
        string question;
        string questionImageName;
        string answer1;
        string answer2;
        string answer3;
        string answer4;
        string correctAnswer;

        public Question1Class(string quest, string questImgName, string an1, string an2, string an3, string an4, string cor)
        {
            question = quest;
            questionImageName = questImgName;
            answer1 = an1;
            answer2 = an2;
            answer3 = an3;
            answer4 = an4;
            correctAnswer = cor;
        }

        //Setters
        public void SetQuestion(string str)
        {
            question = str;
        }

        public void SetQuestionImageName(string str)
        {
            questionImageName = str;
        }

        public void SetAnswer1(string str)
        {
            answer1 = str;
        }

        public void SetAnswer2(string str)
        {
            answer2 = str;
        }

        public void SetAnswer3(string str)
        {
            answer3 = str;
        }

        public void SetAnswer4(string str)
        {
            answer4 = str;
        }

        public void SetCorrectAnswer(string str)
        {
            correctAnswer = str;
        }

        //Getters
        public string GetQuestion()
        {
            return question;
        }

        public string GetQuestionImageName()
        {
            return questionImageName;
        }

        public string GetAnswer1()
        {
            return answer1;
        }

        public string GetAnswer2()
        {
            return answer2;
        }

        public string GetAnswer3()
        {
            return answer3;
        }

        public string GetAnswer4()
        {
            return answer4;
        }

        public string GetCorrectAnswer()
        {
            return correctAnswer;
        }
    }
}
