using Lab2.SpecialFigure.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab2.SpecialFigure.Commands
{
    public class RecordCommand : BaseCommand
    {
        private ICommand _originCmd;
        private Func<bool> _isRecord;
        private Func<bool> _canRecord;
        private Action<ICommand, object> _makeRecord;

        public RecordCommand(ICommand originCmd, Func<bool> isRecord, 
            Func<bool> canRecord, Action<ICommand, object> makeRecord)
        {
            _originCmd = originCmd;
            _isRecord = isRecord;
            _canRecord = canRecord;
            _makeRecord = makeRecord;
        }

        public override bool CanExecute(object parameter)
        {
            if (_isRecord())
            {
                return _canRecord() && _originCmd.CanExecute(parameter);
            }
            else
            {
                return _originCmd.CanExecute(parameter);
            }
        }

        public override void Execute(object arg)
        {
            if (_isRecord())
            {
                _makeRecord(_originCmd, arg);
            }
            else
            {
                _originCmd.Execute(arg);
            }
        }
    }
}
