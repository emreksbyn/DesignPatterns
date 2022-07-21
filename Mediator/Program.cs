using System;
using System.Collections.Generic;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();

            Teacher emre = new Teacher(mediator) { Name = "Emre" };
            mediator.Teacher = emre;

            Student ahmet = new Student(mediator) { Name = "Ahmet" };
            Student mehmet = new Student(mediator) { Name = "Mehmet" };
            mediator.Students = new List<Student> { ahmet, mehmet };

            emre.SendNewImageUrl("slide1.jpg");
            emre.RecieveQuestion("Is it true ?",ahmet);

            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        public CourseMember(Mediator mediator)
        {
            this.Mediator = mediator;
        }
    }
    class Teacher : CourseMember
    {
        public string Name { get; set; }

        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("{0} Teacher recieved a question from {1},{2}", Name, student.Name, question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("{0} Teacher changed slide : {1}", Name, url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("{0} Teacher answered question : {1}, {2}", Name, student, answer);
        }
    }
    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get; set; }

        public void RecieveImage(string url)
        {
            Console.WriteLine("{0} recieved image : {1}", Name, url);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("{0} recieved answer : {1}", Name, answer);
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}