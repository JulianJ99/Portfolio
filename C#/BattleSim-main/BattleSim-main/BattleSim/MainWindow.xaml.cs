using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleSim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnRestart.Visibility = Visibility.Collapsed;
            comboBoxHero.IsEnabled = true;
            comboBoxVillain.IsDropDownOpen = false;
            comboBoxVillain.IsEnabled = false;
        }

        Hero player1 = new Hero();
        Villain player2 = new Villain();

        private int damage(int min, int max)
        {
            Random damageRNG = new Random();
            return damageRNG.Next(min, max);
        }
        private int chargeMin = 3;
        private int chargeMax = 20;


        class Hero
        {
            public int intHeroHealth = 100;
            public int intHeroCharge = 0;
        }

        class Villain
        {
            public int intVillainHealth = 100;
            public int intVillainCharge = 0;
        }



        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if(player1.intHeroCharge == 1)
            {

                Random randomHeroDamage = new Random();
                int[] heroChargeArray = new int[3];
                listBoxCombat.Items.Add("Massive damage!");
                for (int i = 0; i < heroChargeArray.Length; i++)
                {
                    int nextHit = randomHeroDamage.Next(chargeMin, chargeMax);
                    heroChargeArray[i] = nextHit;
                    player2.intVillainHealth -= nextHit;
                    lblVillainHealth.Content = player2.intVillainHealth.ToString();
                    listBoxCombat.Items.Add("Player 1 hits for " + heroChargeArray[i].ToString() + " damage!");
                }
                player1.intHeroCharge = 0;
                comboBoxHero.IsEnabled = false;
                comboBoxVillain.IsDropDownOpen = true;
                comboBoxVillain.IsEnabled = true;

                if (player2.intVillainHealth == 0 || player2.intVillainHealth <= 0)
                {
                    player2.intVillainHealth = 0;
                    lblVillainHealth.Content = player2.intVillainHealth.ToString();
                    comboBoxHero.Visibility = Visibility.Collapsed;
                    comboBoxVillain.Visibility = Visibility.Collapsed;
                    comboBoxVillain.IsDropDownOpen = false;
                    btnRestart.Visibility = Visibility.Visible;
                    listBoxCombat.Items.Add("Player 1 wins!");
                }
            }
            else
            {
                int intPlayer1Attack = damage(0, 31);
                player2.intVillainHealth -= intPlayer1Attack;
                lblVillainHealth.Content = player2.intVillainHealth.ToString();

                if (intPlayer1Attack >= 19 && intPlayer1Attack <= 32)
                {
                    listBoxCombat.Items.Add("Critical hit!");
                }
                else if (intPlayer1Attack >= 0 && intPlayer1Attack <= 6)
                {
                    listBoxCombat.Items.Add("Miss!");
                }
                listBoxCombat.Items.Add("Player 1 hits for " + Convert.ToString(intPlayer1Attack) + " damage!");
                comboBoxHero.IsEnabled = false;
                comboBoxHero.IsDropDownOpen = false;
                comboBoxVillain.IsDropDownOpen = true;
                comboBoxVillain.IsEnabled = true;

                if (player2.intVillainHealth == 0 || player2.intVillainHealth <= 0)
                {
                    player2.intVillainHealth = 0;
                    lblVillainHealth.Content = player2.intVillainHealth.ToString();
                    comboBoxHero.Visibility = Visibility.Collapsed;
                    comboBoxVillain.Visibility = Visibility.Collapsed;
                    comboBoxVillain.IsDropDownOpen = false;
                    btnRestart.Visibility = Visibility.Visible;
                    listBoxCombat.Items.Add("Player 1 wins!");
                }
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (player2.intVillainCharge == 1)
            {
                Random randomVillainDamage = new Random();
                int[] villainChargeArray = new int[3];
                listBoxCombat.Items.Add("Massive damage!");
                for (int i = 0; i < villainChargeArray.Length; i++)
                {
                    int nextHit = randomVillainDamage.Next(chargeMin, chargeMax);
                    villainChargeArray[i] = nextHit;
                    player1.intHeroHealth -= nextHit;
                    lblHeroHealth.Content = player1.intHeroHealth.ToString();
                    listBoxCombat.Items.Add("Player 2 hits for " + villainChargeArray[i].ToString() + " damage!");
                }
                player2.intVillainCharge = 0;
                comboBoxVillain.IsEnabled = false;
                comboBoxHero.IsEnabled = true;
                comboBoxHero.IsDropDownOpen = true;
                

                if (player1.intHeroHealth == 0 || player1.intHeroHealth <= 0)
                {
                    player1.intHeroHealth = 0;
                    lblHeroHealth.Content = player1.intHeroHealth.ToString();
                    comboBoxHero.Visibility = Visibility.Collapsed;
                    comboBoxVillain.Visibility = Visibility.Collapsed;
                    comboBoxHero.IsDropDownOpen = false;
                    btnRestart.Visibility = Visibility.Visible;
                    listBoxCombat.Items.Add("Player 2 wins!");
                }
            }
            else
            {
                int intPlayer2Attack = damage(0, 31);
                player1.intHeroHealth -= intPlayer2Attack;
                lblHeroHealth.Content = player1.intHeroHealth.ToString();


                if (intPlayer2Attack >= 19 && intPlayer2Attack <= 32)
                {
                    listBoxCombat.Items.Add("Critical hit!");
                }
                else if (intPlayer2Attack >= 0 && intPlayer2Attack <= 6)
                {
                    listBoxCombat.Items.Add("Miss!");
                }
                listBoxCombat.Items.Add("Player 2 hits for " + Convert.ToString(intPlayer2Attack) + " damage!");
                comboBoxHero.IsEnabled = true;
                comboBoxHero.IsDropDownOpen = true;
                comboBoxVillain.IsEnabled = false;

                if (player1.intHeroHealth == 0 || player1.intHeroHealth <= 0)
                {
                    player1.intHeroHealth = 0;
                    lblHeroHealth.Content = player1.intHeroHealth.ToString();
                    comboBoxHero.Visibility = Visibility.Collapsed;
                    comboBoxVillain.Visibility = Visibility.Collapsed;
                    comboBoxHero.IsDropDownOpen = false;
                    btnRestart.Visibility = Visibility.Visible;
                    listBoxCombat.Items.Add("Player 2 wins!");
                }
            }
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            player1.intHeroHealth = 100;
            lblHeroHealth.Content = player1.intHeroHealth.ToString();
            player2.intVillainHealth = 100;
            lblVillainHealth.Content = player2.intVillainHealth.ToString();

            listBoxCombat.Items.Add("Let the next round begin!");
            comboBoxHero.Visibility = Visibility.Visible;
            comboBoxVillain.Visibility = Visibility.Visible;
            comboBoxHero.IsEnabled = true;
            comboBoxHero.IsDropDownOpen = true;
            comboBoxVillain.IsEnabled = false;
            btnRestart.Visibility = Visibility.Collapsed;
        }

        private void btnHeroHeal_Click(object sender, RoutedEventArgs e)
        {
            if (player1.intHeroHealth == 100)
            {
                listBoxCombat.Items.Add("There's no need to heal, you're at full health.");
                listBoxCombat.Items.Add("Use your turn for something else instead!");

            }
            else
            {
                int intPlayer1Heal = damage(0, 31);
                player1.intHeroHealth += intPlayer1Heal;
                if (player1.intHeroHealth > 100)
                {
                    player1.intHeroHealth = 100;
                }
                lblHeroHealth.Content = player1.intHeroHealth.ToString();
                listBoxCombat.Items.Add("Player 1 heals " + Convert.ToString(intPlayer1Heal) + " damage!");
                if (player1.intHeroHealth == 100)
                {
                    listBoxCombat.Items.Add("Capped! Health cannot go higher than 100.");
                }
                comboBoxHero.IsEnabled = false;
                comboBoxVillain.IsDropDownOpen = true;
                comboBoxVillain.IsEnabled = true;
            }
        }


        private void btnVillainHeal_Click(object sender, RoutedEventArgs e)
        {
            if (player2.intVillainHealth == 100)
            {
                listBoxCombat.Items.Add("There's no need to heal, you're at full health.");
                listBoxCombat.Items.Add("Use your turn for something else instead!");

            }
            else
            {
                int intPlayer2Heal = damage(0, 31);
                player2.intVillainHealth += intPlayer2Heal;
                if (player2.intVillainHealth > 100)
                {
                    player2.intVillainHealth = 100;

                }
                lblVillainHealth.Content = player2.intVillainHealth.ToString();
                listBoxCombat.Items.Add("Player 2 heals " + Convert.ToString(intPlayer2Heal) + " damage!");
                if (player2.intVillainHealth == 100)
                {
                    listBoxCombat.Items.Add("Capped! Health cannot go higher than 100.");
                }
                comboBoxHero.IsEnabled = true;
                comboBoxHero.IsDropDownOpen = true;
                comboBoxVillain.IsEnabled = false;
            }
        }

        private void btnHeroCharge_Click(object sender, RoutedEventArgs e)
        {
            if(player1.intHeroCharge == 0)
            {
                player1.intHeroCharge = 1;
                listBoxCombat.Items.Add("Player 1 charges up! Their next attack will be devastating.");
                comboBoxHero.IsEnabled = false;
                comboBoxVillain.IsDropDownOpen = true;
                comboBoxVillain.IsEnabled = true;
            }
            else
            {
                listBoxCombat.Items.Add("You're already charged up! Wreak havoc!");
            }
        }

        private void btnVillainCharge_Click(object sender, RoutedEventArgs e)
        {
            if(player2.intVillainCharge == 0)
            {
                player2.intVillainCharge = 1;
                listBoxCombat.Items.Add("Player 2 charges up! Their next attack will be devastating.");
                comboBoxVillain.IsEnabled = false;
                comboBoxHero.IsEnabled = true;
                comboBoxHero.IsDropDownOpen = true;
            }
            else
            {
                listBoxCombat.Items.Add("You're already charged up! Wreak havoc!");
            }

            
        }

       
    }
}
