using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;



struct Worker
{
    
    private static int Id;

    public static int PropId
    {
        get { return Id; }
        private set { Id = value; }
    }
    /// <summary>
    /// Метод вывода информации оработнике на экран
    /// </summary>
    /// <param name="path"> путь к файлу </param>
    public static void OutputInfoUser(string path = @"homework_7.txt")
    {
        string[] UserInfoId;
        int CountLines = File.ReadAllLines(path).Length;
        string[] phrase = { "Информация об Id", "Ф.И.О.", "Возраст",
                            "Рост","Дaта рождения","Место рождения" 
                          };
        Console.WriteLine("Введите Id(1-10) сотрудника");
        do
        {
            string _Id_ = Console.ReadLine();
            int.TryParse(_Id_, out Id);
            if (Id <= CountLines && Id != 0) break;
            else { Console.WriteLine("Попробуйте еще раз!"); }
        } while (Id == 0 || Id > CountLines);
        var sr = new StreamReader(path);
        do
        {
            UserInfoId = sr.ReadLine().Split("#"); ;

        } while (Convert.ToInt32(UserInfoId[0]) != Id);
        //Вывод информации о работнике
        for (int i = 0, y = 1; i < phrase.Length; i++,y++)
        {using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;



struct Worker
{
    
    private static int Id;

    public static int PropId
    {
        get { return Id; }
        private set { Id = value; }
    }
    /// <summary>
    /// Метод вывода информации оработнике на экран
    /// </summary>
    /// <param name="path"> путь к файлу </param>
    public static void OutputInfoUser(string path = @"homework_7.txt")
    {
        string[] UserInfoId;
        int CountLines = File.ReadAllLines(path).Length;
        string[] phrase = { "Информация об Id", "Ф.И.О.", "Возраст",
                            "Рост","Дaта рождения","Место рождения" 
                          };
        Console.WriteLine("Введите Id(1-10) сотрудника");
        do
        {
            string _Id_ = Console.ReadLine();
            int.TryParse(_Id_, out Id);
            if (Id <= CountLines && Id != 0) break;
            else { Console.WriteLine("Попробуйте еще раз!"); }
        } while (Id == 0 || Id > CountLines);
        var sr = new StreamReader(path);
        do
        {
            UserInfoId = sr.ReadLine().Split("#"); 

        } while (Convert.ToInt32(UserInfoId[0]) != Id);
        //Вывод информации о работнике
        for (int i = 0, y = 1; i < phrase.Length; i++,y++)
        {
            if (i == 0) { Console.WriteLine($"{phrase[i]}:{UserInfoId[i]}"); }
            else { Console.WriteLine($"{phrase[i]}:{UserInfoId[y]}"); };
        }

    }
    /// <summary>
    /// Метод удаления учетной записи
    /// </summary>
    /// <param name="path"> путь к файлу </param>
    public static void RemoveUser(string path = @"homework_7.txt")
    {

        int NumId = 0;
        var arr = File.ReadAllLines(path);

        Console.WriteLine($"Введите Id работника для его удаления из БД:");
        do
        {
            string str = Console.ReadLine(); 
            int.TryParse(str, out NumId);

            if (NumId == 0 || NumId > File.ReadAllLines(path).Length) 
            {
                Console.WriteLine($"Существуют Id:");
                foreach (var item in arr)
                {
                    Console.Write(" " + item.Split("#")[0]);
                    Console.WriteLine(Environment.NewLine + $"Введите Id работника из существующих:");
                }

            }

        } while (NumId == 0 || NumId > File.ReadAllLines(path).Length);

        List<string> NewArr = new();

        foreach (var item in arr)
        {
            if (item.Split("#")[0] == NumId.ToString())
            {
                arr.SetValue("",Convert.ToUInt32(item.Split("#")[0]) - 1);
                foreach (var item1 in arr)
                {
                    if (item1 != "") NewArr.Add(item1);
                }
                break;
            }
        }
        File.Delete(path);
        File.WriteAllLines(path,NewArr);
    }
    /// <summary>
    /// Метод редактирования учетной записи
    /// </summary>
    /// <param name="path"> путь к файлу </param>
    public static void EditInfoUser(string path = @"homework_7.txt")
    {
        int NumId = 0, i = 0, y = 0;
        var arr = File.ReadAllLines(path);
        int count = File.ReadAllLines(path).Length;
        int[] val = new int[count];
        string[] arr1 = new string[count];
        //определяем  Id
        foreach (var item in arr) { val[i] = Convert.ToInt32(item.Split("#")[0]); i++; }

        Console.WriteLine($"Введите Id работника для изменения информации:");
        do
        {
            string str = Console.ReadLine();
            int.TryParse(str, out NumId);
            
            if (NumId == 0 || NumId > val.Max() || NumId < val.Min())
            {
                Console.WriteLine($"Существуют Id:");
                foreach (var item in arr){Console.Write(" " + item.Split("#")[0]);}
                Console.WriteLine(Environment.NewLine + $"Введите Id работника из существующих:");
            }

            

        } while (NumId == 0 || NumId > val.Max() || NumId < val.Min());

        foreach (var item in arr)
        {
            if (item.Split("#")[0] == NumId.ToString())
            {
                arr.SetValue($"{CreatUser(setvalue: NumId)}", y);break;
            }
            //номер строки массива 
            y++;
        }
        File.Delete(path);
        File.WriteAllLines(path, arr);
    }
    /// <summary>
    /// Метод создания учетной записи
    /// </summary>
    /// <param name="path"> путь к файлу </param>
    /// <param name="setvalue">точное значение строки для замены </param>
    /// <returns></returns>
    public static string CreatUser(string path = @"homework_7.txt",int setvalue = 0)
    {
        string WorkerInfo = String.Empty;
        string answer;
        int ColLines = 0;
        string[] phrases =
        {
                "Введите Ф.И.О. работника: ", "Введите возраст работника: ","Введите рост работника: ",
                "Введите дату рождения работника: ","Введите место рождения работника: ",
        };
        if (!File.Exists(path))
        {
            using (var sw = new StreamWriter(path))
            {

                for (int i = 0; i < phrases.Length; i++)
                {
                    if (i == 0)
                    {
                        try
                        {
                            ColLines = File.ReadAllLines(path).Length;
                        }
                        catch (Exception) { };
                        Console.WriteLine(phrases[i]);
                        answer = Console.ReadLine();
                        // это Id - порядковый номер работника
                        WorkerInfo = $"{Convert.ToString(ColLines + 1)}#{DateTime.Now}#{answer}";

                    }
                    else
                    {
                        Console.WriteLine(phrases[i]);
                        answer = Console.ReadLine();
                        WorkerInfo += "#" + answer;
                    }
                }
                sw.WriteLine(WorkerInfo);
            }
        }
        else
        {
            for (int i = 0; i < phrases.Length; i++)
            {
                if (i == 0)
                {
                    string[] str = File.ReadAllLines(path);

                    #region проверка точно ли файл пуст
                    var Byte = File.ReadAllBytes(path);
                    bool flag = false;
                    
                    foreach (var item in str)
                    {
                        flag = String.IsNullOrEmpty(item);
                    }
                    #endregion

                    if (flag && Byte.Length != 0) { ColLines = 0;File.Delete(path);/*сносим файл*/ }
                    //это Id - порядковый номер работника
                    else { ColLines = File.ReadAllLines(path).Length; }
                    Console.WriteLine(phrases[i]);
                    answer = Console.ReadLine();
                    if (setvalue == 0) WorkerInfo = $"{Convert.ToString(ColLines + 1)}#{DateTime.Now}#{answer}";
                    else { WorkerInfo = $"{setvalue}#{DateTime.Now}#{answer}"; }

                }
                else
                {
                    Console.WriteLine(phrases[i]);
                    answer = Console.ReadLine();
                    WorkerInfo += $"#{answer}";
                }
            }
            File.AppendAllText(path,Environment.NewLine + WorkerInfo);
        }
        return WorkerInfo;
    }
    /// <summary>
    /// Проверяем существует ли файл
    /// </summary>
    /// <param name="path"></param>
    static bool FileExists(string path = @"homework_7.txt") 
    {
        if (File.Exists(path))
        {
            string[] str = File.ReadAllLines(path);
            var Byte = File.ReadAllBytes(path);
            bool flag = false;
            

            foreach (var item in str)
            {
                flag = String.IsNullOrEmpty(item);
                if (flag && Byte.Length != 0) { File.Delete(path);File.Create(path);return false;/*новый пустой файл*/ }
                else { return true; }
            }
        }
        else { Console.WriteLine("Файл пуст или отсутствует!"); }
        return false;
    }
    /// <summary>
    /// Сортирует файл и перезаписывает сообразно указанному порядку
    /// </summary>
    /// <param name="count"> значение </param>
    /// <param name="path"> путь </param>
    static void ParsBoxSort(int count,string path = @"homework_7.txt") 
    {
        if (Worker.FileExists())
        {
            var Arr = File.ReadAllLines(path);
            List<DateTime> data = new List<DateTime>();
            List<string> dataSort = new List<string>();
            int val = 0;
            //проверяем файл
            if (Worker.FileExists())
            {
                foreach (var item in Arr)
                {
                    data.Add(Convert.ToDateTime(item.Split("#")[1])); val++;
                }
            }
            //Сортируем список по возрастанию
            if (count == 1)
            {
                data.Sort();
                for (int i = 0; i < data.Count; i++)
                {
                    for (int y = 0; y < Arr.Length; y++)
                    {
                        var val_1 = data.ElementAt(i);
                        var val_2 = Convert.ToDateTime(Arr[y].Split("#")[1]);
                        if (val_1 == val_2)
                        {
                            dataSort.Add(Arr[y]);
                        }
                    }
                }
                Console.WriteLine("Сортировка по возрастанию:");
                foreach (var item in dataSort)
                {
                    Console.WriteLine(item);
                }
                File.Delete(path);
                File.WriteAllLines(path, dataSort);
            }
            //по убыванию
            else if (count == 2)
            {
                data.Reverse();
                for (int i = 0; i < data.Count; i++)
                {
                    for (int y = 0; y < Arr.Length; y++)
                    {
                        var val_1 = data.ElementAt(i);
                        var val_2 = Convert.ToDateTime(Arr[y].Split("#")[1]);
                        if (val_1 == val_2)
                        {
                            dataSort.Add(Arr[y]);
                        }
                    }
                }
                Console.WriteLine("Сортировка по убыванию:");
                foreach (var item in dataSort)
                {
                    Console.WriteLine(item);
                }
                File.Delete(path);
                File.WriteAllLines(path, dataSort);
            }
            else if (count == 3)
            {
                DateTime minDate = new DateTime(), maxDate = new DateTime();
                Console.WriteLine($"Диапазон дат от: {data.Min().Date} до:{data.Max().Date}" +
                                  $"\nВведите от какой и до какой даты искать?");
                bool flag = true;

                do
                {
                    Console.WriteLine("Первое значение:");
                    string str = Console.ReadLine();
                    DateTime.TryParse(str, out minDate);
                    Console.WriteLine("Второе значение:");
                    string str1 = Console.ReadLine();
                    DateTime.TryParse(str1, out maxDate);
                    if (minDate != DateTime.MinValue && maxDate != DateTime.MinValue)
                    {
                        DateTime g = data.Min().Date;
                        DateTime f = data.Max().Date;
                        if (minDate <= data.Min().Date && maxDate <= data.Max().Date)
                        {
                            for (int y = 0; y < Arr.Length; y++)
                            {
                                var val_2 = Convert.ToDateTime(Arr[y].Split("#")[1]);
                                if (val_2.Date >= minDate && maxDate <= data.Max().Date && val_2.Date <= maxDate)
                                {
                                    Console.WriteLine(Arr[y]); break;
                                }
                            }
                            flag = false;
                        }
                    }
                    else { Console.WriteLine("Попробуйте еще раз!"); }
                } while (flag);

            }
        }
        else { Console.WriteLine("Файл пуст или отстувует!"); }
    }
    /// <summary>
    /// Метод по выгрузкам дат
    /// </summary>
    public static void LoadData() 
    {
        string str0 = "\n1 - по возрастанию / 2 - по убыванию / 3 - вывести инфо в диапазоне дат";
        Console.WriteLine("Выберите порядок :{0}",str0);
        int num = 0;
        do
        {
            string str1 = Console.ReadLine();
            int.TryParse(str1, out num);
            switch (num)
            {
                case 1: Worker.ParsBoxSort(count: 1); break;
                case 2: Worker.ParsBoxSort(count: 2); break;
                case 3: Worker.ParsBoxSort(count: 3); break;
                default:
                    Console.WriteLine("Попробуйте еще раз!");
                    break;
            }
        } while (num == 0);
    }
   
}
struct Cho
{
    /// <summary>
    /// Метод выбора действия
    /// </summary>
    public static void ice()
    {
        string CreatUs = "1 - Создание записи о работнике";
        string OutputInfoUs = "\n2 - Просмотр записи о работнике";
        string RemoveUs = "\n3 - Удаление записи о работнике";
        string EditInfoUs = "\n4 - Редактирование записи о работнике";
        string LoadData = "\n5 - Диапазон дат";
        Console.WriteLine("{0}{1}{2}{3}{4}", CreatUs, OutputInfoUs, RemoveUs, EditInfoUs, LoadData);
        bool flag;
        do
        {
            string KeyNum = Console.ReadLine();
            flag = int.TryParse(KeyNum, out int switch_on);
            switch (switch_on)
            {
                case 1: Worker.CreatUser(); break;
                case 2: Worker.OutputInfoUser(); break;
                case 3: Worker.RemoveUser(); break;
                case 4: Worker.EditInfoUser(); break;
                case 5: Worker.LoadData(); break;
                default: flag = false; Console.WriteLine("Попробуйте еще раз!"); break;
            }
        } while (!flag);

    }
}
            if (i == 0) { Console.WriteLine($"{phrase[i]}:{UserInfoId[i]}"); }
            else { Console.WriteLine($"{phrase[i]}:{UserInfoId[y]}"); };
        }

    }
    /// <summary>
    /// Метод удаления учетной записи
    /// </summary>
    /// <param name="path"> путь к файлу </param>
    public static void RemoveUser(string path = @"homework_7.txt")
    {

        int NumId = 0;
        var arr = File.ReadAllLines(path);

        Console.WriteLine($"Введите Id работника для его удаления из БД:");
        do
        {
            string str = Console.ReadLine(); 
            int.TryParse(str, out NumId);

            if (NumId == 0 || NumId > File.ReadAllLines(path).Length) 
            {
                Console.WriteLine($"Существуют Id:");
                foreach (var item in arr)
                {
                    Console.Write(" " + item.Split("#")[0]);
                    Console.WriteLine(Environment.NewLine + $"Введите Id работника из существующих:");
                }

            }

        } while (NumId == 0 || NumId > File.ReadAllLines(path).Length);

        List<string> NewArr = new();

        foreach (var item in arr)
        {
            if (item.Split("#")[0] == NumId.ToString())
            {
                arr.SetValue("",Convert.ToUInt32(item.Split("#")[0]) - 1);
                foreach (var item1 in arr)
                {
                    if (item1 != "") NewArr.Add(item1);
                }
                break;
            }
        }
        File.Delete(path);
        File.WriteAllLines(path,NewArr);
    }
    /// <summary>
    /// Метод редактирования учетной записи
    /// </summary>
    /// <param name="path"> путь к файлу </param>
    public static void EditInfoUser(string path = @"homework_7.txt")
    {
        int NumId = 0, i = 0, y = 0;
        var arr = File.ReadAllLines(path);
        int count = File.ReadAllLines(path).Length;
        int[] val = new int[count];
        string[] arr1 = new string[count];
        //определяем  Id
        foreach (var item in arr) { val[i] = Convert.ToInt32(item.Split("#")[0]); i++; }

        Console.WriteLine($"Введите Id работника для изменения информации:");
        do
        {
            string str = Console.ReadLine();
            int.TryParse(str, out NumId);
            
            if (NumId == 0 || NumId > val.Max() || NumId < val.Min())
            {
                Console.WriteLine($"Существуют Id:");
                foreach (var item in arr){Console.Write(" " + item.Split("#")[0]);}
                Console.WriteLine(Environment.NewLine + $"Введите Id работника из существующих:");
            }

            

        } while (NumId == 0 || NumId > val.Max() || NumId < val.Min());

        foreach (var item in arr)
        {
            if (item.Split("#")[0] == NumId.ToString())
            {
                arr.SetValue($"{CreatUser(setvalue: NumId)}", y);break;
            }
            //номер строки массива 
            y++;
        }
        File.Delete(path);
        File.WriteAllLines(path, arr);
    }
    /// <summary>
    /// Метод создания учетной записи
    /// </summary>
    /// <param name="path"> путь к файлу </param>
    /// <param name="setvalue">точное значение строки для замены </param>
    /// <returns></returns>
    public static string CreatUser(string path = @"homework_7.txt",int setvalue = 0)
    {
        string WorkerInfo = String.Empty;
        string answer;
        int ColLines = 0;
        string[] phrases =
        {
                "Введите Ф.И.О. работника: ", "Введите возраст работника: ","Введите рост работника: ",
                "Введите дату рождения работника: ","Введите место рождения работника: ",
        };
        if (!File.Exists(path))
        {
            using (var sw = new StreamWriter(path))
            {

                for (int i = 0; i < phrases.Length; i++)
                {
                    if (i == 0)
                    {
                        try
                        {
                            ColLines = File.ReadAllLines(path).Length;
                        }
                        catch (Exception) { };
                        Console.WriteLine(phrases[i]);
                        answer = Console.ReadLine();
                        // это Id - порядковый номер работника
                        WorkerInfo = $"{Convert.ToString(ColLines + 1)}#{DateTime.Now}#{answer}";

                    }
                    else
                    {
                        Console.WriteLine(phrases[i]);
                        answer = Console.ReadLine();
                        WorkerInfo += "#" + answer;
                    }
                }
                sw.WriteLine("\r" + WorkerInfo);
            }
        }
        else
        {
            for (int i = 0; i < phrases.Length; i++)
            {
                if (i == 0)
                {
                    string[] str = File.ReadAllLines(path);

                    #region проверка точно ли файл пуст
                    var Byte = File.ReadAllBytes(path);
                    bool flag = false;
                    
                    foreach (var item in str)
                    {
                        flag = String.IsNullOrEmpty(item);
                    }
                    #endregion

                    if (flag && Byte.Length != 0) { ColLines = 0;File.Delete(path);/*сносим файл*/ }
                    //это Id - порядковый номер работника
                    else { ColLines = File.ReadAllLines(path).Length; }
                    Console.WriteLine(phrases[i]);
                    answer = Console.ReadLine();
                    if (setvalue == 0) WorkerInfo = $"{Convert.ToString(ColLines + 1)}#{DateTime.Now}#{answer}";
                    else { WorkerInfo = $"{setvalue}#{DateTime.Now}#{answer}"; }

                }
                else
                {
                    Console.WriteLine(phrases[i]);
                    answer = Console.ReadLine();
                    WorkerInfo += $"#{answer}";
                }
            }
            File.AppendAllText(path,Environment.NewLine + WorkerInfo);
        }
        return WorkerInfo;
    }
   
}
struct Cho
{
    /// <summary>
    /// Метод выбора действия
    /// </summary>
    public static void ice()
    {
        string CreatUs = "1 - Создание записи о работнике";
        string OutputInfoUs = "\n2 - Просмотр записи о работнике";
        string RemoveUs = "\n3 - Удаление записи о работнике";
        string EditInfoUs = "\n4 - Редактирование записи о работнике";
        Console.WriteLine("{0}{1}{2}{3}", CreatUs, OutputInfoUs, RemoveUs, EditInfoUs);
        bool flag;
        do
        {
            string KeyNum = Console.ReadLine();
            flag = int.TryParse(KeyNum, out int switch_on);
            switch (switch_on)
            {
                case 1: Worker.CreatUser(); break;
                case 2: Worker.OutputInfoUser(); break;
                case 3: Worker.RemoveUser(); break;
                case 4: Worker.EditInfoUser(); break;
                default: flag = false; Console.WriteLine("Попробуйте еще раз!"); break;
            }
        } while (!flag);

    }
}
