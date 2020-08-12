using System;
using System.IO;
using System.Threading;


namespace Bank
{
    /*
    -------------------------------------
    ------------Class People-------------
    -------------------------------------
    */

    class People
    {

        /*We encapsulate variables
        whose values ​​need to 
        be checked*/

        /*There is no need 
        to hide gender and citizenship.
        Because the user will have a 
        choice of answer*/
        #region VERIABLES Class People
        private string name;
        private int age;
        public string citizenship;
        public string gender;

        public int money;
        #endregion
        public People()
        {
        }

        public People(string Name ,string Surname , int Age , string Citizenship , string Gender) 
        {
            Name = this.name;
            Age = this.age;
            Citizenship = this.citizenship;
            Gender = this.gender;

        }

        public virtual void Hello()
        {
            Console.WriteLine("Thank you for choosing our bank!");
        }
       
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2 || value == "fool")
                {
                    Console.WriteLine("Unccorect input");
                }
                else
                {
                    if (value[0] == value[1])
                    {
                        Console.WriteLine("Unccorect input! Maybe sticky keys");
                    }
                    else
                    {
                        name = value;
                    }
                                         
                }
               
            }
        }

        public int Age
        {
            
            get
            {
                return age;
            }
            set
            {
               if(value < 18 || value > 60 || string.IsNullOrWhiteSpace(value.ToString()))
               {
                    Console.WriteLine("Uncorrect age.");
               }
                else
                {
                    string s = "s";
                    if (Int32.TryParse(s, out value))
                    {
                        Console.WriteLine("Format exception");
                    }
                    else
                    {
                        value = age;
                    }
                }
            }
        }
        public  int AllClientsMoney(int sum)
        {
            Console.WriteLine($"Client have {sum} uah");

            return sum;
        }
        
    }

    /*
    -------------------------------------
    ------------Class Workers------------
    -------------------------------------
    */

    class Workers : People
    {
        int salary;
        private int rate = 7000;
        private float coefficient;
        public int experience;

        /*
        This method helps the employee 
        calculate his monthly salary.
        Based on his work experience, 
        the number of hours worked per 
        month changes and the coefficient
        */
        public int CountingSalary(int hoursInmonth)
        {
            if(experience > 1 && experience < 3)
            {
                coefficient = 1.32f;
                salary = rate * (int)coefficient * hoursInmonth;

                Console.WriteLine($"You have {salary}");
            }
            else if (experience > 3)
            {
                coefficient = 1.7f;
                salary = rate *(int)coefficient * hoursInmonth;

                Console.WriteLine($"You have {salary}");
            }
            return salary;
        }

        //Override parent`s method Hello, just for practice in this project
        public override void Hello()
        {
            Console.WriteLine("Thank you for working in our bank");
        }
    } 
    /*
    -------------------------------------
    ------------Class Program------------
    -------------------------------------
    */
    class Program
    {
        static void Main(string[] args)
        {
            Workers worker = new Workers();
            worker.experience = 2;
            
            Console.WriteLine("Input your name");

            worker.Name = Console.ReadLine();
            string name = worker.Name;
            Console.WriteLine($"Nice to meet you, {name}");
            Console.WriteLine("Data is prepearing! Waiting, please");
            /*
            We simulate receiving data 
            from the server, or simply 
            loading a working program
            */
            Thread.Sleep(2000);
            
            #region SettingsOfConsole
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Cyan;
            #endregion

            Console.WriteLine("Complete the list of clients.");
            Console.WriteLine("Client #1");
            Console.WriteLine("Input Name , Age , Citizenship , Gender");

            #region Client#1
            People client1 = new People();
            client1.Name = Console.ReadLine();

            client1.Age = Convert.ToInt32(Console.ReadLine());
            client1.citizenship = Console.ReadLine();
            client1.gender = Console.ReadLine();

            string[] mainClient = {"Client #1", client1.Name, client1.Age.ToString(), 
            client1.citizenship, client1.gender , "The end info" };

            var clients = new string[mainClient.Length];

            /*
            The FOR loop helps us call the ToString() 
            method for each element of the mainClient 
            array.This will help us write data to a file.
           */

            for (var i = 0; i < mainClient.Length; i++)
            {
                clients[i] = mainClient[i].ToString();
            }
            /*
             Write info about clients into the file 
             */
            File.WriteAllLines("clients",clients);
            #endregion

            Console.Clear();

            #region Client2
            Console.WriteLine("Client #2");
            Console.WriteLine("Input Name , Age , Citizenship , Gender");

            People client2 = new People();
            client1.Name = Console.ReadLine();
            client1.Age = Convert.ToInt32(Console.ReadLine());
            client1.citizenship = Console.ReadLine();
            client1.gender = Console.ReadLine();

            string[] mainClient2 = {"Client #1", client2.Name, client2.Age.ToString(),
            client2.citizenship, client2.gender , "The end info" };

            clients = new string[mainClient2.Length];

            /*
             Hmmmm.....Why doesnt work this loop FOR. Think about.
             */

            //for (var i = 0; i < mainClient2.Length; i++)
            //{
            //    clients[i] = mainClient2[i].ToString();
            //}
            //File.WriteAllLines("clients", clients);
            #endregion Clients2

            client1.AllClientsMoney(19000);
            client2.AllClientsMoney(28000);

            Console.Clear();

            Console.WriteLine("Input CLIENT to go to client mode and WORKER to go to worker mode");
            string mode = Console.ReadLine();
            Console.WriteLine("Waiting, please");
            Thread.Sleep(1500);

            Console.Clear();

            if(mode == "CLIENT")
            {
                menu:
                Console.WriteLine("Choose the operation (enter a number of operation)");

                Console.WriteLine(" 1. Info about client \n 2. Show the balance \n " +
                    "3. Convent to $ \n 4. Exit");

                int choose = Convert.ToInt32(Console.ReadLine());
                /*
                 We can choose points of menu using SWITCH
                 Its more comfortable then use IF ELSE
                 */
                switch (choose)
                {
                    case 1:
                        Console.Clear();

                        Console.WriteLine($"\tInfo about client: \n Name : {client1.Name} \n" +
                            $" Age : {client1.Age} \n Citizenship : {client1.citizenship} \n" +
                            $" Gender : {client1.gender} ");
                        Console.WriteLine("Go to menu? Press any key:");
                        Console.ReadLine();
                        goto menu;
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Your balance :" + client1.AllClientsMoney(19000));

                        Console.WriteLine("Go to menu? Press any key:");
                        Console.ReadLine();
                        goto menu;
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Convert from uah to $. Input sum :");
                        Converting(int.Parse(Console.ReadLine()));

                        Console.WriteLine("Go to menu? Press any key:");
                        Console.ReadKey();
                        goto menu;
                        break;
                    case 4:
                        Console.Clear();

                        Console.WriteLine("Are you sure? Input OK to exit or No to go to menu");
                        string answ = Console.ReadLine();
                        if (answ == "OK")
                        {
                            break;
                        }
                        else if (answ == "No")
                        {
                            goto menu;
                        }
                        break;

                }

            }
            else if (mode == "WORKER")
            {
                //password = 12345678
                int countTry = 3;
                passAgain:

                Console.WriteLine("Input password, please!");
                Console.WriteLine($"Trying {countTry}");
                string password = Console.ReadLine();

                string truePassword = password;

                if(password == truePassword)
                {
                    Console.WriteLine("Waiting, please");
                    Thread.Sleep(1500);

                    worker.Hello();
                    Console.WriteLine($"Choose information that you need , {worker.Name}");

                    WorkewMenu:

                    Console.WriteLine(" 1. Info about salary \n 2. About company \n 3. Change the password \n " +
                        " 4. Exit");
                    int workChooseMode = Convert.ToInt32(Console.ReadLine());

                    //After every operation call Console.Clear();

                    switch (workChooseMode)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Your salary in this month");
                            worker.CountingSalary(40);

                            Console.WriteLine("Go to menu? Press any key:");
                            Console.ReadLine();
                            goto WorkewMenu;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Our company is engaged in high - " +
                                "quality service to our customers.We store all " +
                                "information about clients in our 'clients' file.");

                            Console.WriteLine("Go to menu? Press any key:");
                            Console.ReadLine();
                            goto WorkewMenu;
                        case 3:
                            Console.Clear();

                            Console.WriteLine("The mode changing the password. Input your old password :");
                            string oldPass = Console.ReadLine();

                            if(oldPass == password)
                            {
                                try
                                {
                                    Console.WriteLine("Okey! Input the new password");
                                    string newPass = Console.ReadLine();
                                    password = newPass;
                                    truePassword = newPass;
                                    Console.WriteLine("Password was changed");
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Please, correct type");
                                }
                                finally
                                {
                                    Console.WriteLine("Have a nice day");
                                }

                            }

                            Console.WriteLine("Go to menu? Press any key:");
                            Console.ReadLine();
                            goto WorkewMenu;
                        case 4:
                            Console.Clear();

                            Console.WriteLine("Are you sure? Input OK to exit or No to go to menu");
                            string answ = Console.ReadLine();
                            if (answ == "OK")
                            {
                                break;
                            }
                            else if (answ == "No")
                            {
                                goto WorkewMenu;
                            }
                            break;
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Wrong password");
                    countTry--;

                    Console.Clear();
                    if(countTry < 1)
                    {
                        Console.WriteLine("Hacking attempt!!! Click something to close program");
                        Console.ReadLine();
                    }
                    else
                    {
                        goto passAgain;
                    }
                    
                }

                
            }
            
            
            void Converting(int convertSum)
            {
                int result;
                //convertSum = Convert.ToInt32(Console.ReadLine());
                if (convertSum > client1.AllClientsMoney(19000))
                {
                    Console.WriteLine("Something is wrong! Sum more then you have");
                }
                else
                {
                     result = convertSum * 25;
                    Console.WriteLine($"You have in dollars {result}");
                }
                
            }

        }
    }
}

//Thank you for watching



/*
 * сделать пароль для клиента 
 * доделать меню работника 
 * дописать ком-рии всему коду
 * ДОВЕСТИ КОД ДО УМА!!!!
 */