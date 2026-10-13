namespace NumberAutomaton;

public sealed class Dfa
{
    private readonly Dictionary<(string State, char Symbol), string> _transitions;
    public IReadOnlyList<string> States { get; }
    public IReadOnlyList<char> Alphabet { get; }
    public string InitialState { get; }
    public IReadOnlySet<string> AcceptingStates { get; }

    public Dfa(
        IReadOnlyList<string> states,
        IReadOnlyList<char> alphabet,
        string initialState,
        IEnumerable<string> acceptingStates,
        IReadOnlyDictionary<(string, char), string> transitions)
    {
        States = states;
        Alphabet = alphabet;
        InitialState = initialState;
        AcceptingStates = acceptingStates.ToHashSet();
        _transitions = new Dictionary<(string, char), string>(transitions);
    }

    public bool Accepts(string input)
    {
        var current = InitialState;
        foreach (var symbol in input)
        {
            if (!_transitions.TryGetValue((current, symbol), out var next))
                return false;
            current = next;
        }
        return AcceptingStates.Contains(current);
    }
}
