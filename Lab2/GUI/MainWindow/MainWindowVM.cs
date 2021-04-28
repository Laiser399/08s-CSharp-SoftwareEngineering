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
using System.Windows.Media;

namespace Lab2.GUI
{
    public class MainWindowVM : BaseViewModel
    {
        #region Bindings

        private RelayCommand _undoCmd;
        public RelayCommand UndoCmd
            => _undoCmd ?? (_undoCmd = new RelayCommand(_ => Undo()));

        private FigureType _figureType;
        public FigureType FigureType
        {
            get => _figureType;
            set
            {
                _figureType = value;
                ChangeTypeCmd.Execute(value);
                NotifyPropChanged(nameof(FigureType));
            }
        }

        private double _figureRadius = 5;
        public double FigureRadius
        {
            get => _figureRadius;
            set
            {
                _figureRadius = value;
                NotifyPropChanged(nameof(FigureRadius));
            }
        }

        private RelayCommand _applyRadiusCmd;
        public RelayCommand ApplyRadiusCmd
            => _applyRadiusCmd ?? (_applyRadiusCmd = new RelayCommand(_ => ApplyRadius()));

        private Color _penColor = Colors.Black;
        public Color PenColor
        {
            get => _penColor;
            set
            {
                _penColor = value;
                ChangePenColorCmd.Execute(value);
                NotifyPropChanged(nameof(PenColor));
            }
        }

        private Color _brushColor = Colors.Transparent;
        public Color BrushColor
        {
            get => _brushColor;
            set
            {
                _brushColor = value;
                ChangeBrushColorCmd.Execute(value);
                NotifyPropChanged(nameof(BrushColor));
            }
        }

        private double _borderThickness = 1;
        public double BorderThickness
        {
            get => _borderThickness;
            set
            {
                _borderThickness = value;
                NotifyPropChanged(nameof(BorderThickness));
            }
        }

        private RelayCommand _applyBorderThicknessCmd;
        public RelayCommand ApplyBorderThicknessCmd
            => _applyBorderThicknessCmd ?? (_applyBorderThicknessCmd = new RelayCommand(_ => ApplyBorderThickness()));


        private ObservableCollection<HistoryCommandVM> _commandsHistory;
        public ObservableCollection<HistoryCommandVM> CommandsHistory
            => _commandsHistory ?? (_commandsHistory = new ObservableCollection<HistoryCommandVM>());


        // TODO delete
        private RelayCommand _testCmd;
        public RelayCommand TestCmd
            => _testCmd ?? (_testCmd = new RelayCommand(_ => Test()));

        private RelayCommand _test2Cmd;
        public RelayCommand Test2Cmd
            => _test2Cmd ?? (_test2Cmd = new RelayCommand(_ => Test2()));

        #endregion

        #region FigureCommands

        private ISimpleCommand _changeFigureTypeCmd;
        private ISimpleCommand ChangeTypeCmd => _changeFigureTypeCmd ??
            (_changeFigureTypeCmd = Decorate(new ChangeTypeCommand(_figure)));

        private ISimpleCommand _changeRadiusCmd;
        private ISimpleCommand ChangeRadiusCmd => _changeRadiusCmd ??
            (_changeRadiusCmd = Decorate(new ChangeRadiusCommand(_figure)));

        private ISimpleCommand _changePenColorCmd;
        private ISimpleCommand ChangePenColorCmd => _changePenColorCmd ??
            (_changePenColorCmd = Decorate(new ChangePenColorCommand(_figure)));

        private ISimpleCommand _changeBrushColorCmd;
        private ISimpleCommand ChangeBrushColorCmd => _changeBrushColorCmd ??
            (_changeBrushColorCmd = Decorate(new ChangeBrushColorCommand(_figure)));

        private ISimpleCommand _changeBorderThicknessCmd;
        private ISimpleCommand ChangeBorderThicknessCmd => _changeBorderThicknessCmd ??
            (_changeBorderThicknessCmd = Decorate(new ChangeBorderThicknessCommand(_figure)));

        #endregion

        private IFigure _figure;

        public MainWindowVM(IFigure figure)
        {
            _figure = figure;

            FigureType = _figure.FigureType;
            FigureRadius = _figure.FigureRadius;
            PenColor = _figure.PenColor;
            BrushColor = _figure.BrushColor;
            BorderThickness = _figure.BorderThickness;

        }

        private ISimpleCommand Decorate(IFigureCommand command)
        {
            ISimpleCommand result = DecorateBySnaphotSaver(command);
            return DecorateByRecord(result);
        }

        private ISimpleCommand DecorateBySnaphotSaver(IFigureCommand command)
        {
            SnapshotSaver snapshotSaver = new SnapshotSaver(_figure, command);
            snapshotSaver.OnSnapshot += OnSnapshot;
            return snapshotSaver;
        }

        private ISimpleCommand DecorateByRecord(ISimpleCommand command)
        {
            return new RecordCommand(command, () => false, (_, _) => { });// TODO
        }

        private void Undo()
        {
            if (CommandsHistory.Count == 0)
                return;

            HistoryCommandVM historyCommand = CommandsHistory[CommandsHistory.Count - 1];
            historyCommand.Snapshot.Restore();
            CommandsHistory.RemoveAt(CommandsHistory.Count - 1);
        }

        private void ApplyRadius()
        {
            ChangeRadiusCmd.Execute(FigureRadius);
        }

        private void ApplyBorderThickness()
        {
            ChangeBorderThicknessCmd.Execute(BorderThickness);
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
