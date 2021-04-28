using Lab2.SpecialFigure.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.SpecialFigure.Commands
{
    public class RecordCommand : ISimpleCommand
    {
        private ISimpleCommand _originCmd;
        private Func<bool> _isRecord;
        private Action<ISimpleCommand, object> _makeRecord;

        public RecordCommand(ISimpleCommand originCmd, Func<bool> isRecord, 
            Action<ISimpleCommand, object> makeRecord)
        {
            _originCmd = originCmd;
            _isRecord = isRecord;
            _makeRecord = makeRecord;
        }

        public void Execute(object arg)
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
