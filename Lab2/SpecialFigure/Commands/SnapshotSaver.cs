using Lab2.SpecialFigure.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab2.SpecialFigure.Commands
{
    public class SnapshotEventArgs : EventArgs
    {
        public IFigure Figure { get; init; }
        public IFigureSnapshot Snapshot { get; init; }
        public string CommandName { get; init; }
        public object CommandArg { get; init; }
    }

    public class SnapshotSaver : BaseCommand
    {
        public event EventHandler<SnapshotEventArgs> OnSnapshot;

        private IFigure _figure;
        private ICommand _originCommand;
        private string _commandName;

        public SnapshotSaver(IFigure figure, IFigureCommand originCommand) :
            this(figure, originCommand, originCommand.CommandName)
        {
            _figure = figure;
            _originCommand = originCommand;
            _commandName = originCommand.CommandName;
        }

        public SnapshotSaver(IFigure figure, ICommand originCommand, string commandName)
        {
            _figure = figure;
            _originCommand = originCommand;
            _commandName = commandName;
        }

        public override bool CanExecute(object parameter)
        {
            return _originCommand.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            if (OnSnapshot is not null)
            {
                OnSnapshot(this, new SnapshotEventArgs() {
                    Figure = _figure,
                    Snapshot = _figure.MakeSnapshot(),
                    CommandName = _commandName,
                    CommandArg = parameter
                });
            }

            _originCommand.Execute(parameter);
        }
    }
}
