using Lab2.Abstractions;
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
        private ICommand _recordCmd;
        private ICommand _executeCmd;

        private Func<bool> _isRecording;
        private IChainCommandBuilder _chainCommandBuilder;

        public RecordCommand(ICommand originCmd, Func<bool> isRecording, IChainCommandBuilder builder) :
            this(originCmd, originCmd, isRecording, builder)
        { }

        public RecordCommand(ICommand recordCmd, ICommand executeCmd,
            Func<bool> isRecording, IChainCommandBuilder builder)
        {
            _recordCmd = recordCmd;
            _executeCmd = executeCmd;
            _isRecording = isRecording;
            _chainCommandBuilder = builder;
        }

        public override bool CanExecute(object parameter)
        {
            if (_isRecording())
            {
                return _chainCommandBuilder.CanAddNext(_recordCmd, parameter)
                    && _recordCmd.CanExecute(parameter);
            }
            else
            {
                return _executeCmd.CanExecute(parameter);
            }
        }

        public override void Execute(object parameter)
        {
            if (_isRecording())
            {
                _chainCommandBuilder.AddNext(_recordCmd, parameter);
            }
            else
            {
                _executeCmd.Execute(parameter);
            }
        }
    }
}
