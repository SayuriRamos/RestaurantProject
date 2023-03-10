using Microsoft.VisualBasic;
using RestaurantProject.items;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

/* 
 * This file is simulating a japanese restaurant, where the customer can order from 3 different types of items. 
 * The customer can view, add, and delete items from cart. 
 * Checkout is also implemented, with the simulation of "delivery" in a txt file with details of the order (the path may not work for you, please review it beforehand (line 541)).
 * 
 * Sayuri Ramos Higuera
 */

namespace curso_de_net_core
{

    class Program
    {
        // Create a Delegate for main Menu of the restaurant
        public delegate void MenuDelegate(int menuItem);

        //create dictionary for the main menu
        public Dictionary<int, MenuDelegate> menu = new Dictionary<int, MenuDelegate>();

        //arrays that save the items that are offered
        private static Food[] foodArray = new Food[5];
        private static Drink[] drinkArray = new Drink[3];
        private static Dessert[] dessertArray = new Dessert[3];

        //this is the car list where the products added are saved
        private List<Item> cart = new List<Item>();
        
        
        public static void Main(string[] args)
        {
            //Fill the arrays with food
            CreateItems();

            
            Program creat = new Program();
            creat.Create();
           
        }

        /// <summary>
        /// Create items like food, drinks, and desserts
        /// </summary>
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

            //Add food to array
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

            //add drinks to array
            drinkArray[0] = (calpis);
            drinkArray[1] = (greenTea);
            drinkArray[2] = (shochu);

            //Add desserts
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

            //Add desserts to array
            dessertArray[0] = (yatsuhashi);
            dessertArray[1] = (yukimiDaifuku);
            dessertArray[2] = (dorayaki);

        }

        /// <summary>
        /// Method to add menu options to dictionary
        /// </summary>
        public void Create()
        {

            menu.Add(1, OrderFood);
            menu.Add(2, OrderDrink);
            menu.Add(3, OrderDessert);
            menu.Add(4, SeeCart);
            menu.Add(5, Checkout);

            OrderItems(menu);

        }



        /// <summary>
        /// The main menu is displayed and delegates are used to reference the methods for each option
        /// </summary>
        /// <param name="menu"></param>
        public void OrderItems(Dictionary<int, MenuDelegate> menu)
        {
            // Ask the user to choose a menu item
            Console.WriteLine("\n\nWelcome to Sayuri´s Resutoran");

            while(true) {
                
                Console.WriteLine("\nPlease choose an option:");
                Console.WriteLine("1. Order Food");
                Console.WriteLine("2. Order Drink");
                Console.WriteLine("3. Order Dessert");
                Console.WriteLine("4. See Cart");
                Console.WriteLine("5. Checkout");

                
                try
                {
                    // get input from customer
                    int choice = Convert.ToInt16(Console.ReadLine()); 

                    // Call the delegate method for the chosen menu item
                    if (menu.ContainsKey(choice))
                    {
                        MenuDelegate delegateMethod = menu[choice];
                        delegateMethod(choice);
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid choice, please choose another option");
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("\nPlease write a valid option");
                }

            }
        }

        /// <summary>
        /// Method that is used if the customer wants to add food to the carts, called from the main menu
        /// </summary>
        /// <param name="menuItem"></param>
        public void OrderFood(int menuItem)
        {
            // A counter is used to 
            var cont = 1;

            while (true)
            {
                Console.WriteLine("\n-- Food --");
                Console.WriteLine("Choose 1 of the options to add to your cart");

                //Print in console the options of food
                foreach (Food i in foodArray)
                {
                    Console.WriteLine("{0} ", cont + ". " + i.Name);
                    cont++;
                }

                try
                {
                    //get input froom the customer on what food the wants to add to cart
                    int choice = Convert.ToInt16(Console.ReadLine());

                    //the food is added to cart
                    cart.Add(foodArray[choice - 1]);

                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nPlease write a valid option");
                    cont = 1;
                }
            }

        }

        /// <summary>
        /// Method that is used if the customer wants to add drinks to the carts, called from the main menu
        /// </summary>
        /// <param name="menuItem"></param>
        public void OrderDrink(int menuItem)
        {
            var cont = 1;

            while (true)
            {
                Console.WriteLine("\n-- Drink --");
                Console.WriteLine("Choose 1 of the options to add to your cart");

                //Print in console the options of drinks
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
                    Console.WriteLine("\nPlease write a valid option");
                    cont = 1;
                }
            }
        }

        /// <summary>
        /// Method that is used if the customer wants to add desserts to the carts, called from the main menu
        /// </summary>
        /// <param name="menuItem"></param>
        public void OrderDessert(int menuItem)
        {
            var cont = 1;

            while (true)
            {
                Console.WriteLine("\n-- Dessert --");
                Console.WriteLine("Choose 1 of the options to add to your cart");

                //Print in console the options of desserts
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
                    Console.WriteLine("\nPlease write a valid option");
                    cont = 1;
                }
            }
        }

        /// <summary>
        /// Method to see cart and be able to delete an item or checkout. 
        /// </summary>
        /// <param name="menuItem"></param>
        public void SeeCart(int menuItem)
        {
            // if the carts is empty
            if (cart.Count == 0)
            {
                Console.WriteLine("You have no items in your cart, please add some before checkout :D");
            }
            else
            {

                Console.WriteLine("\n------- Cart -------");
                var cont = 1;
                foreach (Item i in cart)
                {
                    Console.WriteLine("{0} ", cont + ". " + i.Name + "  $" + i.Price);
                    cont++;
                }


                while (true)
                {
                    Console.WriteLine("\nChoose 1 of the following options:");
                    Console.WriteLine("1. Delete items from cart" +
                        "\n2. Checkout");

                    try
                    {
                        int choice = Convert.ToInt16(Console.ReadLine());

                        if (choice == 1)
                        {
                            
                            DeleteItem();

                            //print new cart
                            Console.WriteLine("\n------- NEW Cart -------");
                            cont = 1;

                            foreach (Item i in cart)
                            {
                                Console.WriteLine("{0} ", cont + ". " + i.Name + "  $" + i.Price);
                                cont++;
                            }

                            break;
                        }
                        else if (choice == 2)
                        {
                            Checkout(5);
                            break;
                        }
                        else
                        {
                            //trow exception if other numbers are written
                            throw new Exception("\nThe number is not valid");

                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nPlease write a valid option");
                        cont = 1;
                    }
                };
            }


        }

        /// <summary>
        /// Method to do checkout of the cart
        /// </summary>
        /// <param name="menuItem"></param>
        public void Checkout(int menuItem)
        {
            // if the cart is empty, you cannot checkout
            if (cart.Count == 0)
            {
                Console.WriteLine("\nBefore checkout, please add items to the cart");
            }
            else {
                while (true)
                {
                    //create a string to save all the text with the items and the total, this is goign to be saved in a txt file
                    string deliveryText = "Item & Price";

                    var cont = 1;
                    Console.WriteLine("\n-- Cart --");
                    Console.WriteLine("Item & Price");

                    

                    foreach (Item i in cart)
                    {
                        deliveryText = deliveryText + "\n" + cont + ". " + i.Name + "  $" + i.Price;
                        Console.WriteLine("{0} ", cont + ". " + i.Name + "  $" + i.Price);

                        cont++;
                    }

                    // string that saves the total price
                    string total = totalCart();
                    Console.WriteLine(total);

                    deliveryText = deliveryText + "\n" + total;

                    //Gives the option to customer to cancel or confirm checkout
                    Console.WriteLine("\n\nPlease choose and option: " +
                        "\n1. Confirm Checkout" +
                        "\n2. Cancel");

                    try
                    {
                        int choice = Convert.ToInt16(Console.ReadLine());

                        if (choice == 1)
                        {
                            delivery(deliveryText);
                            Environment.Exit(0);
                        }
                        else if (choice == 2)
                        {
                            break;
                        }
                        else
                        {
                            //trow exception if other numbers are written
                            throw new Exception("\nThe number is not valid");

                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nPlease write a valid option");
                        cont = 1;
                    }
                }
            }
        }


        /// <summary>
        /// Method that deleted an item from cart
        /// </summary>
        public void DeleteItem()
        {
            while (true)
            {
                var cont = 1;
                Console.WriteLine("\n-- Cart --");
                Console.WriteLine("Select the item to delete");

                //print items in cart
                foreach (Item i in cart)
                {
                    Console.WriteLine("{0} ", cont + ". " + i.Name + "  $" + i.Price);
                    cont++;
                }

                try
                {
                    int choice = Convert.ToInt16(Console.ReadLine());

                    //remove from list
                    cart.Remove(cart[choice - 1]);

                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nPlease write a valid option");
                    cont = 1;
                }
                
            };
        }

        /// <summary>
        /// Method to calculate the total price of the order
        /// </summary>
        /// <returns></returns>
        public string totalCart()
        {
            int total = 0;

            //iterates through the cart and adds all the prices into one variable 
            foreach (Item i in cart)
            {
                total = total + i.Price;
            }
            string totalCart = "\nTotal = " + total.ToString();

            return totalCart;
        }

        /// <summary>
        /// Create a txt file to save the order and simulatte delivery
        /// </summary>
        /// <param name="totalcart"></param>
        public void delivery(string totalcart)
        {
            Console.OutputEncoding = Encoding.Unicode;

            //The txt file is saved on the desktop, please change it if you want it saved in another folder
            var  path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                              "delivery.txt");

            File.WriteAllText(path, totalcart);

            //final message
            Console.WriteLine("\n\n\nThe delivery is done!" +
                "\n thank you for shopping with us\n\n\n");

        }





    }
}
