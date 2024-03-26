using PcConfigurator.Models.Orders;

namespace PcConfigurator.Tests;

public class TestDataGenerator : IEnumerable<object[]>
{
    public static IEnumerable<object[]> Test1()
    {
        yield return new object[]
        {
            new Specification(
                cpuCoolerName: "Txii3 ms230xx",
                cpuName: "AMD FX-4300",
                gpuName: "KFA2 GeForce 210",
                hdds: new List<string> { "WD10EZEX" },
                motherBoardName: "AFOX IG41-MA7",
                pcCaseName: "DEXP DC-302R",
                powerSupplyName: "EX219185RUS",
                ramSticks: new List<string> { "AGI160004UD128" },
                ssds: new List<string> { "SA400S37" },
                wiFiModulesName: null),
            new OrderStatus.Success(),
        };

        yield return new object[]
        {
            new Specification(
                cpuCoolerName: "Txii3 ms230xx",
                cpuName: "Intel Core i5-12400F",
                gpuName: "KFA2 GeForce 210",
                hdds: new List<string> { "WD10EZEX" },
                motherBoardName: "AFOX A88-MA5",
                pcCaseName: "DEXP DC-302R",
                powerSupplyName: "EX219185RUS",
                ramSticks: new List<string> { "AGI160004UD128" },
                ssds: new List<string> { "SA400S37" },
                wiFiModulesName: "DFG ITRR-6Ts"),
            new OrderStatus.Fail("Unable to connect SSD with motherboard"),
        };

        yield return new object[]
        {
            new Specification(
                cpuCoolerName: "Master nr200p",
                cpuName: "Intel Core i5-12400F",
                gpuName: "KFA2 GeForce 210",
                hdds: new List<string> { "WD10EZEX" },
                motherBoardName: "AF54X J774T-MSx",
                pcCaseName: "DEXP DC-302R",
                powerSupplyName: "EX219185RUS",
                ramSticks: new List<string> { "AGI160004UD128" },
                ssds: new List<string> { "SA400S37" },
                wiFiModulesName: "DFG ITRR-6Ts"),
            new OrderStatus.Success.WarrantiesDisclaimer(),
        };

        yield return new object[]
        {
            new Specification(
                cpuCoolerName: "Txii3 ms230xx",
                cpuName: "AMD FX-4300",
                gpuName: "KFA2 GeForce 210",
                hdds: new List<string> { "WD10EZEX" },
                motherBoardName: "AFOX IG41-MA7",
                pcCaseName: "DEXP DC-302R",
                powerSupplyName: "Super Power Winard 450WA",
                ramSticks: new List<string> { "AGI160004UD128" },
                ssds: new List<string> { "SA400S37" },
                wiFiModulesName: null),
            new OrderStatus.Success.СapacityNonСompliance(),
        };

        yield return new object[]
        {
            new Specification(
                cpuCoolerName: "Txii3 ms230xx",
                cpuName: "AMD iF-2344",
                gpuName: "KFA2 GeForce 210",
                hdds: new List<string> { "WD10EZEX" },
                motherBoardName: "AFOX IG41-MA7",
                pcCaseName: "DEXP DC-302R",
                powerSupplyName: "EX219185RUS",
                ramSticks: new List<string> { "AGI160004UD128" },
                ssds: new List<string> { "SA400S37" },
                wiFiModulesName: null),
            new OrderStatus.Fail("CPU is not supported by motherboard"),
        };
    }

    public IEnumerator<object[]> GetEnumerator() => Test1().GetEnumerator();

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
}