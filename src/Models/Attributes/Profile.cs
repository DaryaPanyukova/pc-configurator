namespace PcConfigurator.Models.Attributes;

public class Profile
{
    public Profile(int voltage, int frequency, Timing timings)
    {
        Voltage = voltage;
        Frequency = frequency;
        Timings = timings;
    }

    public int Voltage { get; private set; }
    public int Frequency { get; private set; }
    public Timing Timings { get; private set; }
}