using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concept_0_03
{
    class Question2Class
    {
        string question;
        string answer1Image;
        string answer2Image;
        string answer3Image;
        string answer4Image;
        string correctAnswerImage;

        public Question2Class(string quest, string an1Image, string an2Image, string an3Image, string an4Image,
            string corImage)
        {
            question = quest;
            answer1Image = an1Image;
            answer2Image = an2Image;
            answer3Image = an3Image;
            answer4Image = an4Image;
            correctAnswerImage = corImage;
        }

        //Setters
        public void SetQuestion(string str)
        {
            question = str;
        }

        public void SetAnswer1Image(string str)
        {
            answer1Image = str;
        }

        public void SetAnswer2Image(string str)
        {
            answer2Image = str;
        }

        public void SetAnswer3Image(string str)
        {
            answer3Image = str;
        }

        public void SetAnswer4Image(string str)
        {
            answer4Image = str;
        }

        public void SetCorrectAnswerImage(string str)
        {
            correctAnswerImage = str;
        }

        //Getters
        public string GetQuestion()
        {
            return question;
        }

        public string GetAnswer1Image()
        {
            return answer1Image;
        }

        public string GetAnswer2Image()
        {
            return answer2Image;
        }

        public string GetAnswer3Image()
        {
            return answer3Image;
        }

        public string GetAnswer4Image()
        {
            return answer4Image;
        }

        public string GetCorrectAnswerImage()
        {
            return correctAnswerImage;
        }
    }
}
