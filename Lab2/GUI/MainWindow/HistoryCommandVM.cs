using Lab2.SpecialFigure;
using Lab2.SpecialFigure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.GUI
{
    public class HistoryCommandVM : BaseViewModel
    {
        #region Bindings

        private TimeSpan _time;
        public TimeSpan Time => _time;

        public DateTime DateTime => _args.Snapshot.DateTime;

        public string CommandName => _args.CommandName;

        public object CommandArg => _args.CommandArg;


        #endregion

        public IFigureSnapshot Snapshot => _args.Snapshot;
        
        private SnapshotEventArgs _args;

        public HistoryCommandVM(SnapshotEventArgs args)
        {
            _args = args;

            _time = TimeSpan.FromSeconds(Math.Round(DateTime.TimeOfDay.TotalSeconds));
        }
    }
}
