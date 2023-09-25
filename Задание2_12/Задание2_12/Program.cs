using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание2_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ComandShoot = "1";
            const string CommandCover = "2";
            const string CommandReload = "3";
            const string CommandTakeAim = "4";
            const string DantesShoot = "1";
            const string DantesDodge = "2";
            const string DantesUltraShoot = "3";

            float pushkinUltraDamage = 35;
            float dantesUltraDamage = 20;
            float pushkinUltraArmor = 0.5f;
            float dantesUltraArmor = 0.5f;
            float pushkinDamageDafault = 10;
            float dantesDamaeDefault = 10;
            float pushkinArmorDefault = 1;
            float dantesArmorDefault = 1;
            float pushkinDamage = pushkinDamageDafault;
            float dantesDamage = dantesDamaeDefault;
            float pushkinHealth = 100;
            float dantesHealth = 100;
            float pushkinArmor = pushkinArmorDefault;
            float dantesArmor = dantesArmorDefault;

            string dantesAction = DantesUltraShoot;
            string userChoise = string.Empty;

            bool isDuelWorking = true;
            bool haveDantesMoveset = true;
            bool isBulletReloaded = true;
            bool isPushkinsTurn = true;

            Console.WriteLine("Добро пожаловать на последнюю дуэль мистер Пушкин!");
            Console.WriteLine("Я расскажу вам о вариантах ваших действий от которых зависит итог вашего поединка с д'Антесом:\n");

            while (isDuelWorking == true)
            {
                isPushkinsTurn = true;

                while (isPushkinsTurn == true)
                {
                    if (isBulletReloaded == true)
                    {
                        Console.WriteLine("Пистолет заряжен");
                    }
                    else
                    {
                        Console.WriteLine("Пистолет разряжен");
                    }

                    Console.WriteLine($"Ваше здоровье - {pushkinHealth}");
                    Console.WriteLine($"Здоровье д'Антеса - {dantesHealth}\n");
                    Console.WriteLine($"{ComandShoot} - Пистолетный выстрел. Наносит {pushkinDamage} урона");
                    Console.WriteLine($"{CommandCover} - Прекрыться рукой. Поглащает половину урона");
                    Console.WriteLine($"{CommandReload} - Перезарядиться");
                    Console.WriteLine($"{CommandTakeAim} - Прицелиться. Увеличивает урон, но пропускает ход\n\n");
                    
                    Console.Write("Введите команду: ");
                    userChoise = Console.ReadLine();
                    Console.Clear();

                    switch (userChoise)
                    {
                        case ComandShoot:

                            if (isBulletReloaded == true)
                            {
                                dantesHealth -= pushkinDamage * dantesArmor;
                                isBulletReloaded = false;
                                Console.WriteLine($"Вы стреляете нанося д'Антесу {pushkinDamage * dantesArmor}урона");
                            }
                            else
                            {
                                Console.WriteLine($"Пистолет разряжен - выстрел невозможен");
                            }
                            dantesArmor = dantesArmorDefault;
                            pushkinDamage = pushkinDamageDafault;
                            isPushkinsTurn = false;
                            break;

                        case CommandCover:
                            pushkinArmor = pushkinUltraArmor;
                            dantesArmor = dantesArmorDefault;
                            pushkinDamage = pushkinDamageDafault;
                            isPushkinsTurn = false;
                            Console.WriteLine($"Вы прикрываетесь рукой");
                            break;

                        case CommandReload:

                            if (isBulletReloaded == false)
                            {
                                isBulletReloaded = true;
                                Console.WriteLine("Вы перезарядили пистолет");
                            }
                            else
                            {
                                Console.WriteLine("Пистолет уже заряжен");
                            }
                            dantesArmor = dantesArmorDefault;
                            pushkinDamage = pushkinDamageDafault;
                            isPushkinsTurn = false;
                            break;

                        case CommandTakeAim:
                            pushkinDamage = pushkinUltraDamage;
                            dantesArmor = dantesArmorDefault;
                            isPushkinsTurn = false;
                            Console.WriteLine("Вы прицелились");
                            break;

                        default:
                            Console.WriteLine("Не верное значение\n");
                            break;
                    }
                }

                if (haveDantesMoveset)
                {
                    switch (dantesAction)
                    {
                        case DantesUltraShoot:
                            dantesDamage = dantesUltraDamage;
                            pushkinHealth -= dantesDamage * pushkinArmor;
                            dantesAction = DantesShoot;
                            Console.WriteLine($"д'Антес делает прицельный выстрел и наносит вам {dantesDamage * pushkinArmor} урона.\n");
                            pushkinArmor = pushkinArmorDefault;
                            dantesDamage = dantesDamaeDefault;
                            break;

                        case DantesShoot:
                            pushkinHealth -= dantesDamage * pushkinArmor;
                            dantesAction = DantesDodge;
                            Console.WriteLine($"д'Аантес делает выстрел и наносит вам {dantesDamage * pushkinArmor} урона.\n");
                            pushkinArmor = pushkinArmorDefault;
                            break;

                        case DantesDodge:
                            dantesArmor = dantesUltraArmor;
                            dantesAction = DantesDodge;
                            haveDantesMoveset = false;
                            Console.WriteLine("д'Антес заслонился рукой\n");
                            pushkinArmor = pushkinArmorDefault;
                            break;
                    }
                }
                else
                {
                    switch (dantesAction)
                    {
                        case DantesDodge:
                            dantesArmor = dantesUltraArmor;
                            dantesAction = DantesShoot;
                            Console.WriteLine("д'Антес заслонился рукой\n");
                            pushkinArmor = pushkinArmorDefault;
                            break;

                        case DantesShoot:
                            pushkinHealth -= dantesDamage * pushkinArmor;
                            dantesAction = DantesUltraShoot;
                            Console.WriteLine($"д'Антес делает выстрел и наносит вам {dantesDamage * pushkinArmor} урона.\n");
                            pushkinArmor = pushkinArmorDefault;
                            break;

                        case DantesUltraShoot:
                            dantesDamage = dantesUltraDamage;
                            pushkinHealth -= dantesDamage * pushkinArmor;
                            dantesAction = DantesUltraShoot;
                            haveDantesMoveset = true;
                            Console.WriteLine($"д'Антес делает прицельный выстрел и наносит вам {dantesDamage * pushkinArmor} урона.\n");
                            pushkinArmor = pushkinArmorDefault;
                            dantesDamage = dantesDamaeDefault;
                            break;
                    }

                }

                if (dantesHealth <= 0 || pushkinHealth <= 0)
                {
                    isDuelWorking = false;
                }
            }

            if (pushkinHealth <= 0 && dantesHealth <= 0)
            {
                Console.WriteLine("Кровавая ничья");
            }

            if (dantesHealth <= 0 && pushkinHealth > 0)
            {
                Console.WriteLine("Вы выиграли дуэль");
            }

            if (dantesHealth > 0 && pushkinHealth <= 0)
            {
                Console.WriteLine("Вы проиграли дуэль");
            }
        }
    }
}
