using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    internal class Film
    {
        public string Name { get; set; }
        public int Year { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var films = new List<Film>
            {
                new Film {Name = "Jaws", Year = 1975},
                new Film {Name = "Singing in the Rain", Year = 1952},
                new Film {Name = "Some like it Hot", Year = 1959},
                new Film {Name = "The Wizard of Oz", Year = 1939},
                new Film {Name = "It’s a Wonderful Life", Year = 1946},
                new Film {Name = "American Beauty", Year = 1999},
                new Film {Name = "High Fidelity", Year = 2000},
                new Film {Name = "The Usual Suspects", Year = 1995}
            };

            //Создание многократно используемого делегата для вывода списка на консоль
            Action<Film> print = film => Console.WriteLine($"Name={film.Name}, Year={film.Year}");

            //Вывод на консоль исходного списка
            films.ForEach(print);

            //Создание и вывод отфильтрованного списка
            films.FindAll(film => film.Year < 1960).ForEach(print);

            //Сортировка исходного списка
            films.Sort((f1, f2) => f1.Name.CompareTo(f2.Name));
            //or
            films.OrderBy(film => film.Name);

            {
                // OrderByDescending, Skip, SkipWhile, Take, TakeWhile, Select, Concat
                int[] n = {1, 3, 5, 6, 3, 6, 7, 8, 45, 3, 7, 6};

                IEnumerable<int> res;
                res = n.OrderByDescending(g => g).Skip(3);
                res = n.OrderByDescending(g => g).Take(3);
                res = n.Select(g => g * 2);
                // to delete from array number 45
                res = n.TakeWhile(g => g != 45).Concat(n.SkipWhile(s => s != 45).Skip(1));
            }

            {
                //Дана последовательность непустых строк. 
                //Объединить все строки в одну.
                var str = new List<string> {"Hello", "cqwertyc", "cqwe", "c"};
                var amount = str.Aggregate((x, y) => x + y);
            }

            {
                //LinqBegin3. Дано целое число L (> 0) и строковая последовательность A.
                //Вывести последнюю строку из A, начинающуюся с цифры и имеющую длину L.
                //Если требуемых строк в последовательности A нет, то вывести строку «Not found».
                //Указание.Для обработки ситуации, связанной с отсутствием требуемых строк, использовать операцию ??.

                var length = 8;
                var str = new List<string> {"1qwerty", "2qwerty", "7qwe"};
                var res = str.FirstOrDefault(x => char.IsDigit(x[0]) && x.Length == length) ?? "Not found";
            }

            {
                //LinqBegin5. Дан символ С и строковая последовательность A.
                //Найти количество элементов A, которые содержат более одного символа и при этом начинаются и оканчиваются символом C.

                var c = 'c';
                var str = new List<string> {"1qwerty", "cqwertyc", "cqwe", "c"};
                var amount =
                    str.Count(x => x.StartsWith(c.ToString()) && x.EndsWith(c.ToString()) && x.Length > 1);
            }

            {
                //LinqBegin6. Дана строковая последовательность.
                //Найти сумму длин всех строк, входящих в данную последовательность.
                //TODO
                Console.WriteLine("Linq begin 6 task");
                var str = new List<string> {"1qwerty", "cqwertyc", "cqwe", "c"};
                var sum = str.Sum(x => x.Length);
                Console.WriteLine(sum);
            }

            {
                //LinqBegin11. Дана последовательность непустых строк. 
                //Пполучить строку, состоящую из начальных символов всех строк исходной последовательности.
                //TODO

                Console.WriteLine("Linq begin 11 task");
                var str = new List<string> {"1qwerty", "cqwertyc", "cqwe", "c"};

                var result = str.Aggregate((x, y) =>
                    x == str[0] ? x[0] + y[0].ToString() : x + y[0]);

                Console.WriteLine(result);
            }

            {
                //LinqBegin30. Дано целое число K (> 0) и целочисленная последовательность A.
                //Найти теоретико-множественную разность двух фрагментов A: первый содержит все четные числа, 
                //а второй — все числа с порядковыми номерами, большими K.
                //В полученной последовательности(не содержащей одинаковых элементов) поменять порядок элементов на обратный.
                var k = 5;
                IEnumerable<int> n = new[] {12, 88, 1, 3, 5, 4, 6, 6, 2, 5, 8, 9, 0, 90};
                var res = n.Where(x => x % 2 == 0).Except(n.Skip(k)).Reverse();
            }

            {
                //LinqBegin22. Дано целое число K (> 0) и строковая последовательность A.
                //Строки последовательности содержат только цифры и заглавные буквы латинского алфавита.
                //Извлечь из A все строки длины K, оканчивающиеся цифрой, отсортировав их по возрастанию.
                //TODO
                Console.WriteLine("Linq begin 22 task");
                var k = 7;

                var a = new List<string>
                    {"1", "2", "DOKSJA2", "ASOSDFSDFUDH1", "ASDIASDIJH", "KASDJO", "DOKSJA3", "DOKSJA1"};
                var res = a.Where(x => x.Length == k && char.IsDigit(x[x.Length - 1]))
                    .OrderBy(x => x[x.Length - 1]);

                foreach (var re in res)
                    Console.WriteLine(re);
            }

            {
                //LinqBegin29. Даны целые числа D и K (K > 0) и целочисленная последовательность A.
                //Найти теоретико - множественное объединение двух фрагментов A: первый содержит все элементы до первого элемента, 
                //большего D(не включая его), а второй — все элементы, начиная с элемента с порядковым номером K.
                //Полученную последовательность(не содержащую одинаковых элементов) отсортировать по убыванию.
                //TODO
                Console.WriteLine("Linq begin 29 task");

                var d = 7;
                var k = 5;

                var A = new List<int> {1, 2, 3, 4, 5, 6};


                var res = A.TakeWhile(x => x < d).Concat(A.Skip(k)).Distinct().OrderByDescending(x => x);

                foreach (var re in res)
                    Console.WriteLine(re);
            }

            {
                //LinqBegin34. Дана последовательность положительных целых чисел.
                //Обрабатывая только нечетные числа, получить последовательность их строковых представлений и отсортировать ее по возрастанию.
                IEnumerable<int> n = new[] {12, 88, 1, 3, 5, 4, 6, 6, 2, 5, 8, 9, 0, 90};
                var res = n.Where(x => x % 2 != 0).Select(x => x.ToString()).OrderBy(x => x);
            }

            {
                //LinqBegin36. Дана последовательность непустых строк. 
                //Получить последовательность символов, которая определяется следующим образом: 
                //если соответствующая строка исходной последовательности имеет нечетную длину, то в качестве
                //символа берется первый символ этой строки; в противном случае берется последний символ строки.
                //Отсортировать полученные символы по убыванию их кодов.
                //TODO
                Console.WriteLine("Linq begin 36 task");

                var str = new List<string> {"HELLO ", "WORLD", "WTF", "DAROVA", "BEST", "8941753"};

                var res = str.Select(x => x.Length % 2 != 0 ? x[0] : x[x.Length - 1]).OrderByDescending(x => x);

                foreach (var item in res)
                    Console.Write(item + " ");
            }

            {
                //LinqBegin44. Даны целые числа K1 и K2 и целочисленные последовательности A и B.
                //Получить последовательность, содержащую все числа из A, большие K1, и все числа из B, меньшие K2. 
                //Отсортировать полученную последовательность по возрастанию.
                //TODO
                Console.WriteLine("Linq begin 44 task");

                int k1 = 10, k2 = 20;
                IEnumerable<int> A = new[] {15, 2, 2134, 412, 43, 54, 654, 45, 1345};
                IEnumerable<int> B = new[] {15, 2, 2134, 412, 43, 54, 654, 45, 1345};

                var res = A.Where(x => x > k1).Concat(B.Where(x => x < k2)).OrderBy(x => x);

                foreach (var i in res)
                    Console.Write(i + " ");
            }

            {
                //LinqBegin46. Даны последовательности положительных целых чисел A и B; все числа в каждой последовательности различны.
                //Найти последовательность всех пар чисел, удовлетворяющих следующим условиям: первый элемент пары принадлежит 
                //последовательности A, второй принадлежит B, и оба элемента оканчиваются одной и той же цифрой. 
                //Результирующая последовательность называется внутренним объединением последовательностей A и B по ключу, 
                //определяемому последними цифрами исходных чисел. 
                //Представить найденное объединение в виде последовательности строк, содержащих первый и второй элементы пары, 
                //разделенные дефисом, например, «49 - 129».
                IEnumerable<int> n1 = new[] {12, 88, 11, 3, 55, 679, 222, 845, 9245};
                IEnumerable<int> n2 = new[] {123, 888, 551, 443, 69, 222, 780};
                var res = n1.Join(n2, x => x % 10, y => y % 10, (x, y) => x + " - " + y);
            }
            {
                //LinqBegin48.Даны строковые последовательности A и B; все строки в каждой последовательности различны, 
                //имеют ненулевую длину и содержат только цифры и заглавные буквы латинского алфавита. 
                //Найти внутреннее объединение A и B, каждая пара которого должна содержать строки одинаковой длины.
                //Представить найденное объединение в виде последовательности строк, содержащих первый и второй элементы пары, 
                //разделенные двоеточием, например, «AB: CD». Порядок следования пар должен определяться порядком 
                //первых элементов пар(по возрастанию), а для равных первых элементов — порядком вторых элементов пар(по убыванию).
                //TODO
                Console.WriteLine("Linq begin 48 task");
                var A = new List<string>
                    {"1", "2", "DOKSJA2", "ASOSDFSDFUDH1", "ASDIASDIJH", "KASDJO", "DOKSJA3", "DOKSJA1"};

                var B = new List<string> {"LOL", "1", "17", "DSALKJDS", "APOISJDS", "SOAIDJPIJC", "OHFDSKCM"};

                var res = A.Join(B,
                    x => x.Length,
                    y => y.Length,
                    (x, y) => x[0] > y[0]
                        ? x[0] + x[1].ToString() + ":" + y[0] + y[1]
                        : y[0] + y[1].ToString() + ":" + x[0] + x[1]).OrderBy(x => x);

                //order
            }

            {
                //LinqBegin56. Дана целочисленная последовательность A.
                //Сгруппировать элементы последовательности A, оканчивающиеся одной и той же цифрой, и на основе этой группировки 
                //получить последовательность строк вида «D: S», где D — ключ группировки (т.е.некоторая цифра, которой оканчивается 
                //хотя бы одно из чисел последовательности A), а S — сумма всех чисел из A, которые оканчиваются цифрой D.
                //Полученную последовательность упорядочить по возрастанию ключей.
                //Указание.Использовать метод GroupBy.

                IEnumerable<int> n = new[] {12, 88, 11, 3, 55, 679, 222, 845, 9245};
                var res = new List<string>();

                IEnumerable<IGrouping<int, int>> groups = n.GroupBy(x => x % 10).OrderBy(x => x.Key);

                foreach (var group in groups)
                {
                    var listElement = group.Key.ToString();
                    var summaryValue = 0;

                    foreach (var item in group) summaryValue += item;

                    listElement = listElement + ": " + summaryValue;
                    res.Add(listElement);
                }

                {
                    //LinqObj17. Исходная последовательность содержит сведения об абитуриентах. Каждый элемент последовательности
                    //включает следующие поля: < Номер школы > < Год поступления > < Фамилия >
                    //Для каждого года, присутствующего в исходных данных, вывести число различных школ, которые окончили абитуриенты, 
                    //поступившие в этом году (вначале указывать число школ, затем год). 
                    //Сведения о каждом годе выводить на новой строке и упорядочивать по возрастанию числа школ, 
                    //а для совпадающих чисел — по возрастанию номера года.
                    //TODO
                    Console.WriteLine("Linq Obj 17 task");
                    var first = new Student {Name = "Serhii", NumberOfSchool = 12, Year = 2005};
                    var second = new Student {Name = "Andrii", NumberOfSchool = 12, Year = 2012};
                    var third = new Student {Name = "Vova", NumberOfSchool = 12, Year = 2007};
                    var fourth = new Student {Name = "Illya", NumberOfSchool = 12, Year = 2005};

                    var list = new List<Student>();
                    list.Add(first);
                    list.Add(second);
                    list.Add(third);
                    list.Add(fourth);
                    //distinct order
                    var sort = list.GroupBy(x => x.Year).OrderBy(x => x.Key)
                        .Select(x => new { Year = x.Key, Count = x.GroupBy(y => y.NumberOfSchool).Count() });

                    
                }
            }
        }
    }

    internal class Student
    {
        public int NumberOfSchool { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
    }
}