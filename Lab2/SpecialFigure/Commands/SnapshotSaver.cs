using Lab2.SpecialFigure.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private IFigureCommand _originCommand;

        public SnapshotSaver(IFigure figure, IFigureCommand originCommand)
        {
            _figure = figure;
            _originCommand = originCommand;
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
                    CommandName = _originCommand.CommandName,
                    CommandArg = parameter
                });
            }

            _originCommand.Execute(parameter);
        }
    }
}
