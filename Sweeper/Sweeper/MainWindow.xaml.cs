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
using Sweeper.ViewModels;
using System.Diagnostics;

namespace Sweeper
{   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        SweeperViewModel game;    
        public MainWindow()
        {
            //System.Threading.Thread.Sleep(3000);
            
            InitializeComponent();
            game = new SweeperViewModel();
            this.DataContext = game;
            
            game.BeginnerCommand.Execute(null);           
        }
        private void BeginnerGame(object sender, RoutedEventArgs e)
        {
            
            SetGameSize(GameConstants.GameTypes.BEGINNER);
            
            
        }
        private void IntermediateGame(object sender, RoutedEventArgs e)
        {
           
            SetGameSize(GameConstants.GameTypes.INTERMEDIATE);
            
                 
        }
        private void AdvancedGame(object sender, RoutedEventArgs e)
        {
            
            SetGameSize(GameConstants.GameTypes.ADVANCED);
            
        }
        private void CustomGame(object sender, RoutedEventArgs e)
        {
            SetGameSize(GameConstants.GameTypes.CUSTOM);
        }        
        private void SetGameSize(GameConstants.GameTypes gameType)
        {
           
            game.SetGameParms(gameType);
            Height = game.Height;
            Width = game.Width;
            
        }
    }
}
