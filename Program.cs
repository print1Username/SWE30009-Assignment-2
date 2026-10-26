using System;
using System.Collections.Generic;

// Main Program
class Program {
    // Create a fucntion to print out the list
    // Format: [ 1 2 3 5 ]
    public static string PrintList(List<double> doubleList){
        string outputList = "[";

        foreach (var d in doubleList){
            outputList += $" RM {d:F2} "; // Print out the price by two decimal
        }

        outputList += "]";
        return outputList;
    }

    // Original Version
    public static double CalculateTotal(List<double> doubleList, bool discount = false){
        double value = 0.00;

        foreach (var d in doubleList){
            value += d;
        }

        // If the discount is true, then discount half price
        if (discount){ value *= 0.5; }

        // Calculate SST
        value *= 1.06;

        return value;
    }

    // M1 Version
    // Remove one items
    public static double CalculateTotal_M1(List<double> doubleList, bool discount = false){
        double value = -10.00;

        foreach (var d in doubleList){
            value += d;
        }

        // If the discount is true, then discount half price
        if (discount){ value *= 0.5; }

        // Calculate SST
        value *= 1.06;

        return value;
    }

    // M2 Version
    // Setting the SST to 1.60
    public static double CalculateTotal_M2(List<double> doubleList, bool discount = false){
        double value = 0.00;

        foreach (var d in doubleList){
            value += d;
        }

        // If the discount is true, then discount half price
        if (discount){ value *= 0.5; }

        // Calculate SST
        value *= 1.60;

        return value;
    }

    // M3 Version
    // Setting the Discount to 60%
    public static double CalculateTotal_M3(List<double> doubleList, bool discount = false){
        double value = 0.00;

        foreach (var d in doubleList){
            value += d;
        }

        // If the discount is true, then discount half price
        if (discount){ value *= 0.6; }

        // Calculate SST
        value *= 1.06;

        return value;
    }

    // Without Discount
    public static string Validation1(double so, double fo){
        // k == Additional value
        // SO == Source Output
        // FO == Follow Up Output

        if (fo == so + (k * 1.06)){ return "✓ | Satisfied"; }
        else { return "X | Violated"; }
    }

    // With discount
    public static string Validation2(double so, double fo){
        // k == Additional value
        // SO == Source Output
        // FO == Follow Up Output

        if (fo == so * 0.5){ return "✓ | Satisfied"; }
        else { return "X | Violated"; }
    }

    // Output
    public static void PrintOutput(int m, int mtg, int mr){
        Console.WriteLine();

        if (mtg == 1)
            Console.WriteLine($"****** Program M{m}: Testing MTGs for MR{mr} ******");

        Console.WriteLine("***************************************************");

        if (mtg == 1 && mr == 1) {
            Console.WriteLine("Use Case 1: Customer order different items.");
            Console.WriteLine("If FI is constructed by adding k as a new element in SI, where k > 0.00,  then FO = SO + (k * 1.06)");
        } else if (mtg == 1 && mr == 2) {
            Console.WriteLine("Use Case 2: Price for all items may be halved during late-evening discount hours.");
            Console.WriteLine("If FI is constructed by multiplying every element in SI by 0.5,  then FO = SO * 0.5");
        }

        Console.WriteLine();

        Console.WriteLine($"---- MTG {mtg} ----");

        Console.WriteLine($"SI: {PrintList(source_input)}");
        Console.WriteLine($"SO: RM {CalculateTotal(source_input):F2}");
        Console.WriteLine($"FI: {PrintList(follow_up_input)}");
        Console.WriteLine($"FO: RM {CalculateTotal(follow_up_input):F2}");

        Console.WriteLine();

        if (mr == 1)
            Console.WriteLine($"Expected FO: {CalculateTotal(source_input):F2} + ( {k} × 1.06 ) = {CalculateTotal(follow_up_input):F2}");
        else if (mr == 2)
            Console.WriteLine($"Expected FO: {CalculateTotal(source_input):F2} + ( {k} × 50% × 1.06 ) = {CalculateTotal(follow_up_input, true):F2}");

        if (m == 1 && mr == 1){
            Console.WriteLine($"Actual FO: {CalculateTotal_M1(follow_up_input):F2}");
            Console.WriteLine(Validation1(CalculateTotal(source_input), CalculateTotal_M1(follow_up_input)));
        } else if (m == 2 && mr == 1){
            Console.WriteLine($"Actual FO: {CalculateTotal_M2(follow_up_input):F2}");
            Console.WriteLine(Validation1(CalculateTotal(source_input), CalculateTotal_M2(follow_up_input)));
        } else if (m == 3 && mr == 1){
            Console.WriteLine($"Actual FO: {CalculateTotal_M3(follow_up_input):F2}");
            Console.WriteLine(Validation1(CalculateTotal(source_input), CalculateTotal_M3(follow_up_input)));
        } else if (m == 1 && mr == 2){
            Console.WriteLine($"Actual FO: {CalculateTotal_M1(follow_up_input):F2}");
            Console.WriteLine(Validation2(CalculateTotal(source_input, true), CalculateTotal_M1(follow_up_input, true)));
        } else if (m == 2 && mr == 2){
            Console.WriteLine($"Actual FO: {CalculateTotal_M2(follow_up_input):F2}");
            Console.WriteLine(Validation2(CalculateTotal(source_input, true), CalculateTotal_M2(follow_up_input,true)));
        } else if (m == 3 && mr == 2){
            Console.WriteLine($"Actual FO: {CalculateTotal_M3(follow_up_input):F2}");
            Console.WriteLine(Validation2(CalculateTotal(source_input, true), CalculateTotal_M3(follow_up_input, true)));
        }

        Console.WriteLine();

    }

    // Create two list name SI and FI, and the value k
    static List<double> source_input = new List<double>();
    static List<double> follow_up_input = new List<double>();
    static double k;

    public static void Main(string[] args) {
        Console.WriteLine();
        Console.WriteLine();

        // Add the value into the SI
        source_input.Add(2.50);
        source_input.Add(8.00);
        source_input.Add(10.00);

        // FI == SI
        follow_up_input = new List<double>(source_input);

        // MR1
        // Program M1
        // MTG 1
        k = 12.00;
        follow_up_input.Add(k);
        PrintOutput(1,1,1);

        // MTG 2
        follow_up_input.Remove(k);
        k = 25.50;
        follow_up_input.Add(k);
        PrintOutput(1,2,1);

        // MTG 3
        follow_up_input.Remove(k);
        k = 33.33;
        follow_up_input.Add(k);
        PrintOutput(1,3,1);

        // MTG 4
        follow_up_input.Remove(k);
        k = 0.01;
        follow_up_input.Add(k);
        PrintOutput(1,4,1);

        // MTG 5
        follow_up_input.Remove(k);
        k = 1;
        follow_up_input.Add(k);
        PrintOutput(1,5,1);

        // Program M2
        // MTG 1
        follow_up_input.Remove(k);
        k = 12.00;
        follow_up_input.Add(k);
        PrintOutput(2,1,1);

        // MTG 2
        follow_up_input.Remove(k);
        k = 25.50;
        follow_up_input.Add(k);
        PrintOutput(2,2,1);

        // MTG 3
        follow_up_input.Remove(k);
        k = 33.33;
        follow_up_input.Add(k);
        PrintOutput(2,3,1);

        // MTG 4
        follow_up_input.Remove(k);
        k = 0.01;
        follow_up_input.Add(k);
        PrintOutput(2,4,1);

        // MTG 5
        follow_up_input.Remove(k);
        k = 1;
        follow_up_input.Add(k);
        PrintOutput(2,5,1);

        // Program M3
        // MTG 1
        follow_up_input.Remove(k);
        k = 12.00;
        follow_up_input.Add(k);
        PrintOutput(3,1,1);

        // MTG 2
        follow_up_input.Remove(k);
        k = 25.50;
        follow_up_input.Add(k);
        PrintOutput(3,2,1);

        // MTG 3
        follow_up_input.Remove(k);
        k = 33.33;
        follow_up_input.Add(k);
        PrintOutput(3,3,1);

        // MTG 4
        follow_up_input.Remove(k);
        k = 0.01;
        follow_up_input.Add(k);
        PrintOutput(3,4,1);

        // MTG 5
        follow_up_input.Remove(k);
        k = 1;
        follow_up_input.Add(k);
        PrintOutput(3,5,1);
        
        // MR2
        // Program M1
        // MTG 1
        k = 12.00;
        follow_up_input.Add(k);
        PrintOutput(1,1,2);

        // MTG 2
        follow_up_input.Remove(k);
        k = 25.50;
        follow_up_input.Add(k);
        PrintOutput(1,2,2);

        // MTG 3
        follow_up_input.Remove(k);
        k = 33.33;
        follow_up_input.Add(k);
        PrintOutput(1,3,2);

        // MTG 4
        follow_up_input.Remove(k);
        k = 0.01;
        follow_up_input.Add(k);
        PrintOutput(1,4,2);

        // MTG 5
        follow_up_input.Remove(k);
        k = 1;
        follow_up_input.Add(k);
        PrintOutput(1,5,2);

        // Program M2
        // MTG 1
        follow_up_input.Remove(k);
        k = 12.00;
        follow_up_input.Add(k);
        PrintOutput(2,1,2);

        // MTG 2
        follow_up_input.Remove(k);
        k = 25.50;
        follow_up_input.Add(k);
        PrintOutput(2,2,2);

        // MTG 3
        follow_up_input.Remove(k);
        k = 33.33;
        follow_up_input.Add(k);
        PrintOutput(2,3,2);

        // MTG 4
        follow_up_input.Remove(k);
        k = 0.01;
        follow_up_input.Add(k);
        PrintOutput(2,4,2);

        // MTG 5
        follow_up_input.Remove(k);
        k = 1;
        follow_up_input.Add(k);
        PrintOutput(2,5,2);

        // Program M3
        // MTG 1
        follow_up_input.Remove(k);
        k = 12.00;
        follow_up_input.Add(k);
        PrintOutput(3,1,2);

        // MTG 2
        follow_up_input.Remove(k);
        k = 25.50;
        follow_up_input.Add(k);
        PrintOutput(3,2,2);

        // MTG 3
        follow_up_input.Remove(k);
        k = 33.33;
        follow_up_input.Add(k);
        PrintOutput(3,3,2);

        // MTG 4
        follow_up_input.Remove(k);
        k = 0.01;
        follow_up_input.Add(k);
        PrintOutput(3,4,2);

        // MTG 5
        follow_up_input.Remove(k);
        k = 1;
        follow_up_input.Add(k);
        PrintOutput(3,5,2);

    }
}