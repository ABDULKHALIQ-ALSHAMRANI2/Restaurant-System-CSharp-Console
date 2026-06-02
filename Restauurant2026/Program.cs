using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant2026
{
    internal class Program
    {
        // [EN] Main entry point of the program
        // [AR] نقطة الدخول الرئيسية للبرنامج
        static void Main(string[] args)
        {
            // [EN] Set console encoding to UTF-8 to support emojis and special characters
            // [AR] ضبط ترميز الكونسول إلى UTF-8 لدعم الإيموجي والرموز الخاصة
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine(" Welcome To Our Restaurant 🍔☕");
            ManageRestaurantSystem();
        }

        // [EN] Main system manager to handle loop navigation and main menus
        // [AR] الدالة الرئيسية لإدارة النظام والتحكم بالرجوع والقوائم الرئيسية
        static void ManageRestaurantSystem()
        {
            // [EN] Repository for items ordered and the total accumulated price
            // [AR] مستودع لتخزين الطلبات والمجموع الإجمالي المتراكم للأموال
            List<string> myOrderList = new List<string>();
            double dTotalPrice = 0;

            bool bRunning = true;
            while (bRunning)
            {
                Console.WriteLine("\n-----------------------------------------------------------");
                Console.WriteLine(" Please choose from the main menu:");
                Console.WriteLine(" Breakfast (B)\n Fast Food (F)\n Drinks (D)\n Print Invoice & Pay (P)\n Exit (E)");
                Console.WriteLine("-----------------------------------------------------------");

                char cMainChoice;
                char.TryParse(Console.ReadLine(), out cMainChoice);
                cMainChoice = char.ToUpper(cMainChoice);

                switch (cMainChoice)
                {
                    case 'B':
                        // [EN] Pass the order list and total price reference to be populated in the breakfast menu
                        // [AR] تمرير قائمة الطلبات ومرجع المجموع ليتم تعبئتها داخل قائمة الفطور
                        ShowBreakfastMenu(myOrderList, ref dTotalPrice);
                        break;

                    case 'F':
                        Console.Clear();
                        Console.WriteLine("\n[Fast Food Menu - Under Development 🛠️]");
                        break;

                    case 'D':
                        Console.Clear();
                        Console.WriteLine("\n[Drinks Menu - Under Development 🛠️]");
                        break;

                    case 'P':
                        Console.Clear();
                        // [EN] Print the consolidated final receipt
                        // [AR] طباعة الفاتورة النهائية الموحدة
                        PrintFinalInvoice(myOrderList, dTotalPrice);
                        break;

                    case 'E':
                        Console.WriteLine("\n~~~~~~~~~( Thank you, see you later )~~~~~~~~~");
                        bRunning = false; // [EN] Break the main loop to close the application / [AR] كسر اللوب الرئيسي لإغلاق البرنامج
                        break;

                    default:
                        Console.WriteLine("❌ Invalid choice! Please select a valid option.");
                        break;
                }
            }
        }

        // [EN] Displays the breakfast menu items and handles item selection
        // [AR] تعرض عناصر قائمة الفطور وتتعامل مع اختيار الوجبات
        static void ShowBreakfastMenu(List<string> orderList, ref double totalPrice)
        {
            char cSubChoice = ' ';
            while (cSubChoice != 'B') // [EN] Loop until the user chooses to go back / [AR] يستمر اللوب حتى يختار المستخدم الرجوع
            {
                Console.Clear();
                Console.WriteLine("\n--- Breakfast Menu ---");
                Console.WriteLine(" Toast with cheese and jam - 10$ (J)");
                Console.WriteLine(" Toast with cheese and eggs - 9$ (E)");
                Console.WriteLine(" Toasted bread with cheese and tomatoes - 8$ (T)");
                Console.WriteLine(" Back to Main Menu (B)");
                Console.WriteLine("----------------------");

                char.TryParse(Console.ReadLine(), out cSubChoice);
                cSubChoice = char.ToUpper(cSubChoice);

                string sMealName = "";
                double dPrice = 0;

                if (cSubChoice == 'J') { sMealName = "Toast with cheese and jam"; dPrice = 10; }
                else if (cSubChoice == 'E') { sMealName = "Toast with cheese and eggs"; dPrice = 9; }
                else if (cSubChoice == 'T') { sMealName = "Toasted bread with cheese and tomatoes"; dPrice = 8; }
                else if (cSubChoice == 'B') { break; } // [EN] Exit breakfast loop and return to main menu / [AR] الخروج من لوب الفطور والرجوع للقائمة الرئيسية
                else
                {
                    Console.WriteLine("❌ Invalid choice!");
                    Console.ReadKey();
                    continue; // [EN] Restart loop to alert the user / [AR] إعادة اللوب لتنبيه المستخدم
                }

                // [EN] Call the unified order confirmation function
                // [AR] استدعاء دالة تأكيد الطلبات الموحدة
                ConfirmOrder(sMealName, dPrice, orderList, ref totalPrice);
            }
        }

        // [EN] Unified function to confirm adding an item to the cart
        // [AR] دالة موحدة لتأكيد إضافة الوجبة إلى سلة المشتريات
        static void ConfirmOrder(string sMealName, double dPrice, List<string> orderList, ref double totalPrice)
        {
            Console.Clear();
            Console.WriteLine($"\n🛒 You selected: {sMealName} \t Price: {dPrice}$");
            Console.WriteLine("To confirm adding to cart, press (A)...\nTo cancel, press (S)...");

            char cConfirm;
            char.TryParse(Console.ReadLine(), out cConfirm);
            cConfirm = char.ToUpper(cConfirm);

            if (cConfirm == 'A')
            {
                // [EN] Add the selected meal to the list and increment the total price
                // [AR] إضافة الوجبة المختارة إلى القائمة وزيادة السعر الإجمالي
                orderList.Add(sMealName + $" ({dPrice}$)");
                totalPrice += dPrice;

                Console.WriteLine("=========================================");
                Console.WriteLine("✅ Added to cart successfully!");
                Console.WriteLine("=========================================");
            }
            else
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("❌ Canceled! Not added to cart.");
                Console.WriteLine("=========================================");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        // [EN] Generates and displays the official structured invoice with tax and live date/time
        // [AR] توليد وعرض الفاتورة الرسمية المنظمة مع الضرائب والوقت والتاريخ الحي
        static void PrintFinalInvoice(List<string> orderList, double totalPrice)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("          🍔 FAZZA RESTAURANT ☕         ");
            Console.WriteLine("       Jeddah, Saudi Arabia 🇸🇦            ");
            Console.WriteLine("     Tax Number: 300123456700003         ");
            Console.WriteLine("-----------------------------------------");

            // [EN] Retrieve the current date and time from the computer system
            // [AR] جلب الوقت والتاريخ الحاليين من نظام الكمبيوتر
            DateTime currentDateTime = DateTime.Now;
            Console.WriteLine($" Date: {currentDateTime.ToString("dd/MM/yyyy")}");
            Console.WriteLine($" Time: {currentDateTime.ToString("hh:mm:ss tt")}");
            Console.WriteLine("=========================================");
            Console.WriteLine("              YOUR ORDERS                ");
            Console.WriteLine("=========================================");

            if (orderList.Count == 0)
            {
                Console.WriteLine(" Your cart is empty! No items ordered yet.");
            }
            else
            {
                // [EN] Loop through and print each ordered item
                // [AR] مرُور طباعي على كل الوجبات المطلوبة داخل القائمة
                foreach (string item in orderList)
                {
                    Console.WriteLine($" 🔹 {item}");
                }
                Console.WriteLine("-----------------------------------------");

                // [EN] Calculate 15% VAT and compute the final total due
                // [AR] احتساب ضريبة القيمة المضافة 15% وحساب الإجمالي النهائي المستحق
                double dVatAmount = totalPrice * 0.15;
                double dFinalTotal = totalPrice + dVatAmount;

                // [EN] :F2 formats numbers to 2 decimal places cleanly
                // [AR] التنسيق :F2 يقوم بعرض الأرقام بخانتين عشريتين بشكل نظيف
                Console.WriteLine($" Subtotal: {totalPrice:F2}$");
                Console.WriteLine($" VAT 15%: {dVatAmount:F2}$");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($" TOTAL DUE: {dFinalTotal:F2}$ 💰");
            }
            Console.WriteLine("=========================================");
            Console.WriteLine("              Thank You                  ");
            Console.WriteLine("=========================================");
            Console.WriteLine("\nPress any key to return to Main Menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}