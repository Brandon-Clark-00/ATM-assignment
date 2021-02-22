using System;

namespace ConsoleApplication3
{   

    /*
     *   This is the root of program and the entry point
     * 
     *   Class programm contains an array of account objects and a single ATM object  
     * 
     */
    class Program
    {
        private Account[] ac = new Account[3];
        private ATM atm;

        /*
         * This function initilises the 3 accounts 
         * and instantiates the ATM class passing a reference to the account information
         * 
         */
        public Program()
        {
            ac[0] = new Account(300, 1111, 111111);
            ac[1] = new Account(750, 2222, 222222);
            ac[2] = new Account(3000, 3333, 333333);

            atm = new ATM(ac);

        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
    /*
     *   The Account class encapusulates all features of a simple bank account
     */ 
    class Account
    {
        // The attributes for the account
        private int balance;
        private int pin;
        private int accountNum;

        // A constructor that takes initial values for each of the attributes (balance, pin, accountNumber)
        public Account(int balance, int pin, int accountNum)
        {
            this.balance = balance;
            this.pin = pin;
            this.accountNum = accountNum;
        }

        //getter and setter functions for balance
        public int getBalance()
        {
            return balance;
        }
        public void setBalance(int newBalance)
        {
            this.balance = newBalance;
        }

        /*
         *   This funciton allows us to decrement the balance of an account.
         *   It performs a simple check to ensure the balance is greater than
         *   the amount being debeted
         *   
         *   returns:
         *   true if the transactions if possible
         *   false if there are insufficent funds in the account
         */
        public Boolean decrementBalance(int amount)
        {
            if (this.balance > amount)
            {
                balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * This funciton check the account pin against the argument passed to it
         *
         * returns:
         * true if they match
         * false if they do not
         */
        public Boolean checkPin(int pinEntered)
        {
            if (pinEntered == pin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int getAccountNum()
        {
            return accountNum;
        }

    }
    /* 
     *      This is out main ATM class that preforms the actions outlined in the assigment hand out
     *      
     *      the constutor contains the main functionality.
     */
    class ATM
    {
        // Local reference to the array of accounts
        private Account[] ac;

        // This is a reference to the account that is being used
        private Account activeAccount = null;
        
        // The atm constructor takes an array of account objects as a reference
        public ATM(Account[] ac)
        {
            this.ac = ac;
            Console.WriteLine("hello from ATM");

            // An infinite loop to keep the flow of control going on and on
            while (true)
            {

                // Ask for account number and store result in activeAccount (null if no match found)
                activeAccount = this.findAccount();

                if (activeAccount != null)
                {
                    // If the account is found check the pin 
                    if (activeAccount.checkPin(this.promptForPin()))
                    {
                        // If the pin is a match give the options to do stuff to the account (take money out, view balance, exit)
                        dispOptions();
                    }
                }
                else
                {   //if the account number entered is not found let the user know!
                    Console.WriteLine("no matching account found.");
                }

                //wipes all text from the console
                Console.Clear();
            }


        }

        /*
         *    This method promts for the input of an account number,
         *    the string input is then converted to an int.
         *    A for loop is used to check the entered account number
         *    against those held in the account array,
         *    if a match is found a reference to the match is returned;
         *    If the for loop completes with no match we return null
         * 
         */
        private Account findAccount()
        {
            Console.WriteLine("enter your account number..");
            
            int input = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < this.ac.Length; i++)
            {
                if (ac[i].getAccountNum() == input)
                {
                    return ac[i];
                }
            }

            return null;
        }
        /*
         * 
         *  This just prompts the user to enter a pin number
         *  
         * returns the string entered converted to an int
         * 
         */
        private int promptForPin()
        {
            Console.WriteLine("enter pin:");
            String str = Console.ReadLine();
            int pinNumEntered = Convert.ToInt32(str);
            return pinNumEntered;
        }

        /*
         * 
         *  Gives the use the options to do with the account
         *  
         *  prompt for input
         *  and defer to appropriate method based on input
         *  
         */
        private void dispOptions()
        {
            Console.WriteLine("1> take out cash");
            Console.WriteLine("2> balance");
            Console.WriteLine("3> exit");

            int input = Convert.ToInt32(Console.ReadLine());

            if (input == 1)
            {
                dispWithdraw();
            }
            else if (input == 2)
            {
                dispBalance();
            }
            else if (input == 3)
            {
                
             
            }
            else
            {

            }

        }

        /*
         * 
         * offer withdrawable amounts
         * 
         * based on input attempt to withraw the corosponding amount of money
         * 
         */
        private void dispWithdraw()
        {
            Console.WriteLine("1> 10");
            Console.WriteLine("2> 50");
            Console.WriteLine("3> 500");

            int input = Convert.ToInt32(Console.ReadLine());

            if (input > 0 && input < 4)
            {

                //opiton one is entered by the user
                if (input == 1)
                {

                    //attempt to decrement account by 10 punds
                    if (activeAccount.decrementBalance(10))
                    {   
                        //if this is possible display new balance and await key press
                        Console.WriteLine("new balance " + activeAccount.getBalance());
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }else{
                        //if this is not possible inform user and await key press
                         Console.WriteLine("insufficent funds");
                         Console.WriteLine(" (prese enter to continue)");
                         Console.ReadLine();
                    }
                }
                else if (input == 2)
                {
                    if (activeAccount.decrementBalance(50))
                    {
                        Console.WriteLine("new balance " + activeAccount.getBalance());
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("insufficent funds");
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                }
                else if (input == 3)
                {
                    if (activeAccount.decrementBalance(500))
                    {
                        Console.WriteLine("new balance " + activeAccount.getBalance());
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("insufficent funds");
                        Console.WriteLine(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                }
            }
        }
        /*
         *  display balance of activeAccount and await keypress
         *  
         */
        private void dispBalance(){
            if (this.activeAccount != null)
            {
                Console.WriteLine(" your current balance is : "+activeAccount.getBalance());
                Console.WriteLine(" (prese enter to continue)");
                Console.ReadLine();
                
            }
        }
        
    }
}
