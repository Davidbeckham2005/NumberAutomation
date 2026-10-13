using NumberAutomaton;
var dfa = NumberDfa.Build();

if (args.Length > 0)
{
    foreach (var s in args)
        Console.WriteLine($"{Show(s)}  ->  {(dfa.Accepts(s) ? "HỢP LỆ (là một giá trị số)" : "KHÔNG hợp lệ")}");
    return;
}

while (true)
{
    PrintMenu();
    Console.Write("Chọn: ");
    var choice = Console.ReadLine()?.Trim();

    Console.WriteLine();
    switch (choice)
    {
        case "1":
            CheckOne(dfa);
            break;
        case "0":
            Console.WriteLine("Kết thúc.");
            return;
        default:
            Console.WriteLine("Lựa chọn không hợp lệ.");
            break;
    }

    Console.WriteLine();
}

static void PrintMenu()
{
    Console.WriteLine("================ AUTOMATON NHẬN SỐ THẬP PHÂN ================");
    Console.WriteLine("Σ = {0,1,2,3,4,5,6,7,8,9,.,+,-}");
    Console.WriteLine("1. Kiểm tra một chuỗi đầu vào");
    Console.WriteLine("0. Thoát");
    Console.WriteLine("=============================================================");
}

static void CheckOne(Dfa dfa)
{
    while (true)
    {
        Console.Write("Nhập chuỗi cần kiểm tra (gõ 'q' để quay lại): ");
        var input = Console.ReadLine();
        if (input is null || input.Trim().Equals("q", StringComparison.OrdinalIgnoreCase))
            return;

        Console.WriteLine($"{Show(input)}  ->  {(dfa.Accepts(input) ? "HỢP LỆ (là một giá trị số)" : "KHÔNG hợp lệ")}");
    }
}
static string Show(string s) => s.Length == 0 ? "\"\"" : $"\"{s}\"";
