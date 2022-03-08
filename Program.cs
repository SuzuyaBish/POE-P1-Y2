public abstract class Expense
{
    public abstract void getUserData();
    public abstract double Ceil(double fIn, int decimals);
    public abstract bool willBeApproved(double monthlyRepayment, int grossMonthlyIncome);
    public abstract void calculateHomeLoan();
    public abstract void calculateMoneyAfterDeductions();

    //public static void Main(string[] args)
    //{
    //    Expense part1 = new Expense();

    //    Console.WriteLine("What is your montly income: ");
    //    int grossMonthlyIncome = Convert.ToInt32(Console.ReadLine());
    //    Console.WriteLine();

    //    Console.WriteLine("What is your estimated monthly tax: ");
    //    int monthlyTax = Convert.ToInt32(Console.ReadLine());
    //    Console.WriteLine();

    //    Console.WriteLine("What are your estimated monthly expenditures: ");
    //    string[] expenditureTitles = { "Groceries", "Water and lights", "Travel costs (including petrol)", "Cell phone and telephone", "Other expenses" };
    //    int[] expenditures = new int[5];

    //    for (int i = 0; i < expenditures.Length; i++)
    //    {
    //        Console.WriteLine(expenditureTitles[i]);
    //        expenditures[i] = Convert.ToInt32(Console.ReadLine());
    //    }
    //    Console.WriteLine();

    //    Console.WriteLine("Renting (1) or Buying (2): ");
    //    int isRenting = Convert.ToInt32(Console.ReadLine());

    //    int monthlyRentalAmount = 0;
    //    int[] homeLoanValues = new int[4];
    //    string[] homeLoanTitles = { "Purchase price of the property:", "Total deposit:", "Interest rate (percentage):", "Number of months to repay (between 240 and 360):" };

    //    if (isRenting == 1)
    //    {
    //        monthlyRentalAmount = Convert.ToInt32(Console.ReadLine());
    //    }
    //    else
    //    {
    //        for (int i = 0; i < homeLoanValues.Length; i++)
    //        {
    //            Console.WriteLine(homeLoanTitles[i]);
    //            homeLoanValues[i] = Convert.ToInt32(Console.ReadLine());
    //            Console.WriteLine();
    //        }
    //    }

    //    double wihtoutDeposit = homeLoanValues[0] - homeLoanValues[1];
    //    double monthlyCalc = (wihtoutDeposit * (1 + (homeLoanValues[2] / 100.00) * (homeLoanValues[3] / 12))) / homeLoanValues[3];
    //    double payableMonthly = part1.Ceil(monthlyCalc, 2);
    //    string approvalMessage = part1.willBeApproved(payableMonthly, grossMonthlyIncome) == true ? "UNLIKELY" : "LIKELY";

    //    Console.WriteLine((1 / 3) * grossMonthlyIncome);
    //    Console.WriteLine("Your home loan is " + approvalMessage + " to be approved");

    //    int incomeAfterDeductions = grossMonthlyIncome - monthlyTax;
    //    for (int i = 0; i < expenditures.Length; i++)
    //    {
    //        incomeAfterDeductions -= expenditures[i];
    //    }
    //    Console.WriteLine("Money available after deductions: ");
    //    Console.WriteLine(incomeAfterDeductions);
    //}
}

public abstract class UserData : Expense
{
    int grossMonthlyIncome;
    int monthlyTax;
    string[] expenditureTitles;
    int[] expenditures = new int[5];

    public override void getUserData()
    {
        Console.WriteLine("What is your montly income: ");
        grossMonthlyIncome = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        Console.WriteLine("What is your estimated monthly tax: ");
        monthlyTax = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        Console.WriteLine("What are your estimated monthly expenditures: ");
        expenditureTitles = new string[] { "Groceries", "Water and lights", "Travel costs (including petrol)", "Cell phone and telephone", "Other expenses" };


        for (int i = 0; i < expenditures.Length; i++)
        {
            Console.WriteLine(expenditureTitles[i]);
            expenditures[i] = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine();
    }
}

public abstract class HomeLoan : Expense
{
    public override double Ceil(double fIn, int decimals)
    {
        double mul = Math.Pow(10, Convert.ToDouble(decimals));
        return Math.Ceiling(fIn * mul) / mul;
    }

    public override bool willBeApproved(double monthlyRepayment, int grossMonthlyIncome)
    {
        double thirdOf = grossMonthlyIncome / 3;
        return monthlyRepayment > thirdOf;
    }

    public override void calculateHomeLoan()
    {
        HomeLoan homeLoan = new HomeLoan();

        Console.WriteLine("Renting (1) or Buying (2): ");
        int isRenting = Convert.ToInt32(Console.ReadLine());

        int monthlyRentalAmount = 0;
        int[] homeLoanValues = new int[4];
        string[] homeLoanTitles = { "Purchase price of the property:", "Total deposit:", "Interest rate (percentage):", "Number of months to repay (between 240 and 360):" };

        if (isRenting == 1)
        {
            monthlyRentalAmount = Convert.ToInt32(Console.ReadLine());
        }
        else
        {
            for (int i = 0; i < homeLoanValues.Length; i++)
            {
                Console.WriteLine(homeLoanTitles[i]);
                homeLoanValues[i] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            }
        }

        double wihtoutDeposit = homeLoanValues[0] - homeLoanValues[1];
        double monthlyCalc = (wihtoutDeposit * (1 + (homeLoanValues[2] / 100.00) * (homeLoanValues[3] / 12))) / homeLoanValues[3];
        double payableMonthly = part1.Ceil(monthlyCalc, 2);
        string approvalMessage = part1.willBeApproved(payableMonthly, grossMonthlyIncome) == true ? "UNLIKELY" : "LIKELY";

        Console.WriteLine((1 / 3) * grossMonthlyIncome);
        Console.WriteLine("Your home loan is " + approvalMessage + " to be approved");
    }
}

public abstract class MoneyAfterDeductions : Expense
{
    public override void calculateMoneyAfterDeductions()
    {
        int incomeAfterDeductions = grossMonthlyIncome - monthlyTax;
        for (int i = 0; i < expenditures.Length; i++)
        {
            incomeAfterDeductions -= expenditures[i];
        }
        Console.WriteLine("Money available after deductions: ");
        Console.WriteLine(incomeAfterDeductions);
    }
}
