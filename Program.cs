using System.Diagnostics;

Console.WriteLine("Tom OLIVIER 2022");

if (args.Length > 1 &&
    int.TryParse(args[0], out int contractor_id) &&
    int.TryParse(args[1], out int target_id))
{
    try
    {
        var contractor = Process.GetProcessById(contractor_id);
        var target = Process.GetProcessById(target_id);

        contractor.WaitForExit();
        target.Kill();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
else
    Console.WriteLine("Hitman.exe [contractor_id] [target_id}");