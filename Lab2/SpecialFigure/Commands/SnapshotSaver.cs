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

    public class SnapshotSaver : ISimpleCommand
    {
        private IFigureCommand _originCommand;

        public IFigure Figure { get; private init; }

        public event EventHandler<SnapshotEventArgs> OnSnapshot;

        public SnapshotSaver(IFigure figure, IFigureCommand originCommand)
        {
            _originCommand = originCommand;
            Figure = figure;
        }

        public void Execute(object arg)
        {
            if (OnSnapshot is not null)
            {
                OnSnapshot(this, new SnapshotEventArgs() {
                    Figure = Figure,
                    Snapshot = Figure.MakeSnapshot(),
                    CommandName = _originCommand.CommandName,
                    CommandArg = arg
                });
            }

            _originCommand.Execute(arg);
        }
    }
}
