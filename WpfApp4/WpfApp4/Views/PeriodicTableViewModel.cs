using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ChemistryIS.ViewModels
{
    public class PeriodicTableViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ElementItem> AllElements { get; set; }

        public ICommand SelectElementCommand { get; set; }

        public PeriodicTableViewModel()
        {
            AllElements = new ObservableCollection<ElementItem>();
            GenerateFullPeriodicTable();

            SelectElementCommand = new RelayCommand(param =>
            {
            });
        }

        private void GenerateFullPeriodicTable()
        {
            AddElement(1, "H", "Водород", 1.008, "1s¹", "Неметаллы", 0, 0);
            AddElement(2, "He", "Гелий", 4.0026, "1s²", "Благородные газы", 0, 17);

            AddElement(3, "Li", "Литий", 6.94, "[He] 2s¹", "Щелочные металлы", 1, 0);
            AddElement(4, "Be", "Бериллий", 9.0122, "[He] 2s²", "Щелочноземельные", 1, 1);
            AddElement(5, "B", "Бор", 10.81, "[He] 2s² 2p¹", "Металлоиды", 1, 12);
            AddElement(6, "C", "Углерод", 12.011, "[He] 2s² 2p²", "Неметаллы", 1, 13);
            AddElement(7, "N", "Азот", 14.007, "[He] 2s² 2p³", "Неметаллы", 1, 14);
            AddElement(8, "O", "Кислород", 15.999, "[He] 2s² 2p⁴", "Неметаллы", 1, 15);
            AddElement(9, "F", "Фтор", 18.998, "[He] 2s² 2p⁵", "Галогены", 1, 16);
            AddElement(10, "Ne", "Неон", 20.180, "[He] 2s² 2p⁶", "Благородные газы", 1, 17);

            AddElement(11, "Na", "Натрий", 22.990, "[Ne] 3s¹", "Щелочные металлы", 2, 0);
            AddElement(12, "Mg", "Магний", 24.305, "[Ne] 3s²", "Щелочноземельные", 2, 1);
            AddElement(13, "Al", "Алюминий", 26.982, "[Ne] 3s² 3p¹", "Постпереходные", 2, 12);
            AddElement(14, "Si", "Кремний", 28.085, "[Ne] 3s² 3p²", "Металлоиды", 2, 13);
            AddElement(15, "P", "Фосфор", 30.974, "[Ne] 3s² 3p³", "Неметаллы", 2, 14);
            AddElement(16, "S", "Сера", 32.06, "[Ne] 3s² 3p⁴", "Неметаллы", 2, 15);
            AddElement(17, "Cl", "Хлор", 35.45, "[Ne] 3s² 3p⁵", "Галогены", 2, 16);
            AddElement(18, "Ar", "Аргон", 39.948, "[Ne] 3s² 3p⁶", "Благородные газы", 2, 17);

            AddElement(19, "K", "Калий", 39.098, "[Ar] 4s¹", "Щелочные металлы", 3, 0);
            AddElement(20, "Ca", "Кальций", 40.078, "[Ar] 4s²", "Щелочноземельные", 3, 1);
            AddElement(21, "Sc", "Скандий", 44.956, "[Ar] 3d¹ 4s²", "Переходные металлы", 3, 2);
            AddElement(22, "Ti", "Титан", 47.867, "[Ar] 3d² 4s²", "Переходные металлы", 3, 3);
            AddElement(23, "V", "Ванадий", 50.942, "[Ar] 3d³ 4s²", "Переходные металлы", 3, 4);
            AddElement(24, "Cr", "Хром", 51.996, "[Ar] 3d⁵ 4s¹", "Переходные металлы", 3, 5);
            AddElement(25, "Mn", "Марганец", 54.938, "[Ar] 3d⁵ 4s²", "Переходные металлы", 3, 6);
            AddElement(26, "Fe", "Железо", 55.845, "[Ar] 3d⁶ 4s²", "Переходные металлы", 3, 7);
            AddElement(27, "Co", "Кобальт", 58.933, "[Ar] 3d⁷ 4s²", "Переходные металлы", 3, 8);
            AddElement(28, "Ni", "Никель", 58.693, "[Ar] 3d⁸ 4s²", "Переходные металлы", 3, 9);
            AddElement(29, "Cu", "Медь", 63.546, "[Ar] 3d¹⁰ 4s¹", "Переходные металлы", 3, 10);
            AddElement(30, "Zn", "Цинк", 65.38, "[Ar] 3d¹⁰ 4s²", "Переходные металлы", 3, 11);
            AddElement(31, "Ga", "Галлий", 69.723, "[Ar] 3d¹⁰ 4s² 4p¹", "Постпереходные", 3, 12);
            AddElement(32, "Ge", "Германий", 72.630, "[Ar] 3d¹⁰ 4s² 4p²", "Металлоиды", 3, 13);
            AddElement(33, "As", "Мышьяк", 74.922, "[Ar] 3d¹⁰ 4s² 4p³", "Металлоиды", 3, 14);
            AddElement(34, "Se", "Селен", 78.971, "[Ar] 3d¹⁰ 4s² 4p⁴", "Неметаллы", 3, 15);
            AddElement(35, "Br", "Бром", 79.904, "[Ar] 3d¹⁰ 4s² 4p⁵", "Галогены", 3, 16);
            AddElement(36, "Kr", "Криптон", 83.798, "[Ar] 3d¹⁰ 4s² 4p⁶", "Благородные газы", 3, 17);

            AddElement(37, "Rb", "Рубидий", 85.468, "[Kr] 5s¹", "Щелочные металлы", 4, 0);
            AddElement(38, "Sr", "Стронций", 87.62, "[Kr] 5s²", "Щелочноземельные", 4, 1);
            AddElement(39, "Y", "Иттрий", 88.906, "[Kr] 4d¹ 5s²", "Переходные металлы", 4, 2);
            AddElement(40, "Zr", "Цирконий", 91.224, "[Kr] 4d² 5s²", "Переходные металлы", 4, 3);
            AddElement(41, "Nb", "Ниобий", 92.906, "[Kr] 4d⁴ 5s¹", "Переходные металлы", 4, 4);
            AddElement(42, "Mo", "Молибден", 95.95, "[Kr] 4d⁵ 5s¹", "Переходные металлы", 4, 5);
            AddElement(43, "Tc", "Технеций", 98, "[Kr] 4d⁵ 5s²", "Переходные металлы", 4, 6);
            AddElement(44, "Ru", "Рутений", 101.07, "[Kr] 4d⁷ 5s¹", "Переходные металлы", 4, 7);
            AddElement(45, "Rh", "Родий", 102.91, "[Kr] 4d⁸ 5s¹", "Переходные металлы", 4, 8);
            AddElement(46, "Pd", "Палладий", 106.42, "[Kr] 4d¹⁰", "Переходные металлы", 4, 9);
            AddElement(47, "Ag", "Серебро", 107.87, "[Kr] 4d¹⁰ 5s¹", "Переходные металлы", 4, 10);
            AddElement(48, "Cd", "Кадмий", 112.41, "[Kr] 4d¹⁰ 5s²", "Переходные металлы", 4, 11);
            AddElement(49, "In", "Индий", 114.82, "[Kr] 4d¹⁰ 5s² 5p¹", "Постпереходные", 4, 12);
            AddElement(50, "Sn", "Олово", 118.71, "[Kr] 4d¹⁰ 5s² 5p²", "Постпереходные", 4, 13);
            AddElement(51, "Sb", "Сурьма", 121.76, "[Kr] 4d¹⁰ 5s² 5p³", "Металлоиды", 4, 14);
            AddElement(52, "Te", "Теллур", 127.60, "[Kr] 4d¹⁰ 5s² 5p⁴", "Металлоиды", 4, 15);
            AddElement(53, "I", "Йод", 126.90, "[Kr] 4d¹⁰ 5s² 5p⁵", "Галогены", 4, 16);
            AddElement(54, "Xe", "Ксенон", 131.29, "[Kr] 4d¹⁰ 5s² 5p⁶", "Благородные газы", 4, 17);

            AddElement(55, "Cs", "Цезий", 132.91, "[Xe] 6s¹", "Щелочные металлы", 5, 0);
            AddElement(56, "Ba", "Барий", 137.33, "[Xe] 6s²", "Щелочноземельные", 5, 1);
            for (int col = 2; col <= 11; col++)
                AddDummy(5, col);
            AddElement(72, "Hf", "Гафний", 178.49, "[Xe] 4f¹⁴ 5d² 6s²", "Переходные металлы", 5, 2);
            AddElement(73, "Ta", "Тантал", 180.95, "[Xe] 4f¹⁴ 5d³ 6s²", "Переходные металлы", 5, 3);
            AddElement(74, "W", "Вольфрам", 183.84, "[Xe] 4f¹⁴ 5d⁴ 6s²", "Переходные металлы", 5, 4);
            AddElement(75, "Re", "Рений", 186.21, "[Xe] 4f¹⁴ 5d⁵ 6s²", "Переходные металлы", 5, 5);
            AddElement(76, "Os", "Осмий", 190.23, "[Xe] 4f¹⁴ 5d⁶ 6s²", "Переходные металлы", 5, 6);
            AddElement(77, "Ir", "Иридий", 192.22, "[Xe] 4f¹⁴ 5d⁷ 6s²", "Переходные металлы", 5, 7);
            AddElement(78, "Pt", "Платина", 195.08, "[Xe] 4f¹⁴ 5d⁹ 6s¹", "Переходные металлы", 5, 8);
            AddElement(79, "Au", "Золото", 196.97, "[Xe] 4f¹⁴ 5d¹⁰ 6s¹", "Переходные металлы", 5, 9);
            AddElement(80, "Hg", "Ртуть", 200.59, "[Xe] 4f¹⁴ 5d¹⁰ 6s²", "Переходные металлы", 5, 10);
            AddElement(81, "Tl", "Таллий", 204.38, "[Xe] 4f¹⁴ 5d¹⁰ 6s² 6p¹", "Постпереходные", 5, 11);
            AddElement(82, "Pb", "Свинец", 207.2, "[Xe] 4f¹⁴ 5d¹⁰ 6s² 6p²", "Постпереходные", 5, 12);
            AddElement(83, "Bi", "Висмут", 208.98, "[Xe] 4f¹⁴ 5d¹⁰ 6s² 6p³", "Постпереходные", 5, 13);
            AddElement(84, "Po", "Полоний", 209, "[Xe] 4f¹⁴ 5d¹⁰ 6s² 6p⁴", "Металлоиды", 5, 14);
            AddElement(85, "At", "Астат", 210, "[Xe] 4f¹⁴ 5d¹⁰ 6s² 6p⁵", "Галогены", 5, 15);
            AddElement(86, "Rn", "Радон", 222, "[Xe] 4f¹⁴ 5d¹⁰ 6s² 6p⁶", "Благородные газы", 5, 16);

            AddElement(87, "Fr", "Франций", 223, "[Rn] 7s¹", "Щелочные металлы", 6, 0);
            AddElement(88, "Ra", "Радий", 226, "[Rn] 7s²", "Щелочноземельные", 6, 1);
            for (int col = 2; col <= 11; col++)
                AddDummy(6, col);
            AddElement(104, "Rf", "Резерфордий", 267, "[Rn] 5f¹⁴ 6d² 7s²", "Переходные металлы", 6, 2);
            AddElement(105, "Db", "Дубний", 270, "[Rn] 5f¹⁴ 6d³ 7s²", "Переходные металлы", 6, 3);
            AddElement(106, "Sg", "Сиборгий", 271, "[Rn] 5f¹⁴ 6d⁴ 7s²", "Переходные металлы", 6, 4);
            AddElement(107, "Bh", "Борий", 270, "[Rn] 5f¹⁴ 6d⁵ 7s²", "Переходные металлы", 6, 5);
            AddElement(108, "Hs", "Хассий", 277, "[Rn] 5f¹⁴ 6d⁶ 7s²", "Переходные металлы", 6, 6);
            AddElement(109, "Mt", "Мейтнерий", 276, "[Rn] 5f¹⁴ 6d⁷ 7s²", "Переходные металлы", 6, 7);
            AddElement(110, "Ds", "Дармштадтий", 281, "[Rn] 5f¹⁴ 6d⁸ 7s²", "Переходные металлы", 6, 8);
            AddElement(111, "Rg", "Рентгений", 282, "[Rn] 5f¹⁴ 6d⁹ 7s²", "Переходные металлы", 6, 9);
            AddElement(112, "Cn", "Коперниций", 285, "[Rn] 5f¹⁴ 6d¹⁰ 7s²", "Переходные металлы", 6, 10);
            AddElement(113, "Nh", "Нихоний", 286, "[Rn] 5f¹⁴ 6d¹⁰ 7s² 7p¹", "Постпереходные", 6, 11);
            AddElement(114, "Fl", "Флеровий", 289, "[Rn] 5f¹⁴ 6d¹⁰ 7s² 7p²", "Постпереходные", 6, 12);
            AddElement(115, "Mc", "Московий", 290, "[Rn] 5f¹⁴ 6d¹⁰ 7s² 7p³", "Постпереходные", 6, 13);
            AddElement(116, "Lv", "Ливерморий", 293, "[Rn] 5f¹⁴ 6d¹⁰ 7s² 7p⁴", "Постпереходные", 6, 14);
            AddElement(117, "Ts", "Теннессин", 294, "[Rn] 5f¹⁴ 6d¹⁰ 7s² 7p⁵", "Галогены", 6, 15);
            AddElement(118, "Og", "Оганесон", 294, "[Rn] 5f¹⁴ 6d¹⁰ 7s² 7p⁶", "Благородные газы", 6, 16);

            string[] lanthanidesSymbols = { "La", "Ce", "Pr", "Nd", "Pm", "Sm", "Eu", "Gd", "Tb", "Dy", "Ho", "Er", "Tm", "Yb", "Lu" };
            string[] lanthanidesNames = { "Лантан", "Церий", "Празеодим", "Неодим", "Прометий", "Самарий", "Европий", "Гадолиний", "Тербий", "Диспрозий", "Гольмий", "Эрбий", "Тулий", "Иттербий", "Лютеций" };
            double[] lanthanidesMasses = { 138.91, 140.12, 140.91, 144.24, 145, 150.36, 151.96, 157.25, 158.93, 162.50, 164.93, 167.26, 168.93, 173.05, 174.94 };
            string[] lanthanidesConfigs = { "[Xe] 5d¹ 6s²", "[Xe] 4f¹ 5d¹ 6s²", "[Xe] 4f³ 6s²", "[Xe] 4f⁴ 6s²", "[Xe] 4f⁵ 6s²", "[Xe] 4f⁶ 6s²", "[Xe] 4f⁷ 6s²", "[Xe] 4f⁷ 5d¹ 6s²", "[Xe] 4f⁹ 6s²", "[Xe] 4f¹⁰ 6s²", "[Xe] 4f¹¹ 6s²", "[Xe] 4f¹² 6s²", "[Xe] 4f¹³ 6s²", "[Xe] 4f¹⁴ 6s²", "[Xe] 4f¹⁴ 5d¹ 6s²" };

            for (int i = 0; i < lanthanidesSymbols.Length; i++)
            {
                AddElement(57 + i, lanthanidesSymbols[i], lanthanidesNames[i], lanthanidesMasses[i],
                          lanthanidesConfigs[i], "Лантаноиды", 8, 2 + i);
            }

            string[] actinidesSymbols = { "Ac", "Th", "Pa", "U", "Np", "Pu", "Am", "Cm", "Bk", "Cf", "Es", "Fm", "Md", "No", "Lr" };
            string[] actinidesNames = { "Актиний", "Торий", "Протактиний", "Уран", "Нептуний", "Плутоний", "Америций", "Кюрий", "Берклий", "Калифорний", "Эйнштейний", "Фермий", "Менделевий", "Нобелий", "Лоуренсий" };
            double[] actinidesMasses = { 227, 232.04, 231.04, 238.03, 237, 244, 243, 247, 247, 251, 252, 257, 258, 259, 266 };
            string[] actinidesConfigs = { "[Rn] 6d¹ 7s²", "[Rn] 6d² 7s²", "[Rn] 5f² 6d¹ 7s²", "[Rn] 5f³ 6d¹ 7s²", "[Rn] 5f⁴ 6d¹ 7s²", "[Rn] 5f⁶ 7s²", "[Rn] 5f⁷ 7s²", "[Rn] 5f⁷ 6d¹ 7s²", "[Rn] 5f⁹ 7s²", "[Rn] 5f¹⁰ 7s²", "[Rn] 5f¹¹ 7s²", "[Rn] 5f¹² 7s²", "[Rn] 5f¹³ 7s²", "[Rn] 5f¹⁴ 7s²", "[Rn] 5f¹⁴ 7s² 7p¹" };

            for (int i = 0; i < actinidesSymbols.Length; i++)
            {
                AddElement(89 + i, actinidesSymbols[i], actinidesNames[i], actinidesMasses[i],
                          actinidesConfigs[i], "Актиноиды", 9, 2 + i);
            }
        }

        private void AddElement(int atomicNum, string symbol, string name, double atomicMass,
                             string electronConfig, string category, int row, int col)
        {
            AllElements.Add(new ElementItem
            {
                AtomicNumber = atomicNum,
                Symbol = symbol,
                NameRu = name,
                Category = category,
                AtomicMass = atomicMass,
                ElectronConfig = electronConfig,
                Row = row,
                Column = col,
                IsDummy = false
            });
        }

        private void AddDummy(int row, int col)
        {
            AllElements.Add(new ElementItem
            {
                IsDummy = true,
                Row = row,
                Column = col
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ElementItem : INotifyPropertyChanged
    {
        private int _atomicNumber;
        private string _symbol;
        private string _nameRu;
        private string _category;
        private double _atomicMass;
        private string _electronConfig;
        private int _row;
        private int _column;
        private bool _isDummy;

        public int AtomicNumber
        {
            get => _atomicNumber;
            set { _atomicNumber = value; OnPropertyChanged(); }
        }

        public string Symbol
        {
            get => _symbol;
            set { _symbol = value; OnPropertyChanged(); }
        }

        public string NameRu
        {
            get => _nameRu;
            set { _nameRu = value; OnPropertyChanged(); }
        }

        public string Category
        {
            get => _category;
            set { _category = value; OnPropertyChanged(); }
        }

        public double AtomicMass
        {
            get => _atomicMass;
            set { _atomicMass = value; OnPropertyChanged(); }
        }

        public string ElectronConfig
        {
            get => _electronConfig;
            set { _electronConfig = value; OnPropertyChanged(); }
        }

        public int Row
        {
            get => _row;
            set { _row = value; OnPropertyChanged(); }
        }

        public int Column
        {
            get => _column;
            set { _column = value; OnPropertyChanged(); }
        }

        public bool IsDummy
        {
            get => _isDummy;
            set { _isDummy = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}