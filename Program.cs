﻿public abstract class Expense
{
    int grossMonthlyIncome;
    int monthlyTax;
    int[]? expenditure = new int[5];
    int monthlyRentalAmount;
    int[]? homeLoanValues = new int[4];
    int incomeAterDeductions;

    public int GrossMonthlyIncome { get => grossMonthlyIncome; set => grossMonthlyIncome = value; }
    public int MonthlyTax { get => monthlyTax; set => monthlyTax = value; }
    public int[]? Expenditure { get => expenditure; set => expenditure = value; }
    public int MonthlyRentalAmount { get => monthlyRentalAmount; set => monthlyRentalAmount = value; }
    public int[]? HomeLoanValues { get => homeLoanValues; set => homeLoanValues = value; }
    public int IncomeAterDeductions { get => incomeAterDeductions; set => incomeAterDeductions = value; }
}

public class UserData : Expense
{ 
    public void GetUserData()
    {
        Console.WriteLine("What is your montly income: ");
        GrossMonthlyIncome = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        Console.WriteLine("What is your estimated monthly tax: ");
        MonthlyTax = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        Console.WriteLine("What are your estimated monthly expenditures: ");
        string[] expenditureTitles = { "Groceries", "Water and lights", "Travel costs (including petrol)", "Cell phone and telephone", "Other expenses" };

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(expenditureTitles[i]);
            Expenditure[i] = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine();
    }

    public class HomeLoan : UserData
    {
        public double Ceil(double fIn, int decimals)
        {
            double mul = Math.Pow(10, Convert.ToDouble(decimals));
            return Math.Ceiling(fIn * mul) / mul;
        }

        public bool willBeApproved(double monthlyRepayment, int grossMonthlyIncome)
        {
            double thirdOf = grossMonthlyIncome / 3;
            return monthlyRepayment > thirdOf;
        }

        public void CalcHomeLoan()
        {

            Console.WriteLine("Renting (1) or Buying (2): ");
            int isRenting = Convert.ToInt32(Console.ReadLine());

            string[] homeLoanTitles = { "Purchase price of the property:", "Total deposit:", "Interest rate (percentage):", "Number of months to repay (between 240 and 360):" };

            if (isRenting == 1)
            {
                MonthlyRentalAmount = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine(homeLoanTitles[i]);
                    HomeLoanValues[i] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                }
            }

            double wihtoutDeposit = HomeLoanValues[0] - HomeLoanValues[1];
            double monthlyCalc = (wihtoutDeposit * (1 + (HomeLoanValues[2] / 100.00) * (HomeLoanValues[3] / 12))) / HomeLoanValues[3];
            double payableMonthly = Ceil(monthlyCalc, 2);
            string approvalMessage = willBeApproved(payableMonthly, GrossMonthlyIncome) == true ? "UNLIKELY" : "LIKELY";

            Console.WriteLine("Your home loan is " + approvalMessage + " to be approved");
        }

        public class SalaryAfterDeductions : UserData
        {
            public void getSalaryAfterDeductions()
            {
                IncomeAterDeductions = GrossMonthlyIncome - MonthlyTax;

                for (int i = 0; i < Expenditure.Length; i++)
                {
                    IncomeAterDeductions -= Expenditure[i];
                }
                Console.WriteLine("Money available after deductions: ");
                Console.WriteLine(IncomeAterDeductions);
            }
        }
    }
}






public class MakeWork
{
    public static void Main(string [] args)
    {
        UserData userData = new UserData();
        userData.GetUserData();
        userData.CalcHomeLoan();
        salaryAfterDeductions.getSalaryAfterDeductions();
    }
}



//public static void Main(string[] args)
//{
//    Expense part1 = new Expense();

//Console.WriteLine("What is your montly income: ");
//int grossMonthlyIncome = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine();

//Console.WriteLine("What is your estimated monthly tax: ");
//int monthlyTax = Convert.ToInt32(Console.ReadLine());
//Console.WriteLine();

//Console.WriteLine("What are your estimated monthly expenditures: ");
//string[] expenditureTitles = { "Groceries", "Water and lights", "Travel costs (including petrol)", "Cell phone and telephone", "Other expenses" };
//int[] expenditures = new int[5];

//for (int i = 0; i < expenditures.Length; i++)
//{
//    Console.WriteLine(expenditureTitles[i]);
//    expenditures[i] = Convert.ToInt32(Console.ReadLine());
//}
//Console.WriteLine();

//Console.WriteLine("Renting (1) or Buying (2): ");
//int isRenting = Convert.ToInt32(Console.ReadLine());

//int monthlyRentalAmount = 0;
//int[] homeLoanValues = new int[4];
//string[] homeLoanTitles = { "Purchase price of the property:", "Total deposit:", "Interest rate (percentage):", "Number of months to repay (between 240 and 360):" };

//if (isRenting == 1)
//{
//    monthlyRentalAmount = Convert.ToInt32(Console.ReadLine());
//}
//else
//{
//    for (int i = 0; i < homeLoanValues.Length; i++)
//    {
//        Console.WriteLine(homeLoanTitles[i]);
//        homeLoanValues[i] = Convert.ToInt32(Console.ReadLine());
//        Console.WriteLine();
//    }
//}

//double wihtoutDeposit = homeLoanValues[0] - homeLoanValues[1];
//double monthlyCalc = (wihtoutDeposit * (1 + (homeLoanValues[2] / 100.00) * (homeLoanValues[3] / 12))) / homeLoanValues[3];
//double payableMonthly = part1.Ceil(monthlyCalc, 2);
//string approvalMessage = part1.willBeApproved(payableMonthly, grossMonthlyIncome) == true ? "UNLIKELY" : "LIKELY";

//Console.WriteLine((1 / 3) * grossMonthlyIncome);
//Console.WriteLine("Your home loan is " + approvalMessage + " to be approved");

//int incomeAfterDeductions = grossMonthlyIncome - monthlyTax;
//for (int i = 0; i < expenditures.Length; i++)
//{
//    incomeAfterDeductions -= expenditures[i];
//}
//Console.WriteLine("Money available after deductions: ");
//Console.WriteLine(incomeAfterDeductions);
//}