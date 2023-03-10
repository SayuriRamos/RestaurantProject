using Microsoft.VisualBasic;
using RestaurantProject.items;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace curso_de_net_core
{

    class Program
    {
        // Define a delegate type that takes a string parameter and returns void
        public delegate void MenuDelegate(int menuItem);


        public Dictionary<int, MenuDelegate> menu = new Dictionary<int, MenuDelegate>();


        private static Food[] foodArray = new Food[5];
        private static Drink[] drinkArray = new Drink[3];
        private static Dessert[] dessertArray = new Dessert[3];

        private Object[] itemArray;

        private List<Item> cart = new List<Item>();
        

        public static void Main(string[] args)
        {
            Program creat = new Program();
            CreateItems();

            creat.Create();
           
        }


        public static void CreateItems()
        {
            //Add Food
            Food onigiri = new Food
            {
                Name = "Onigiri",
                Price = 30,
                IsSpicy = true
            };

            Food ramen = new Food
            {
                Name = "Ramen",
                Price = 180,
                IsSpicy = false
            };

            Food soba = new Food
            {
                Name = "Soba",
                Price = 175,
                IsSpicy = false
            };

            Food edamame = new Food
            {
                Name = "Edamame",
                Price = 100,
                IsSpicy = true
            };

            Food tenpura = new Food
            {
                Name = "Tenpura",
                Price = 200,
                IsSpicy = false
            };


            foodArray[0] = (onigiri);
            foodArray[1] = (ramen);
            foodArray[2] = (soba);
            foodArray[3] = (edamame);
            foodArray[4] = (tenpura);


            //Add Drinks
            Drink calpis = new Drink
            {
                Name = "Calpis",
                Price = 50,
                IsAlcoholic = false

            };

            Drink greenTea = new Drink
            {
                Name = "Green Tea",
                Price = 50,
                IsAlcoholic = false

            };

            Drink shochu = new Drink
            {
                Name = "Shochu",
                Price = 50,
                IsAlcoholic = true

            };

            drinkArray[0] = (calpis);
            drinkArray[1] = (greenTea);
            drinkArray[2] = (shochu);

            Dessert dorayaki = new Dessert
            {
                Name = "Dorayaki",
                Price = 25,
                IsFrozen = false
            };

            Dessert yatsuhashi = new Dessert
            {
                Name = "Yatsuhashi",
                Price = 25,
                IsFrozen = false
            };

            Dessert yukimiDaifuku = new Dessert
            {
                Name = "Yukimi Daifuku",
                Price = 10,
                IsFrozen = false
            };

            dessertArray[0] = (yatsuhashi);
            dessertArray[1] = (yukimiDaifuku);
            dessertArray[2] = (dorayaki);

        }



        // Define a method that takes a dictionary of menu items and their corresponding delegate methods
        public void OrderItems(Dictionary<int, MenuDelegate> menu)
        {
            // Ask the user to choose a menu item
            Console.WriteLine("Welcome to Sayuri´s Resutoran");

            while(true) {
                
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Order Food");
                Console.WriteLine("2. Order Drink");
                Console.WriteLine("3. Order Dessert");
                Console.WriteLine("4. See Cart");
                Console.WriteLine("5. Checkout");


                try
                {
                    int choice = Convert.ToInt16(Console.ReadLine());

                    // Call the delegate method for the chosen menu item
                    if (menu.ContainsKey(choice))
                    {
                        MenuDelegate delegateMethod = menu[choice];
                        delegateMethod(choice);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Please write a valid option");
                }

            }
        }

        public void OrderFood(int menuItem)
        {
            var cont = 1;

            while (true)
            {
                Console.WriteLine("-- Food --");
                Console.WriteLine("Choose 1 of the options to add to your cart");

                foreach (Food i in foodArray)
                {
                    Console.WriteLine("{0} ", cont + ". " + i.Name);
                    cont++;
                }

                try
                {
                    int choice = Convert.ToInt16(Console.ReadLine());

                    cart.Add(foodArray[choice - 1]);

                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please write a valid option");
                }
            }

            


        }
        public void OrderDrink(int menuItem)
        {
            var cont = 1;

            while (true)
            {
                Console.WriteLine("-- Drink --");
                Console.WriteLine("Choose 1 of the options to add to your cart");

                foreach (Drink i in drinkArray)
                {
                    Console.WriteLine("{0} ", cont + ". " + i.Name);
                    cont++;
                }

                try
                {
                    int choice = Convert.ToInt16(Console.ReadLine());

                    cart.Add(drinkArray[choice - 1]);

                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please write a valid option");
                }
            }
        }

        public void OrderDessert(int menuItem)
        {
            var cont = 1;

            while (true)
            {
                Console.WriteLine("-- Dessert --");
                Console.WriteLine("Choose 1 of the options to add to your cart");

                foreach (Dessert i in dessertArray)
                {
                    Console.WriteLine("{0} ", cont + ". " + i.Name);
                    cont++;
                }

                try
                {
                    int choice = Convert.ToInt16(Console.ReadLine());

                    cart.Add(dessertArray[choice - 1]);

                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please write a valid option");
                }
            }
        }

        public void SeeCart(int menuItem)
        {
            Console.WriteLine("-- Cart --");

            Console.WriteLine("Choose 1 of the following options:");
            var cont = 1;
            foreach (Item i in cart)
            {
                Console.WriteLine("{0} ", cont + ". " + i.Name);
                cont++;
            }

        }

        public void Checkout(int menuItem)
        {
            Console.WriteLine("");
            Console.WriteLine("Choose 1 of the options to add to your cart");

        }

      


        public void Create ()
        {

            menu.Add(1, OrderFood);
            menu.Add(2, OrderDrink);
            menu.Add(3, OrderDessert);
            menu.Add(4, SeeCart);
            menu.Add(5, Checkout);
            
            OrderItems(menu);

        }





    }
}
