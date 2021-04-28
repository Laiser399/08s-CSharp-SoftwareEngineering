using Lab2.SpecialFigure;
using Lab2.SpecialFigure.Commands;
using Lab2.SpecialFigure.Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace Lab2.GUI
{
    public class MainWindowVM : BaseViewModel
    {
        #region Bindings

        private RelayCommand _undoCmd;
        public RelayCommand UndoCmd
            => _undoCmd ?? (_undoCmd = new RelayCommand(_ => Undo()));

        private ObservableCollection<HistoryCommandVM> _commandsHistory;
        public ObservableCollection<HistoryCommandVM> CommandsHistory
            => _commandsHistory ?? (_commandsHistory = new ObservableCollection<HistoryCommandVM>());

        private FigureVM _figureVM;
        public FigureVM FigureVM => _figureVM ?? (_figureVM = new FigureVM());

        // TODO delete
        private RelayCommand _testCmd;
        public RelayCommand TestCmd
            => _testCmd ?? (_testCmd = new RelayCommand(_ => Test()));

        private RelayCommand _test2Cmd;
        public RelayCommand Test2Cmd
            => _test2Cmd ?? (_test2Cmd = new RelayCommand(_ => Test2()));

        

        #endregion

        #region FigureCommands

        private ICommand _changeFigureTypeCmd;
        public ICommand ChangeTypeCmd => _changeFigureTypeCmd ??
            (_changeFigureTypeCmd = Decorate(new ChangeTypeCommand(FigureVM)));

        private ICommand _changeRadiusCmd;
        public ICommand ChangeRadiusCmd => _changeRadiusCmd ??
            (_changeRadiusCmd = Decorate(new ChangeRadiusCommand(FigureVM)));

        private ICommand _changePenColorCmd;
        public ICommand ChangePenColorCmd => _changePenColorCmd ??
            (_changePenColorCmd = Decorate(new ChangePenColorCommand(FigureVM)));

        private ICommand _changeBrushColorCmd;
        public ICommand ChangeBrushColorCmd => _changeBrushColorCmd ??
            (_changeBrushColorCmd = Decorate(new ChangeBrushColorCommand(FigureVM)));

        private ICommand _changeBorderThicknessCmd;
        public ICommand ChangeBorderThicknessCmd => _changeBorderThicknessCmd ??
            (_changeBorderThicknessCmd = Decorate(new ChangeBorderThicknessCommand(FigureVM)));

        #endregion

        public MainWindowVM()
        {

        }

        private ICommand Decorate(IFigureCommand command)
        {
            ICommand result = DecorateBySnaphotSaver(command);
            return DecorateByRecord(result);
        }

        private ICommand DecorateBySnaphotSaver(IFigureCommand command)
        {
            SnapshotSaver snapshotSaver = new SnapshotSaver(FigureVM, command);
            snapshotSaver.OnSnapshot += OnSnapshot;
            return snapshotSaver;
        }

        private ICommand DecorateByRecord(ICommand command)
        {
            return new RecordCommand(command, () => false, () => false, (_, _) => { });// TODO

        }

        private void Undo()
        {
            if (CommandsHistory.Count == 0)
                return;

            HistoryCommandVM historyCommand = CommandsHistory[CommandsHistory.Count - 1];
            historyCommand.Snapshot.Restore();
            CommandsHistory.RemoveAt(CommandsHistory.Count - 1);
        }

        private void OnSnapshot(object sender, SnapshotEventArgs args)
        {
            CommandsHistory.Add(new HistoryCommandVM(args));
        }




        // TODO delete
        private void Test()
        {

        }

        private void Test2()
        {

            
        }



    }
}
