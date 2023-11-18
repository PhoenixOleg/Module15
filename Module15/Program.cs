namespace Module15
{
    internal class Program
    {
        static void Main()
        {
            var classes = new[]
            {
               new Classroom { Students = {"Evgeniy", "Sergey", "Andrew"}, },
               new Classroom { Students = {"Anna", "Viktor", "Vladimir"}, },
               new Classroom { Students = {"Bulat", "Alex", "Galina"}, }
           };
            
            var allStudents = GetAllStudents(classes);

            Console.WriteLine("С помощью методов расширения LINQ:");
            Console.WriteLine(string.Join(" ", allStudents));


            var allStudentsSQL = GetAllStudentsClaasicSQL(classes);

            Console.WriteLine("\nС помощью LINQ classic SQL-style (декларативных запросов):");
            Console.WriteLine(string.Join(" ", allStudentsSQL));

            Console.WriteLine("\nНажмите любую клавишу для выхода");
            Console.ReadLine();
        }

        /// <summary>
        /// Статический метод, преобразующий список с экземплярами класса Students в массив строк с именами студентов
        /// при помощи методов расширения LINQ
        /// </summary>
        /// <param name="classes">Перечень классов в учебном заведении</param>
        /// <returns>Строковый массив с именами учащихся во всех классах</returns>
        static string[] GetAllStudents(Classroom[] classes)
        {
            string[] students = classes.SelectMany(c => c.Students).ToArray();

            return students;
        }

        /// <summary>
        /// Статический метод, преобразующий список с экземплярами класса Students в массив строк с именами студентов
        /// при помощи классического SQL-стиля LINQ (декларативный)
        /// </summary>
        /// <param name="classes">Перечень классов в учебном заведении</param>
        /// <returns>Строковый массив с именами учащихся во всех классах</returns>
        static string[] GetAllStudentsClaasicSQL(Classroom[] classes)
        {
            string[] students = (from c in classes
                                 from s in c.Students
                                 select s).ToArray();

            return students;
        }

    }
}