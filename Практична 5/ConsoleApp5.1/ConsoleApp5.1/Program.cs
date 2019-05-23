using ConsoleApp5._1.Data;
using ConsoleApp5._1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5._1
{
    class Program
    {

        public static void PayBills(int userid, float amount)
        {

            int paymid = 0;
            int bankid = 0;
            int cardid = 0;
            bool flag = false;
            

            using (BillsPS context = new BillsPS())
            {
                var paym = context.PaymentMethods.ToList();
                foreach (var u in paym)
                {
                    if (userid == u.UserId)
                    {
                        flag = true;
                        paymid = u.PaymentMethodId;
                        bankid = u.BankAccountId;
                        cardid = u.CreditCardId;
                        break;

                    }
                    else
                    {
                        flag = false;

                    }
                }

                bool flagBank = false;
                bool flagCard = false;

                if (flag == true)
                {
                    var bankAccounts = context.BankAccounts.ToList().Where(p => p.BankAccountId == bankid);
                    var creditCards = context.CreditCards.ToList().Where(p => p.CreditCardId == cardid);

                    Console.WriteLine("Your Bank accounts :  ");
                    foreach (var b in bankAccounts)
                    {
                        Console.WriteLine("-- ID : " + b.BankAccountId);
                        Console.WriteLine("-- Bank Name : " + b.BankName);
                        Console.WriteLine("-- Balance : " + b.Balance);

                        if (b.Balance > amount || b.Balance == amount)
                        {
                            flagBank = true;
                        }
                        else
                        {
                            flagBank = false;

                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("Your Credit cards :  ");
                    foreach (var c in creditCards)
                    {
                        Console.WriteLine("-- ID : " + c.CreditCardId);
                        Console.WriteLine("-- Limit : " + c.Limit);

                        if (c.Limit > amount || c.Limit == amount)
                        {
                            flagCard = true;
                        }
                        else
                        {
                            flagCard = false;
                        }
                    }

                    Console.WriteLine();
                    int l = 0;

                    Console.Write("Do you want withdraw money from Bank or Card (1 - Bank , other symbol - Card) : ");
                    l = Convert.ToInt32(Console.ReadLine());

                    if( l == 1)
                    {
                        int d = 0;
                        Console.Write("Input Bank Account ID : ");
                        d = Convert.ToInt32(Console.ReadLine());

                        var bankaccounts = context.BankAccounts.ToList().Where(p => p.BankAccountId == d);

                        foreach(var b in bankaccounts)
                        {
                            if (flagBank == true)
                            {
                                b.Balance = b.Balance - amount;
                                context.SaveChanges();
                                Console.WriteLine("Mission completed!");


                            }
                            else
                            {
                                Console.WriteLine("Insufficient funds!");
                            }
                        }
                       



                    }
                    else
                    {

                        int d = 0;
                        Console.Write("Input Card ID : ");
                        d = Convert.ToInt32(Console.ReadLine());
                        var creditcards = context.CreditCards.ToList().Where(p => p.CreditCardId == d);

                        foreach(var c in creditcards)
                        {
                            if(flagCard == true)
                            {
                                c.Limit = c.Limit - amount;
                                c.MoneyOwned = c.MoneyOwned + amount;
                                context.SaveChanges();
                                Console.WriteLine("Mission completed!");

                            }
                            else
                            {
                                Console.WriteLine("Insufficient funds!");
                            }
                        }


                    }

                }
                else
                {
                    Console.WriteLine("UserId not found!");
                }


            }
        }

        static void Main(string[] args)
        {
            int userid = 0;
            int paymid = 0;
            int bankid = 0;
            int cardid = 0;
            using (ConsoleApp5._1.Data.BillsPS context = new ConsoleApp5._1.Data.BillsPS())
            {
                //context.Database.Initialize(true);
                Console.Write("Input UserId : ");
                userid = Convert.ToInt32(Console.ReadLine());
                bool flag = false;
                var paym = context.PaymentMethods.ToList();
                foreach(var u in paym)
                {
                    if(userid == u.UserId)
                    {
                        flag = true;
                        paymid = u.PaymentMethodId;
                        bankid = u.BankAccountId;
                        cardid = u.CreditCardId;
                        break;
                      
                    }
                    else
                    {
                        flag = false;
                        
                    }
                }


                if(flag == true)
                {
                    var bankAccounts = context.BankAccounts.ToList().Where(p=> p.BankAccountId == bankid);
                    var creditCards = context.CreditCards.ToList().Where(p => p.CreditCardId == cardid);

                    Console.WriteLine("Bank Accounts : ");
                    foreach(var b in bankAccounts)
                    {
                        Console.WriteLine(" -- ID : " + b.BankAccountId);
                        Console.WriteLine(" -- Balance : " + b.Balance);
                        Console.WriteLine(" -- Bank : " + b.BankName);
                        Console.WriteLine(" -- SWIFT : " + b.SwiftCode);
                        Console.WriteLine();

                    }
                    Console.WriteLine("Credit Cards : ");

                    foreach (var b in creditCards)
                    {
                        Console.WriteLine(" -- ID : " + b.CreditCardId);
                        Console.WriteLine(" -- Limit : " + b.Limit);
                        Console.WriteLine(" -- Money Owned : " + b.MoneyOwned);
                        Console.WriteLine(" -- LimitLeft : " + b.LimitLeft);
                        Console.WriteLine(" -- Expiration Date : " + b.ExpirationDate);
                        Console.WriteLine();
                    }

                }
                else
                {
                    Console.WriteLine("UserId not found!");
                }

                int k;
                Console.WriteLine();
                Console.WriteLine("Do you want to Withdraw money? (1 - 'yes', other symbol -'no') : ");
                k = Convert.ToInt32(Console.ReadLine());

                if(k == 1)
                {
                    int usid;
                    float money;
                    Console.WriteLine();
                    Console.WriteLine("Input Your Id : ");
                    usid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("How much money : ");
                    money = float.Parse(Console.ReadLine());


                    PayBills(usid, money);
                }
                else
                {
                    Console.WriteLine("Cancel!");
                }


             
                

            }
            Console.ReadKey();
        }
    }
}
