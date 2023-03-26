using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeworkThree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Patient patientOne = new Patient("Сидоров", "Бирюкова 11", 22, false);
            Patient patientTwo = new Patient("Иванов", "Дизайнеров 3", 45, false);
            Patient patientThree = new Patient("Абдулаев", "Пирогова 3", 48, false);

            Doc docOne = new Doc("Ибрагимов", "Врач-невролог", 20, 53);
            Doc docTwo = new Doc("Флоров", "Врач-терапевт", 5, 29);
            Doc docThree = new Doc("Димитрофф", "Врач-профпатолог", 15, 46);

            Queue<Patient> patients = new Queue<Patient>();
            patients.Enqueue(patientOne);
            patients.Enqueue(patientTwo);
            patients.Enqueue(patientThree);


            List<Doc> docs = new List<Doc>();
            docs.Add(docOne);
            docs.Add(docTwo);
            docs.Add(docThree);
            while (true)
            {
                Console.WriteLine("Сегодняшние пациенты: \n");
                foreach (Patient patient in patients)
                {
                    patient.Display();
                }


                Console.WriteLine("\nПринимающие лечащие врачи: \n");
                foreach (Doc doc in docs)
                {
                    doc.Display();
                }
                Console.WriteLine($"\nПациент {patientOne.Surname} будет на приёме у {docOne.Surname}а,\nПациент {patientTwo.Surname} будет на приёме у {docTwo.Surname}а,\nПациент {patientThree.Surname} будет на приёме у {docThree.Surname}а");


                Console.WriteLine("\nВыберите, за чьим лечением Вас интересует наблюдение. Счёт ведётся от 1 до максимального количества случаев");
                try
                {
                    int chooseTheTreatment;
                    chooseTheTreatment = Convert.ToInt32(Console.ReadLine());
                    switch (chooseTheTreatment)
                    {
                        case 1:
                            docOne.Cure(patientOne);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:
                            docTwo.Cure(patientTwo);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            docThree.Cure(patientThree);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Такого случая не существует");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                    Console.Clear();
                }
                if (patientOne.IsHealthy == true && patientTwo.IsHealthy == true && patientThree.IsHealthy == true)
                {
                    Console.Clear();
                    Console.WriteLine("Пациенты излечены - вот так мы хорошо работаем!\n");
                    break;
                }
            }
        }
    }

    interface IDisplay
    {
        void Display();
    }
    class Patient
    {
        public string Surname { get; private set; }
        public string Address { get; private set; }
        public int Age { get; private set; }
        public bool IsHealthy { get; set; }

        public Patient(string surname, string address, int age, bool isHealthy)
        {
            Surname = surname;
            Address = address;
            Age = age;
            IsHealthy = isHealthy;
        }

        public void Display()
        {
            Console.WriteLine($"Пациент {Surname}. Возраст: {Age}. Улица проживания: {Address}. Статус: {ShowStatus(IsHealthy)}");
        }

        public string ShowStatus(bool isHealthy)
        {
            if (isHealthy == true)
            {
                return "Здоров";
            }
            else
            {
                return "Болен";
            }
        }
    }
    class Doc
    {
        public string Surname { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }
        public int Age { get; set; }
        public Doc(string surname, string specialization, int experience, int age = 0)
        {
            Surname = surname;
            Specialization = specialization;
            Experience = experience;
            Age = age;
        }
        public void Display()
        {
            Console.WriteLine($"Лечащий врач: {Surname}. Возраст: {Age}. Специализация: {Specialization}. Стаж: {Experience}");
        }

        public bool Cure(Patient patient)
        {
            Random random = new Random();
            int chanceOfCure = random.Next(0, 2);
            if (patient.IsHealthy == true)
            {
                Console.WriteLine("\n Пациент здоров - ему не нужна помощь!");
                return true;
            }
            else
            {
                Console.WriteLine("\nПациенту необходимо получить лечение");

                Thread.Sleep(2000);
                if (chanceOfCure == 1)
                {
                    patient.IsHealthy = true;
                    Console.WriteLine("\nПациент здоров!");
                    return true;
                }
                else
                {
                    Console.WriteLine("\nПациенту нужно продолжать терапию");
                    return false;
                }
            }
        }

    }
}
