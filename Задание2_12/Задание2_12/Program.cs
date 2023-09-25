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
            const string DantesShoot1 = "1";
            const string DantesShoot2 = "2";
            const string DantesDodge = "3";
            const string DantesUltraShoot = "4";

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

            string dantesAction = DantesShoot1;
            string userChoise = string.Empty;

            bool duelIsWorking = true;
            bool dantesMoveSet = true;
            bool bulletReloaded = true;
            bool pushkinsTurnIsWork = true;

            Console.WriteLine("Добро пожаловать на последнюю дуэль мистер Пушкин!");
            Console.WriteLine("Я расскажу вам о вариантах ваших действий от которых зависит итог вашего поединка с д'Антесом:\n");

            while (duelIsWorking == true)
            {
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
                        case CommandCover:
                            pushkinArmor = pushkinUltraArmor;
                            dantesArmor = dantesArmorDefault;
                            pushkinDamage = pushkinDamageDafault;
                            pushkinsTurnIsWork = false;
                            Console.WriteLine($"Вы прикрываетесь рукой");
                            break;
                        case CommandReload:

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
                        case CommandTakeAim:
                            pushkinDamage = pushkinUltraDamage;
                            dantesArmor = dantesArmorDefault;
                            pushkinsTurnIsWork = false;
                            Console.WriteLine("Вы прицелились");
                            break;
                        default:
                            Console.WriteLine("Не верное значение\n");
                            break;
                    }
                }

                if (dantesMoveSet == true)
                {
                    switch (dantesAction)
                    {
                        case DantesShoot1:
                            pushkinHealth -= dantesDamage * pushkinArmor;
                            dantesAction = DantesShoot2;
                            Console.WriteLine($"д'Антес делает выстрел и наносит вам {dantesDamage * pushkinArmor} урона.\n");
                            pushkinArmor = pushkinArmorDefault;
                            break;
                        case DantesShoot2:
                            pushkinHealth -= dantesDamage * pushkinArmor;
                            dantesAction = DantesDodge;
                            Console.WriteLine($"д'Аантес делает выстрел и наносит вам {dantesDamage * pushkinArmor} урона.\n");
                            pushkinArmor = pushkinArmorDefault;
                            break;
                        case DantesDodge:
                            dantesArmor = dantesUltraArmor;
                            dantesAction = DantesUltraShoot;
                            Console.WriteLine("д'Антес заслонился рукой\n");
                            pushkinArmor = pushkinArmorDefault;
                            break;
                        case DantesUltraShoot:
                            dantesDamage = dantesUltraDamage;
                            pushkinHealth -= dantesDamage * pushkinArmor;
                            dantesAction = DantesShoot1;
                            dantesMoveSet = false;
                            Console.WriteLine($"д'Антес делает прицельный выстрел и наносит вам {dantesDamage * pushkinArmor} урона.\n");
                            pushkinArmor = pushkinArmorDefault;
                            dantesDamage = dantesDamaeDefault;
                            break;
                    }
                }
                else
                {
                    switch (dantesAction)
                    {
                        case DantesDodge:
                            dantesArmor = dantesUltraArmor;
                            dantesAction = DantesShoot1;
                            Console.WriteLine("д'Антес заслонился рукой\n");
                            pushkinArmor = pushkinArmorDefault;
                            break;
                        case DantesShoot1:
                            pushkinHealth -= dantesDamage * pushkinArmor;
                            dantesAction = DantesUltraShoot;
                            Console.WriteLine($"д'Антес делает выстрел и наносит вам {dantesDamage * pushkinArmor} урона.\n");
                            pushkinArmor = pushkinArmorDefault;
                            break;
                        case DantesUltraShoot:
                            dantesDamage = dantesUltraDamage;
                            pushkinHealth -= dantesDamage * pushkinArmor;
                            dantesAction = DantesShoot1;
                            dantesMoveSet = true;
                            Console.WriteLine($"д'Антес делает прицельный выстрел и наносит вам {dantesDamage * pushkinArmor} урона.\n");
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
            else
            {
                Console.WriteLine("Кровавая ничья");
            }
        }
    }
}
