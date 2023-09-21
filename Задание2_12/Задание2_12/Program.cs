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
            float pushkinUltraDamage = 50;
            float dantesUltraDamage = 30;
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
            const string Shoot = "1";
            const string Cover = "2";
            const string Reload = "3";
            const string TakeAim = "4";
            const string DantesShoot1 = "1";
            const string DantesShoot2 = "2";
            const string DantesDodge = "3";
            const string DantesUltraShoot = "4";
            string dantesAction = DantesShoot1;
            string userChoise = string.Empty;
            bool duelIsWorking = true;
            bool dantesMoveSet = true;
            bool bulletReloaded = true;
            bool pushkinsTurnIsWork = true;

            Console.WriteLine("Добро пожаловать на последнюю дуэль мистер Пушкин!");
            Console.WriteLine("Я расскажу вам о вариантах ваших действий от которых зависит итог вашего поединка с д'Антесом:");
            Console.WriteLine();

            while (duelIsWorking == true)
            {
                // Ход игрока
                pushkinsTurnIsWork = true;

                while (pushkinsTurnIsWork == true)
                {
                    if (bulletReloaded == true)
                    {
                        Console.WriteLine("Пистолет заряжен");
                    }

                    else
                    {
                        Console.WriteLine("Пистолет разряжен");
                    }

                    Console.WriteLine($"Ваше здоровье - {pushkinHealth}");
                    Console.WriteLine($"Здоровье д'Антеса - {dantesHealth}");
                    Console.WriteLine();
                    Console.WriteLine($"{Shoot} - Пистолетный выстрел. Наносит {pushkinDamage} урона");
                    Console.WriteLine($"{Cover} - Прекрыться рукой. Поглащает половину урона");
                    Console.WriteLine($"{Reload} - Перезарядиться");
                    Console.WriteLine($"{TakeAim} - Прицелиться. Увеличивает урон, но пропускает ход");
                    Console.WriteLine();
                    userChoise = Console.ReadLine();
                    Console.WriteLine();

                    switch (userChoise)
                    {
                        case Shoot:

                            if (bulletReloaded == true)
                            {
                                dantesHealth -= pushkinDamage * dantesArmor;
                                bulletReloaded = false;
                                Console.WriteLine($"Вы стреляете нанося д'Антесу {pushkinDamage * dantesArmor}урона");
                            }

                            else
                            {
                                Console.WriteLine($"Пистолет разряжен - выстрел невозможен");
                            }

                            dantesArmor = dantesArmorDefault;
                            pushkinDamage = pushkinDamageDafault;
                            pushkinsTurnIsWork = false;
                            break;

                        case Cover:
                            pushkinArmor = pushkinUltraArmor;
                            dantesArmor = dantesArmorDefault;
                            pushkinDamage = pushkinDamageDafault;
                            pushkinsTurnIsWork = false;

                            Console.WriteLine($"Вы прикрываетесь рукой");

                            break;

                        case Reload:

                            if (bulletReloaded == false)
                            {
                                bulletReloaded = true;

                                Console.WriteLine("Вы перезарядили пистолет");
                            }

                            else
                            {
                                Console.WriteLine("Пистолет уже заряжен");
                            }

                            dantesArmor = dantesArmorDefault;
                            pushkinDamage = pushkinDamageDafault;
                            pushkinsTurnIsWork = false;
                            break;

                        case TakeAim:
                            pushkinDamage = pushkinUltraDamage;
                            dantesArmor = dantesArmorDefault;
                            pushkinsTurnIsWork = false;

                            Console.WriteLine("Вы прицелились");

                            break;

                        default:
                            Console.WriteLine("Не верное значение");
                            Console.WriteLine();

                            break;
                    }
                }


                //Ход д'Антеса

                //Первый мувсет

                if (dantesMoveSet == true)
                {
                    switch (dantesAction)
                    {
                        case DantesShoot1:
                            pushkinHealth -= dantesDamage * pushkinArmor;
                            dantesAction = DantesShoot2;

                            Console.WriteLine($"д'Антес делает выстрел и наносит вам {dantesDamage * pushkinArmor} урона.");
                            Console.WriteLine();

                            pushkinArmor = pushkinArmorDefault;
                            break;

                        case DantesShoot2:
                            pushkinHealth -= dantesDamage * pushkinArmor;
                            dantesAction = DantesDodge;

                            Console.WriteLine($"д'Аантес делает выстрел и наносит вам {dantesDamage * pushkinArmor} урона.");
                            Console.WriteLine();

                            pushkinArmor = pushkinArmorDefault;
                            break;

                        case DantesDodge:
                            dantesArmor = dantesUltraArmor;
                            dantesAction = DantesUltraShoot;

                            Console.WriteLine("д'Антес заслонился рукой");
                            Console.WriteLine();

                            pushkinArmor = pushkinArmorDefault;
                            break;

                        case DantesUltraShoot:
                            dantesDamage = dantesUltraDamage;
                            pushkinHealth -= dantesDamage * pushkinArmor;
                            dantesAction = DantesShoot1;
                            dantesMoveSet = false;

                            Console.WriteLine($"д'Антес делает прицельный выстрел и наносит вам {dantesDamage * pushkinArmor} урона.");
                            Console.WriteLine();

                            pushkinArmor = pushkinArmorDefault;
                            dantesDamage = dantesDamaeDefault;
                            break;
                    }
                }

                //Второй мувсет

                else
                {
                    switch (dantesAction)
                    {
                        case DantesDodge:
                            dantesArmor = dantesUltraArmor;
                            dantesAction = DantesShoot1;

                            Console.WriteLine("д'Антес заслонился рукой");
                            Console.WriteLine();

                            pushkinArmor = pushkinArmorDefault;
                            break;

                        case DantesShoot1:
                            pushkinHealth -= dantesDamage * pushkinArmor;
                            dantesAction = DantesUltraShoot;

                            Console.WriteLine($"д'Антес делает выстрел и наносит вам {dantesDamage * pushkinArmor} урона.");
                            Console.WriteLine();

                            pushkinArmor = pushkinArmorDefault;
                            break;

                        case DantesUltraShoot:
                            dantesDamage = dantesUltraDamage;
                            pushkinHealth -= dantesDamage * pushkinArmor;
                            dantesAction = DantesShoot1;
                            dantesMoveSet = true;

                            Console.WriteLine($"д'Антес делает прицельный выстрел и наносит вам {dantesDamage * pushkinArmor} урона.");
                            Console.WriteLine();

                            pushkinArmor = pushkinArmorDefault;
                            dantesDamage = dantesDamaeDefault;
                            break;
                    }

                }

                if (dantesHealth <= 0 || pushkinHealth <= 0)
                {
                    duelIsWorking = false;
                }
            }

            if (pushkinHealth > 0)
            {
                Console.WriteLine("Вы победили на дуэли");
            }

            if (dantesHealth > 0)
            {
                Console.WriteLine("Вы проиграли дуэль");
            }

            if (pushkinHealth == dantesHealth)
            {
                Console.WriteLine("Кровавая ничья");
            }
        }
    }
}
