using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sweeper.ViewModels
{
    public class
      RelayCommand : ICommand
    {
        #region Fields

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        private string _displayText;
        private string _category;
        
        private static EventHandler newLogItemEvent;
        public static event EventHandler NewLogItemEvent
        {
            add { newLogItemEvent += value; }
            remove { newLogItemEvent -= value; }
        }
        protected  virtual void OnNewLogItemEvent(LogItem li)
        {
            if (newLogItemEvent != null)
            {
                newLogItemEvent(null,li);
            }
        }
        private void RaiseNewLogItemEvent(LogItem li)
        {
            OnNewLogItemEvent(li);
        }
        //
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        

        //public static List<LogItem> Log = new List<LogItem>();
        public static ObservableCollection<LogItem> Log = new ObservableCollection<LogItem>();
        public delegate void LogItemCallBack(LogItem lItem);

       
         
        private Action<object> action;

        #endregion // Fields

        #region Constructors

        //<summary>
        //Creates a new command that can always execute.
        //</summary>
        //<param name="execute">The execution logic.</param>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
            
        }

        //<summary>
        //Creates a new command.
        //</summary>
        //<param name="execute">The execution logic.</param>
        //<param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
            : this(execute, canExecute, "")
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute, string displayText)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
            _displayText = displayText;
        }


        public string DisplayText
        {
            get { return _displayText; }
            set { _displayText = value;
                  }
        }

        #endregion // Constructors

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add    { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            
            //if (this._category == "GAME")
            {   string str;
                if (parameter != null)
                   str = "Cmd:(" + _displayText + ")\tParm:(" + parameter+")";
                else
                    str = "Cmd:(" + _displayText + ")\tParm:(null)";
                
                RaiseNewLogItemEvent(new LogItem(str, parameter));
               
                Debug.WriteLine(str);
            }
            //if (this._category == "GAME")
                
            _execute(parameter);
        }
        #endregion // ICommand Members  
        public static void ClearLog()
        {
            RelayCommand.Log.Clear();
        }
    }


    
}
