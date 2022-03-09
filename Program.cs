//What to do with the monthly rental amount
//Should the monthly rental amount or property thing come off of deductions

public abstract class Expense : IExpense
{
    // Fields for use later in the program
    int grossMonthlyIncome;
    int monthlyTax;
    int[]? expenditure = new int[5];
    int monthlyRentalAmount;
    int[]? homeLoanValues = new int[4];
    int incomeAfterDeductions;


    //Constructor for the fields
    protected Expense(int grossMonthlyIncome, int monthlyTax, int[]? expenditure, int monthlyRentalAmount, int[]? homeLoanValues, int incomeAfterDeductions)
    {
        GrossMonthlyIncome = grossMonthlyIncome;
        MonthlyTax = monthlyTax;
        Expenditure = expenditure;
        MonthlyRentalAmount = monthlyRentalAmount;
        HomeLoanValues = homeLoanValues;
        IncomeAfterDeductions = incomeAfterDeductions;
    }


    // Getters and setters for my fields
    public int GrossMonthlyIncome { get => grossMonthlyIncome; set => grossMonthlyIncome = value; }
    public int MonthlyTax { get => monthlyTax; set => monthlyTax = value; }
    public int[]? Expenditure { get => expenditure; set => expenditure = value; }
    public int MonthlyRentalAmount { get => monthlyRentalAmount; set => monthlyRentalAmount = value; }
    public int[]? HomeLoanValues { get => homeLoanValues; set => homeLoanValues = value; }
    public int IncomeAfterDeductions { get => incomeAfterDeductions; set => incomeAfterDeductions = value; }   
    

    //Default implementations of the three main functions of the program
    public abstract void GetUserData();
    public abstract void CalcHomeLoan();
    public abstract void GetSalaryAfterDeductions();
}

public interface IExpense
{
    //Instantiation of functions
    public void GetUserData();
    public void CalcHomeLoan();
    public void GetSalaryAfterDeductions();
}


//Implementation class
public class ProcessExpenses : Expense
{
    //Instantiation of base constructor
    public ProcessExpenses(int grossMonthlyIncome, int monthlyTax, int[]? expenditure, int monthlyRentalAmount, int[]? homeLoanValues, int incomeAfterDeductions) : base(grossMonthlyIncome, monthlyTax, expenditure, monthlyRentalAmount, homeLoanValues, incomeAfterDeductions)
    {
        GrossMonthlyIncome = grossMonthlyIncome;
        MonthlyTax = monthlyTax;
        Expenditure = expenditure;
        MonthlyRentalAmount = monthlyRentalAmount;
        HomeLoanValues = homeLoanValues;
        IncomeAfterDeductions = incomeAfterDeductions;

        //Calling my functions
        GetUserData();
        CalcHomeLoan();
        GetSalaryAfterDeductions();
    }

    //Function for getting user information from gross salary to their list of expenses
    public override void GetUserData()
    {
        Console.Write("What is your montly income: R ");
        GrossMonthlyIncome = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        Console.Write("What is your estimated monthly tax: R ");
        MonthlyTax = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        Console.WriteLine("What are your estimated monthly expenditures:");
        string[] expenditureTitles =
        {
            "Groceries: R ", "Water and lights: R ", "Travel costs (including petrol): R ", "Cell phone and telephone: R ",
            "Other expenses: R "
        };

        for (int i = 0; i < 5; i++)
        {
            Console.Write(expenditureTitles[i]);
            Expenditure[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine();
    }

    //Function for calculating the upper ceiling of the decimals of the monthly payable amount
    public double Ceil(double fIn, int decimals)
    {
        double mul = Math.Pow(10, Convert.ToDouble(decimals));
        return Math.Ceiling(fIn * mul) / mul;
    }


    //Function to calculate the monthly home loan repayment
    public override void CalcHomeLoan()
    {
        Console.Write("Renting (1) or Buying (2): ");
        int isRenting = Convert.ToInt32(Console.ReadLine());

        string[] homeLoanTitles = { "Purchase price of the property: R ", "Total deposit: R ", "Interest rate (percentage): ", "Number of months to repay (between 240 and 360): " };

        if (isRenting == 1)
        {
            Console.Write("What is your monthly rental amount: R ");
            MonthlyRentalAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Your monthly rental amount: " + MonthlyRentalAmount);
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Write(homeLoanTitles[i]);
                HomeLoanValues[i] = Convert.ToInt32(Console.ReadLine());
            }

            double wihtoutDeposit = HomeLoanValues[0] - HomeLoanValues[1];
            double monthlyCalc = (wihtoutDeposit * (1 + (HomeLoanValues[2] / 100.00) * (HomeLoanValues[3] / 12))) / HomeLoanValues[3]; // Simple interest formula
            double payableMonthly = Ceil(monthlyCalc, 2);
            string approvalMessage = payableMonthly > (GrossMonthlyIncome / 3) ? "UNLIKELY" : "LIKELY";

            Console.WriteLine();
            Console.WriteLine("Your home loan is " + approvalMessage + " to be approved");
            Console.WriteLine();
        }
    }

    //Function to calculate available money after deductions
    public override void GetSalaryAfterDeductions()
    {
        IncomeAfterDeductions = GrossMonthlyIncome - MonthlyTax;

        for (int i = 0; i < Expenditure.Length; i++)
        {
            IncomeAfterDeductions -= Expenditure[i];
        }
        Console.WriteLine("Money available after deductions: R " + IncomeAfterDeductions);
    }
}

//Function used for running the program
public class Print
{
    public static void Main()
    {
        ProcessExpenses processExpenses = new ProcessExpenses(0, 0, new int[5], 0, new int[4], 0);
    }
}