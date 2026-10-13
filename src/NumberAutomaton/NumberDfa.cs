namespace NumberAutomaton;

public static class NumberDfa
{
    public const string DeadState = "qd";
    public const string Digits = "0123456789";
    public const string Signs = "+-";

    public static readonly char[] Alphabet = "0123456789.+-".ToCharArray();

    public static Dfa Build()
    {
        var states = new List<string> { "q0", "q1", "q2", "q3", "q4", "q5", DeadState };
        var alphabet = Alphabet.ToList();
        var transitions = new Dictionary<(string, char), string>();

// Hàm Set để thiết lập các trạng thái chuyển tiếp trong DFA
        void Set(string from, string symbols, string to)
        {
            foreach (var c in symbols)
                transitions[(from, c)] = to;
        }

        foreach (var state in states)
            foreach (var symbol in alphabet)
                transitions[(state, symbol)] = DeadState;
// từ bảng trạng thái đi qua
        Set("q0", Signs, "q1");
        Set("q0", Digits, "q2");
        Set("q0", ".", "q3");

        Set("q1", Digits, "q2");
        Set("q1", ".", "q3");

        Set("q2", Digits, "q2");
        Set("q2", ".", "q4");

        Set("q3", Digits, "q5");

        Set("q4", Digits, "q5");

        Set("q5", Digits, "q5");
// lúc này dfa đã được xây dựng xong, trả về đối tượng Dfa với các trạng thái, bảng chữ cái, trạng thái bắt đầu, trạng thái chấp nhận và các chuyển tiếp
        return new Dfa(states, alphabet, "q0", new[] { "q2", "q4", "q5" }, transitions);
    }
}
