using System;
using System.IO;
namespace ExamPlatform
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            #region reading mcq from mcq file
            string mcqQuestionsFilePath = "MCQ.txt";
            string mcqQuestionsString = "";
            string mcqQuestionAnswerPath = "mcq_sol.txt";
            string mcqQuestionAnswerString = "";
           
            if (File.Exists(mcqQuestionsFilePath) && File.Exists(mcqQuestionAnswerPath))
            {
                mcqQuestionsString= File.ReadAllText(mcqQuestionsFilePath);
                mcqQuestionAnswerString = File.ReadAllText(mcqQuestionAnswerPath);
            }
            //Console.WriteLine(mcqQuestionsString);
            #endregion
            #region split mcq
            string[] mcqQuestionsArray = mcqQuestionsString.Split("######");
            string[] mcqQuestionAnsewerArray = mcqQuestionAnswerString.Split("\n");

            QuestionList questionList = new QuestionList();
            int q_Id = 1;
            for (int i = 0; i < mcqQuestionsArray.Length; i++)
            {
                string[] mcqQuestionHeaderAndChoices = mcqQuestionsArray[i].Split(":");
                string[] mcqQuestionChoices = mcqQuestionHeaderAndChoices[1].Split("\n");

                List<ChoiceAnswer> choiceAnswers= new List<ChoiceAnswer>();

                
                foreach(string item in mcqQuestionChoices)
                    choiceAnswers.Add(new ChoiceAnswer(item));

                questionList.Add(new MCQ(q_Id, mcqQuestionHeaderAndChoices[0] ,1 ,new Answer(mcqQuestionAnsewerArray[i]),choiceAnswers));
                q_Id++;
            }

            #endregion

            #region create TF objects 
            string tfQuestionsPath = "TorF.txt";
            string tfAnswerPath = "TorFSol.txt";
            string TrueOrFalseQuestionString = "";
            String TrueOrFalseAnswerString = "";
            if(File.Exists(tfQuestionsPath) && File.Exists(tfAnswerPath))
            {
                TrueOrFalseQuestionString = File.ReadAllText(tfQuestionsPath);
                TrueOrFalseAnswerString= File.ReadAllText(tfAnswerPath);
            }

            #region split true or false questions 
            string[] TF_QuestionsArray = TrueOrFalseQuestionString.Split("#####");
            string[] TF_AnswersArray = TrueOrFalseAnswerString.Split("\n");

            for (int i = 0; i <TF_QuestionsArray.Length; i++)
            {
                string[] TF_Header = TF_QuestionsArray[i].Split(":");
                

                questionList.Add(new TrueFalse(q_Id, TF_Header[0] , 1 , new Answer(TF_AnswersArray[i]) ));
                q_Id++;
            }
            #endregion
            #endregion

            try
            {
                #region student data 
                int studentId;
                string studentName;
                Console.WriteLine("Please Enter your Id :");
                studentId = int.Parse(Console.ReadLine());
                Console.WriteLine("Please Enter your name : ");
                studentName = Console.ReadLine();
                Student student = new Student(studentId, studentName);
                #endregion

                #region select Exam 
                Console.WriteLine("Do you want practice or final exam if you want practice press 1 if final press 2 ");
                int userWantedExam = int.Parse(Console.ReadLine());
                #endregion
                #region define Exam 
                Dictionary<Question, Answer> examCorrector = new Dictionary<Question, Answer>();

                if (userWantedExam == 2)
                {
                    Exam databaseExam = new FinalExam(questionList, 20);
                    Console.WriteLine("Now you can start Final Exam and the timer is 20 min ");
                    databaseExam.startExam(examCorrector, student);
                }
                else if (userWantedExam == 1)
                {

                    Exam databaseExam = new PracticeExam(questionList, 10);
                    Console.WriteLine("Now you can start Final Exam and the timer is 10 min ");
                    databaseExam.startExam(examCorrector, student);
                }
                else
                {
                    Console.WriteLine("Sorry You enterded error Input ");
                }



                #endregion

            }
            catch {

                Console.WriteLine("Sorry we cannot contine exam because in correct input");
            }
            

        }
    }
}