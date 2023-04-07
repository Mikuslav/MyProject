﻿using System;
using System.Collections.Generic;
using System.Globalization;
using ClassLibrary1;

namespace ConsoleApp1
{
    static class ClassCreator
    {
        public static Lesson Lesson()
        {
            Console.WriteLine("Занятие");
            DateTime date = DateTime.Now;
            string input, d = "d.M.yyyy H:m:s";
            CultureInfo ci = CultureInfo.InvariantCulture;
            while (true)
            {
                Console.Write("Введите дату проведения в формате \"число.месяц.год часы:минуты:секунды\": ");
                input = Console.ReadLine();
                if (!DateTime.TryParseExact(input, d, ci, DateTimeStyles.None, out _))
                {
                    if (string.IsNullOrEmpty(input)) return new Lesson(Discipline(), Worker(), Auditorium(), Group(), Pair(), TypeOfLesson());
                    Console.WriteLine("Неверный формат");
                }
                else 
                { 
                    date = DateTime.ParseExact(input, d, ci);
                    break;
                }     
            }
            return new Lesson(date, Discipline(), Worker(), Auditorium(), Group(), Pair(), TypeOfLesson());
        }

        public static Auditorium Auditorium()
        {
            Console.WriteLine("Аудитория");
            Console.Write("Введите название аудитории: ");
            string name = Console.ReadLine();
            uint places;
            uint window;
            while (true)
            {
                Console.Write("Введите количество посадочных мест: ");
                if (!uint.TryParse(Console.ReadLine(), out places)) Console.WriteLine("Неверный формат"); else break;
            }
            while (true)
            {
                Console.Write("Введите количество окон: ");
                if (!uint.TryParse(Console.ReadLine(), out window)) Console.WriteLine("Неверный формат"); else break;
            }
            List<Equipment> list = new List<Equipment>();
            int c = 1;
            Console.WriteLine("Список оборудования");
            bool f = true;
            string temp;
            while (f)
            {
                Console.Write($"Введите {c} ");
                list.Add(Equipment());
                Console.Write("Завершить создание списка? (да/нет): ");
                temp = Console.ReadLine();
                if (temp == "да") break;
                c++;
            }
            return new Auditorium(name, Worker(), places, window, list);
        }

        public static Discipline Discipline()
        {
            Console.WriteLine("Дисциплина");
            Console.Write("Введите название дисциплины: ");
            string name = Console.ReadLine();
            Console.Write("Введите сокращение: ");
            string abbreviation = Console.ReadLine();
            return new Discipline(name, abbreviation);
        }

        public static Group Group()
        {
            Console.WriteLine("Группа");
            Console.Write("Введите название: ");
            string name = Console.ReadLine();
            Console.Write("Введите сокращение: ");
            string abbreviation = Console.ReadLine();
            Console.Write("Введите численность: ");
            string size = Console.ReadLine();
            Console.Write("Введите год поступления: ");
            string yearofadmission = Console.ReadLine();
            return new Group(name, abbreviation, size, yearofadmission, Specialty(), Worker());
        }

        public static Student Student()
        {
            Console.WriteLine("Студент");
            Console.Write("Введите фамилию: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите имя: ");
            string firstName = Console.ReadLine();
            Console.Write("Введите отчество: ");
            string patronymic = Console.ReadLine();
            Console.Write("Введите дату рождения: ");
            string birthday = Console.ReadLine();
            return new Student(lastName, firstName, patronymic, Group(), birthday);
        }

        public static Specialty Specialty()
        {
            Console.WriteLine("Специальность");
            Console.Write("Введите название специальности ");
            string name = Console.ReadLine();
            Console.Write("Введите сокращение ");
            string abbreviation = Console.ReadLine();
            return new Specialty(name, abbreviation);
        }
        public static Pair Pair()
        {
            return new Pair();
        }

        public static Shift Shift()
        {
            return new Shift();
        }


        public static Worker Worker()
        {
            Console.WriteLine("Сотрудник");
            Console.Write("Введите фамилию: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите имя: ");
            string firstName = Console.ReadLine();
            Console.Write("Введите отчество: ");
            string patronymic = Console.ReadLine();
            return new Worker(lastName, firstName, patronymic, Post());
        }

        public static Post Post()
        {
            Console.WriteLine("Должность");
            Console.Write("Введите название: ");
            string title = Console.ReadLine();
            Console.Write("Укажите размер оклада: ");
            string salary = Console.ReadLine();
            return new Post(title, salary, Subdivision());
        }

        public static Subdivision Subdivision()
        {
            return new Subdivision();
        }

        public static Organization Organization()
        {
            return new Organization();
        }

        public static Corps Corps()
        {
            Console.Write("Корпус\nВведите название: ");
            string nom = Console.ReadLine();
            Console.Write("Введите адрес: ");
            string adress = Console.ReadLine();
            Console.WriteLine("Комендант:");
            return new Corps(nom,adress,Worker(),Organization());
        }
        public static TypeOfLesson TypeOfLesson()
        {
            return new TypeOfLesson();
        }

        public static Equipment Equipment()
        {
            return new Equipment();
        }
    }
}