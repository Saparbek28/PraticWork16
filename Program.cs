using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива");
            int n = int.Parse(Console.ReadLine());
            Employee[] massiv = new Employee[n];
            for (int i = 0; i < n; i++)
            {
                massiv[i].date = new int[3];
                if (i == 0)
                {
                    Console.WriteLine("Введите информацию о боссе - 0 сотруднике");
                    Console.WriteLine("Введите имя");
                    massiv[i].Name = Console.ReadLine();
                    massiv[i].Vacancy = Vacancies.Boss;
                    Console.WriteLine("Введите заработную плату");
                    massiv[i].Salary = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите день приема на работу");
                    massiv[i].Day = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите месяц приема на работу");
                    massiv[i].Month = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите год приема на работу");
                    massiv[i].Year = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Введите информацию о " + i + " сотруднике");
                    Console.WriteLine("Введите имя");
                    massiv[i].Name = Console.ReadLine();
                    Console.WriteLine("Введите должность 1-Manager, 2-Clerk, 3-Salesman ");
                    string a = Console.ReadLine();
                    switch (a)
                    {
                        case "1": massiv[i].Vacancy = Vacancies.Manager; break;
                        case "2": massiv[i].Vacancy = Vacancies.Clerk; break;
                        case "3": massiv[i].Vacancy = Vacancies.Salesman; break;
                    }
                    Console.WriteLine("Введите заработную плату");
                    massiv[i].Salary = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите день приема на работу");
                    massiv[i].Day = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите месяц приема на работу");
                    massiv[i].Month = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите год приема на работу");
                    massiv[i].Year = int.Parse(Console.ReadLine());
                }
            }
            for (int i = 1; i < n; i++)
            {
                for (int j = i; j < n - 1; j++)
                {
                    Employee temp;
                    if (massiv[j].Name.CompareTo(massiv[j + 1].Name) > 0)
                    {
                        temp = massiv[j];
                        massiv[j] = massiv[j + 1];
                        massiv[j + 1] = temp;
                    }
                }
            }
            bool check = true;
            do
            {
                Console.WriteLine("1- вывести информацию о сотрудниках; 2 - менеджеры, по зарплате; 3 - принятые после босса");
                string a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        {
                            for (int i = 0; i < n; i++)
                            {
                                Console.WriteLine(massiv[i].ToString());
                            }
                        }
                        break;
                    case "2":
                        {
                            double midSalary = 0;
                            int s = 0;
                            for (int i = 0; i < n; i++)
                            {
                                if (massiv[i].Vacancy == Vacancies.Clerk)
                                {
                                    midSalary = +massiv[i].Salary;
                                    s++;
                                }
                            }
                            midSalary = midSalary / n;
                            for (int i = 0; i < n; i++)
                            {
                                if (massiv[i].Vacancy == Vacancies.Manager && massiv[i].Salary > midSalary)
                                {
                                    Console.WriteLine("Имя менеджера " + massiv[i].Name + "  Зарплата - " + massiv[i].Salary + "  Дата приема на работу - " + massiv[i].Day + "." + massiv[i].Month + "." + massiv[i].Year);
                                }
                            }
                        }
                        break;
                    case "3":
                        {
                            for (int i = 1; i < n; i++)
                            {
                                if (massiv[i].Year > massiv[0].Year) Console.WriteLine(massiv[i].ToString());
                                else
                                {
                                    if (massiv[i].Month > massiv[0].Month) Console.WriteLine(massiv[i].ToString());
                                    else
                                    {
                                        if (massiv[i].Day > massiv[0].Day) Console.WriteLine(massiv[i].ToString());
                                    }
                                }
                            }
                        }
                        break;
                    default: check = false; break;
                }
            }
            while (check);
            Console.ReadLine();
        }
    }
}
