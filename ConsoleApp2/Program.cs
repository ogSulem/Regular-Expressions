using System.Text.RegularExpressions;

//one();
//two();
//three();
four();
void one()
{
    Console.Write("Введите строку: ");
    string input = Console.ReadLine();
    if (Regex.IsMatch(input, @"^abcd2023111111102023$"))
    {
        string result = Regex.Replace(input, "2023", "happynewyear");
        Console.WriteLine($"a) {result}");
    }
    else
    {
        Console.WriteLine("a) Строка не соответствует шаблону.");
    }

    Regex regex = new Regex(@"\d");
    Match match = regex.Match(input);
    int[] digits = new int[match.Length];
    int sum = 0, index = 0;
    int max = 99999999;
    for (int i = 0; i < digits.Length; i++)
    {
        digits[i] = int.Parse(match.Value[i].ToString());
        sum += int.Parse(match.Value[i].ToString());
        if (int.Parse(match.Value[i].ToString()) > max)
        {
            max = int.Parse(match.Value[i].ToString());
            index = i + 1;
        }
    }
    Console.Write("b)\nПолученные числа: ");
    foreach (int num in digits) Console.Write($"{num} ");
    Console.WriteLine($"\nИх сумма: {sum}\n" +
        $"Максимальное из них и его порядкоый номер: {max}  |  {index}");


    Console.Write("c) Введите строку: "); //adas123da-3fdsfs+231ads23,31dsa-23,412+321.312das=--+321.0dad-31,da===sa
    string inputC = Console.ReadLine();
    MatchCollection matchesC = Regex.Matches(inputC, @"(-|\+)?\d+((\.|,)\d)?");
    double[] numbersC = new double[matchesC.Count];
    for (int i = 0; i < numbersC.Length; i++)
    {
        double num = double.Parse(matchesC[i].Value.ToString().Replace('.', ','));
        numbersC[i] = num;
    }
    Console.Write("Полученный массив: ");
    foreach (double num in numbersC) Console.Write($"{num} ");
    Console.WriteLine("\nСтрока с заменной дробей на  number: ");
    Console.WriteLine(Regex.Replace(inputC, @"(\+|-)?\d+((\.|,)\d)+", "number"));

    Console.WriteLine("d)Введите строку: "); //C:\Users\Envy\Downloads
    string inputD = Console.ReadLine();
    MatchCollection matchesD = Regex.Matches(inputD, @"\\\w+");
    string[] catalogsD = new string[matchesD.Count];
    for (int i = 0; i < catalogsD.Length; i++)
    {
        string s = matchesD[i].Value.ToString().Replace("\\", "");
        catalogsD[i] = s;
    }
    Console.Write("Названия папок: ");
    foreach (string catalog in catalogsD) Console.Write($"{catalog} ");

    Console.Write("\ne) Введите строку: ");
    string inputE = Console.ReadLine();
    string patternE = @"(^(((0[1-9])|([1-2][0-9])|(3[0-1]))/((01)|([3-9])|(1[0-2]))/((1[6-9][0-9][0-9])|([2-9][0-9][0-9][0-9])))$)|(^(((0[1-9])|([1-2][0-8]))/(02)/((1[6-9][0-9][0-9])|([2-9][0-9][0-9][0-9])))$)|(^((29)/(02)/((1[6-9](((2|4|6|8)(0|4|8))|((1|3|5|7|9)(2|6))|(0(4|8))))|([2-9][0-9](((2|4|6|8)(0|4|8))|((1|3|5|7|9)(2|6))|(0(4|8))))|(1(6|8)00)|((((2|4|6|8)(0|4|8))|((3|5|7|9)(2|6)))00)))$)";
    Console.WriteLine(Regex.IsMatch(inputE, patternE));
}

void two()
{
    Console.WriteLine("a)");
    string[] inputs = new string[5];
    for (int i = 0; i < inputs.Length; i++)
    {
        Console.Write($"Введите {i + 1} строку: ");
        inputs[i] = Console.ReadLine();
    }
    Console.WriteLine("Строки, содержащие подстроку 'cat' 2 раза: ");
    foreach (string input in inputs) if (Regex.Matches(input, @"cat").Count == 2) Console.WriteLine(input);

    Console.WriteLine("b)");
    for (int i = 0; i < inputs.Length; i++, Console.WriteLine())
    {
        string first = inputs[i];
        string second = inputs[i];
        string third = inputs[i];
        string pattern = @"\w{10,}";
        if (Regex.Matches(inputs[i], pattern).Count >= 1)
        {
            first = Regex.Replace(first, pattern, "*");
            MatchCollection matches = Regex.Matches(inputs[i], pattern);
            for (int j = 0; j < matches.Count; j++)
            {
                string rep = matches[j].Value;
                second = Regex.Replace(second, rep.ToString(), rep[0].ToString());
            }
            for (int j = 0; j < matches.Count; j++)
            {
                string rep = matches[j].Value;
                string replace = "";
                for (int s = 0; s < rep.Length; s++) replace += rep[0].ToString();
                third = Regex.Replace(third, rep.ToString(), replace);
            }
        }
        Console.WriteLine($"{first}\n{second}\n{third}");
    }

    Console.Write("c) Введите строку: ");
    string inputC = Console.ReadLine();
    Console.WriteLine(Regex.Replace(inputC, @"ик", ""));

    Console.Write("d) Введите строку: ");
    string inputD = Console.ReadLine();
    if (Regex.IsMatch(inputD, @"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")) Console.WriteLine("Цвет HTML");
    else Console.WriteLine("Не цвет HTML");

    Console.Write("e) Введите строку: ");
    string inputE = Console.ReadLine();
    if (Regex.IsMatch(inputE, "^[A-Fa-f0-9]{8}-[A-Fa-f0-9]{4}-[A-Fa-f0-9]{4}-[A-Fa-f0-9]{4}-[A-Fa-f0-9]{12}$")) Console.WriteLine("Строка GUID");
    else Console.WriteLine("Не строка GUID");

    Console.Write("f) Введите строку с ценами: ");
    string inputF = Console.ReadLine(); //23 USD 99.1 EU 1 USD 23 RUR
    string patrik = @"\d+((\.\d{2})|(\.\d))?";
    MatchCollection RUR = Regex.Matches(inputF, patrik + @"\s?RUR");
    MatchCollection USD = Regex.Matches(inputF, patrik + @"\s?USD");
    MatchCollection EU = Regex.Matches(inputF, patrik + @"\s?EU");
    Console.Write("Введите целевую валюту: ");
    string valute = Console.ReadLine();
    Console.Write($"Введите курс USD к {valute}: ");
    double rateUSD = Convert.ToDouble(Console.ReadLine());
    Console.Write($"Введите курс RUR к {valute}: ");
    double rateRUR = Convert.ToDouble(Console.ReadLine());
    Console.Write($"Введите курс EU к {valute}: ");
    double rateEU = Convert.ToDouble(Console.ReadLine());
    foreach (Match match in RUR)
    {
        Match price = Regex.Match(match.Value.ToString(), patrik);
        double num = double.Parse(price.Value.ToString().Replace('.', ','));
        inputF = Regex.Replace(inputF, match.Value.ToString(), $"{rateRUR * num} {valute}");
    }
    foreach (Match match in USD)
    {
        Match NUM = Regex.Match(match.Value.ToString(), patrik);
        double num = double.Parse(NUM.Value.ToString().Replace('.', ','));
        inputF = Regex.Replace(inputF, match.Value.ToString(), $"{rateUSD * num} {valute}");
    }
    foreach (Match match in EU)
    {
        Match NUM = Regex.Match(match.Value.ToString(), patrik);
        double num = double.Parse(NUM.Value.ToString().Replace('.', ','));
        inputF = Regex.Replace(inputF, match.Value.ToString(), $"{rateEU * num} {valute}");
    }
    Console.WriteLine(inputF);
}

void three()
{
    string pattern = @"^(?=.+[a-z])(?=.+[A-Z])(?=.+\d)(?=.*_).{8,}$";
    Console.Write("Введите пароль: ");
    string password = Console.ReadLine();
    if (Regex.IsMatch(password, pattern)) Console.WriteLine("Норм");
    else Console.WriteLine("Не норм");
}

void four()
{
    string pattern = @"\d\+";
    Console.Write("Введите строку: ");
    string input = Console.ReadLine();
    if (Regex.IsMatch(input, pattern)) Console.WriteLine("Есть +");
    else Console.WriteLine("Нет плюса");
}