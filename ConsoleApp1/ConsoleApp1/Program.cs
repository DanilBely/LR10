﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_10
{
    class Program
    {
        class Student : IComparable<Student>
        {
            public string name;
            public int age;

            public Student(int Age, string Name)
            {
                age = Age;
                name = Name;
            }
            public Student()
            {
                age = -1;
                name = null;
            }
            public int CompareTo(Student obj)
            {
                if (this.age > obj.age)
                    return 1;
                if (this.age < obj.age)
                    return -1;
                else
                    return 0;
            }
        }
        static void Main(string[] args)
        {

            ArrayList ArrList = new ArrayList();
            Random x = new Random();
            int n;
            for (int i = 0; i < 5; i++)
            {
                n = x.Next();
                ArrList.Add(n);
            }


            string c = "abc";
            ArrList.Add(c);

            Student s1 = new Student();
            s1.name = "Danila";
            s1.age = 20;

            ArrList.Add(s1);

            Console.WriteLine("Count of ArrLists: " + ArrList.Count);

            Console.WriteLine("Elements:");
            foreach (var s in ArrList)
                Console.WriteLine(s);

            if (ArrList.Contains(c))
                Console.WriteLine("ArrList consist string " + c);
            else
                Console.WriteLine("ArrList dosen't consist string " + c);

            ArrList.RemoveAt(0);


            //2

            SortedDictionary<int, string> SortDict = new SortedDictionary<int, string>();
            SortDict.Add(1, "Maxim");
            SortDict.Add(2, "Danil");
            SortDict.Add(3, "Roman");
            SortDict.Add(s1.age, s1.name);//Danila
            Console.WriteLine("Count of ArrLists: " + SortDict.Count);
            Console.WriteLine("Elements of SortDict:");
            foreach (string str in SortDict.Values)
                Console.WriteLine(str);

            n = 2;
            for (int i = 1; i <= n; i++)
            {
                SortDict.Remove(i);
            }
            SortDict[1] = "Dima";
            SortDict.Add(4,"Novichek");
            SortedDictionary<int, string> SortDict2 = SortDict;

            List<string> list = new List<string>();
            Console.WriteLine("Elements of SortDict2:");
            foreach (string str in SortDict2.Values)
            {
                Console.WriteLine(str);
                list.Add(str);
            }

            Console.WriteLine("Список из тех же элементов: ");
            foreach (string str in list)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine(list.Contains("Dima") ? "List contains Dima" : "List dosen't contain Dima");

            List<Student> listOfStudents = new List<Student>();
            listOfStudents.Add(new Student(19, "Kate"));
            Console.WriteLine("Вывод возрастов студентов в списке:");
            listOfStudents.Add(s1);
            foreach (Student st in listOfStudents)
            {
                Console.WriteLine(st.age);
            }
            n = 2;
            for (int i = 0; i < n; i++)
            {
                listOfStudents.Remove(listOfStudents[0]);
            }
            foreach (Student st in listOfStudents)
            {
                Console.WriteLine(st.age);
            }

            void change(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Console.WriteLine("Добавление студента");
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Console.WriteLine("Удаление студента");
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        Console.WriteLine("Замена объекта");
                        break;
                    case NotifyCollectionChangedAction.Move:
                        Console.WriteLine("Перемещение объекта");
                        break;
                    case NotifyCollectionChangedAction.Reset:
                        Console.WriteLine("Содержимое коллекции удалено");
                        break;
                }
            }
            ObservableCollection<Student> students = new ObservableCollection<Student>();//позволяет известить внешние объекты о том, что коллекция была изменена.
            students.Add(s1);
            students.CollectionChanged += change;
            students.Add(new Student(44, "Jim"));
            students.Remove(s1);

            Console.ReadKey();
        }
    }
}