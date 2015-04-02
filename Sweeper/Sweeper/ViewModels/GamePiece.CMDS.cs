using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Sweeper.ViewModels
{
    public partial class GamePiece
    {
        
        //#region COMMANDS
        //const string CATEGORY = "MOUSE";
        //#region MOUSE_LEFT_BUTTON_DOWN
        //private RelayCommand _mouseLeftButtonDownCommand;
        //public RelayCommand MouseLeftButtonDownCommand
        //{
        //    get
        //    {
        //        if (_mouseLeftButtonDownCommand == null)
        //        {
        //            _mouseLeftButtonDownCommand = new RelayCommand(param => ExecuteMouseLeftButtonDown((MouseEventArgs)param))
        //            {
        //                DisplayText = "MouseLeftButtonDownCommand",
        //                Category = CATEGORY
        //            };
        //        }
        //        return _mouseLeftButtonDownCommand;
        //    }
        //    set { _mouseLeftButtonDownCommand = value; }
        //}

        //private void ExecuteMouseLeftButtonDown(MouseEventArgs e)
        //{
        //    Debug.WriteLine("Mouse Down : " + e.GetPosition((IInputElement)e.Source));
        //    if (e.Source is Rectangle)
        //    {
        //        if (e.LeftButton == MouseButtonState.Pressed)
        //        {

        //            if (this.Value == GameConstants.PieceValues.BUTTON)
        //            {
        //                this.Value = GameConstants.PieceValues.PRESSED;
        //            }
        //        }
        //    }
        //}
        //#endregion

        //#region MOUSE_LEFT_BUTTON_UP
        //RelayCommand _mouseLeftButtonUpCommand;
        //public RelayCommand MouseLeftButtonUpCommand
        //{
        //    get
        //    {
        //        if (_mouseLeftButtonUpCommand == null)
        //        {
        //            _mouseLeftButtonUpCommand = new RelayCommand(param => ExecuteMouseLeftButtonUp((MouseEventArgs)param))
        //            {
        //                DisplayText = "MouseLeftButtonUpCommand",
        //                Category = CATEGORY
        //            };
        //        }
        //        return _mouseLeftButtonUpCommand;
        //    }
        //    set { _mouseLeftButtonUpCommand = value; }
        //}

        //private void ExecuteMouseLeftButtonUp(MouseEventArgs e)
        //{
        //    Debug.WriteLine("Mouse Left Button Up : " + e.GetPosition((IInputElement)e.Source));



        //    if (this.Value == GameConstants.PieceValues.PRESSED)
        //    {
        //        //gameBoard.Play(this.R, this.C);
        //        gameBoard.PlayCommand.Execute(new System.Windows.Point(this.R, this.C));
        //        //this.Value = GameConstants.PieceValues.BUTTON;
        //    }


        //}

        //#endregion

        //#region MOUSE_ENTER
        //private RelayCommand _mouseEnterCommand;
        //public RelayCommand MouseEnterCommand
        //{
        //    get
        //    {
        //        if (_mouseEnterCommand == null)
        //        {
        //            _mouseEnterCommand = new RelayCommand(param => ExecuteMouseEnter((MouseEventArgs)param))
        //            {
        //                DisplayText = "MouseEnterCommand",

        //                Category = CATEGORY
        //            };
        //        }
        //        return _mouseEnterCommand;
        //    }
        //    set { _mouseEnterCommand = value; }
        //}

        //private void ExecuteMouseEnter(MouseEventArgs e)
        //{
        //    Debug.WriteLine("Mouse Enter : " + e.GetPosition((IInputElement)e.Source));
        //    if (e.Source is Rectangle)
        //    {

        //        if (e.LeftButton == MouseButtonState.Pressed)
        //        {
        //            if (Value == GameConstants.PieceValues.BUTTON)
        //            {
        //                Value = GameConstants.PieceValues.PRESSED;
        //            }
        //        }
        //    }
        //}

        //private RelayCommand _mouseLeaveCommand;
        //#endregion

        //#region MOUSE_LEAVE
        //public RelayCommand MouseLeaveCommand
        //{
        //    get
        //    {
        //        if (_mouseLeaveCommand == null)
        //        {
        //            _mouseLeaveCommand = new RelayCommand(param => ExecuteMouseLeave((MouseEventArgs)param))
        //            {
        //                DisplayText = "MouseLeaveCommand",

        //                Category = CATEGORY
        //            };
        //        }
        //        return _mouseLeaveCommand;
        //    }
        //    set { _mouseLeaveCommand = value; }
        //}

        //private void ExecuteMouseLeave(MouseEventArgs e)
        //{

        //    Debug.WriteLine("Mouse Leave : " + e.GetPosition((IInputElement)e.Source));
        //    if (this.Value == GameConstants.PieceValues.PRESSED)
        //    {
        //        this.Value = GameConstants.PieceValues.BUTTON;
        //    }


        //}

        //private RelayCommand _mouseRightButtonUpCommand;
        //private ViewModels.SweeperViewModel sweeperViewModel;


        //#endregion

        //#region MOUSE_RB_UP
        //public RelayCommand MouseRightButtonUpCommand
        //{
        //    get
        //    {
        //        if (_mouseRightButtonUpCommand == null)
        //        {
        //            _mouseRightButtonUpCommand = new RelayCommand(param => ExecuteMouseRightButtonUp((MouseEventArgs)param))
        //            {
        //                DisplayText = "MouseRightButtonUpCommand",
        //                Category = CATEGORY
        //            };
        //        }
        //        return _mouseRightButtonUpCommand;
        //    }
        //    set { _mouseRightButtonUpCommand = value; }
        //}

        //private void ExecuteMouseRightButtonUp(MouseEventArgs e)
        //{

        //    Debug.WriteLine("Mouse RightButtonUp : " + e.GetPosition((IInputElement)e.Source));
        //    gameBoard.FlagCommand.Execute(new System.Windows.Point(this.R, this.C));
        //    //gameBoard.Flag(this.R, this.C);


        //}

        //#endregion


        //#endregion
         
    }
}
